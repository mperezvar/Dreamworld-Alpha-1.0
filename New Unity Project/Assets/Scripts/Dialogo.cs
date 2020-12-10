using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] oraciones;
    public TextMeshProUGUI mensajeC;
    public TextMeshProUGUI avisoC;
    public GameObject panelC;
    public GameObject jugador;
    public GameObject objeto;

    public Button[] Opciones;
    public string[] OPText;
    public GameObject panelaviso;
    private string s = "";
    

    public bool Complejo;

    // Start is called before the first frame update
    void Start()
    {
        panelaviso.SetActive(false);
        for (int n = 0; n < Opciones.Length; n++)
        {
            Opciones[n].interactable = false;
        }

        panelC.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            s = "";
            panelaviso.SetActive(true);
            avisoC.text = "Presiona Z o ENTER para interactuar";
            if (Complejo)
                StartCoroutine(DialogoC());
            else
                StartCoroutine(iniciarDialogo());
        }
    }

    //Activa una conversación simple sin uso de botones
    IEnumerator iniciarDialogo()
    {
        yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        avisoC.text = "";
        jugador.GetComponent<Movimiento>().desactCapas();
        panelaviso.SetActive(false);
        jugador.GetComponent<Movimiento>().enabled = false;


        for (int i = 0; i < oraciones.Length; i++)
        {
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            
            panelC.SetActive(true);

            //Ciclo for que muestra las oraciones en pantalla letra por letra
            for (int let = 0; let < oraciones[i].Length; let++)
            {
                yield return new WaitForSeconds(0.07f);
                s = s + oraciones[i][let].ToString();
                mensajeC.text = s;
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
                {
                    mensajeC.text = oraciones[i];
                    yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                    break;
                }
            }
            s = "";
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));

            //Cuando se acabe el diálogo el jugador vuelve a tener su velocidad anterior.
            if (i == oraciones.Length - 1)
                jugador.GetComponent<Movimiento>().enabled = true;
        }
    }

    //Muestra las oraciones de los personajes en pantalla
    IEnumerator DialogoC()
    {
        //Al presionar Z o Enter el aviso se va
        TagID();
        yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        avisoC.text = "";
        panelaviso.SetActive(false);
        jugador.GetComponent<Movimiento>().desactCapas();
        jugador.GetComponent<Movimiento>().enabled = false;
        

        //Ciclo for que muestra las oraciones en pantalla
        for (int i = 0; i < oraciones.Length; i++)
        {
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            
            panelC.SetActive(true);
            for (int let = 0; let < oraciones[i].Length; let++)
            {
                yield return new WaitForSeconds(0.07f);
                s = s + oraciones[i][let].ToString();
                mensajeC.text = s;
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
                {
                    mensajeC.text = oraciones[i];
                    yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                    break;
                }
            }
            s = "";
            if (i == oraciones.Length - 1)
            {
                yield return new WaitForSecondsRealtime(2.0f);
                for (int j = 0; j < Opciones.Length; j++)
                {
                    Opciones[j].interactable = true;
                    Opciones[j].GetComponentInChildren<TextMeshProUGUI>().text = OPText[j];
                }
            }
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        }
    }
    void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            objeto.GetComponent<Datos>().DesactivarTags();
            Apagar();
        }
    }

    //Desactiva todos los elementos del UI cuando los colliders dejan de tocarse
    void Apagar()
    {
        StopAllCoroutines();
        s = "";
        mensajeC.text = "";
        panelC.SetActive(false);
        avisoC.text = "";
        panelaviso.SetActive(false);
    }

    //Métodos para identificar el Tag del Objeto cuando se van a habilitar botones

    void TagID() //Identifica el Tag del objeto con el que se está colisionando y se añade un valor booleano a un objeto externo dependiendo del objeto con el que colisiona
    {
        switch (this.tag)
        {
            case "Cama":
                objeto.GetComponent<Datos>().setCama(true);
                break;
            case "Cofre":
                objeto.GetComponent<Datos>().setCofre(true);
                break;
            case "CamaReturn":
                objeto.GetComponent<Datos>().setCamaR(true);
                break;
            case "OsoG":
                objeto.GetComponent<Datos>().setOso(true);
                break;
            case "NuevaEscena":
                objeto.GetComponent<Datos>().setNE(true);
                break;
            case "AnteriorEscena":
                objeto.GetComponent<Datos>().setAE(true);
                break;
            case "Tienda":
                objeto.GetComponent<Datos>().setTienda(true);
                break;
            default:
                break;

        }
    }

}

