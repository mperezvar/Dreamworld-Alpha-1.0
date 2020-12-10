using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemigo : MonoBehaviour
{
    public GameObject panelC;
    public TextMeshProUGUI mensajeC;

    private GameObject objeto;
    private GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        objeto = GameObject.Find("Posicion");
        jugador = GameObject.Find("Protagonista");
       
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            objeto.GetComponent<Datos>().setPosicion(jugador.GetComponent<Transform>().position);
            jugador.GetComponent<DatosJugador>().setNombreLvLP(Nombre(SceneManager.GetActiveScene().buildIndex));
            jugador.GetComponent<Movimiento>().enabled = false;
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {

                StartCoroutine(Escribir("¡Te has encontrado con un delirio del valle!"));
            }
            else
            {
                StartCoroutine(Escribir("¡Te has encontrado con un delirio de la montaña!"));
            }
            
        }
    }

    IEnumerator Escribir(string str)
    {
        string s = "";
        string[] oraciones = { str };
        for (int i = 0; i < oraciones.Length; i++)
        {
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
            yield return new WaitWhile(() => !(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)));
        }
        yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        SceneManager.LoadScene("Batalla");
    }

    string Nombre(int i)
    {
        switch (i)
        {
            case 1:
                return "Habitación";
            case 2:
                return "Bosque inicial";
            case 3:
                return "Montañas";
            default:
                return "Habitación";
        }
    }
}
