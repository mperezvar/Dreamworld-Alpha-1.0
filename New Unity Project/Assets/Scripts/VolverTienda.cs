using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class VolverTienda : MonoBehaviour
{
    private GameObject jugador;
    public TextMeshProUGUI texto;
    public GameObject objeto, panel;
    public Button[] botones;
    // Start is called before the first frame update
    public void volver()
    {
        SceneManager.LoadScene(jugador.GetComponent<DatosJugador>().GetNombreLvLP());
    }
    void Start()
    {
        jugador = GameObject.Find("Protagonista");
    }
    
    public void Texto()
    {
        panel.SetActive(true);
        StopAllCoroutines();

        for(int i=0; i<botones.Length; i++)
        {
            botones[i].interactable = false;
        }
        if (jugador.GetComponent<DatosJugador>().Lleno())
        {
            StopAllCoroutines();
            StartCoroutine(Escribir("¡Tu inventario está lleno!"));
        }
        else
        {
            if (jugador.GetComponent<DatosJugador>().pobre)
            {
                StartCoroutine(Escribir("¡Rayos! Creo que no tienes suficientes lunas para comprar este artículo."));
            }
            else
            {
                switch (objeto.GetComponent<Inventario>().getTipo())
                {
                    case "Consumible":
                        StartCoroutine(Escribir("Has comprado " + objeto.GetComponent<Inventario>().getNombre() + " que da +" + objeto.GetComponent<Inventario>().getModificador() + " VIDA"));
                        break;
                    case "EquipableDEF":
                        StartCoroutine(Escribir("Has comprado " + objeto.GetComponent<Inventario>().getNombre() + " que da +" + objeto.GetComponent<Inventario>().getModificador() + " DEF"));
                        break;
                    case "EquipableATK":
                        StartCoroutine(Escribir("Has comprado " + objeto.GetComponent<Inventario>().getNombre() + " que da +" + objeto.GetComponent<Inventario>().getModificador() + " ATK"));
                        break;
                    default:
                        StartCoroutine(Escribir("Error"));
                        break;
                }
            }
        }
    }
    IEnumerator Escribir(string oracion)
    {
        string s = "";

        //Ciclo for que muestra las oraciones en pantalla letra por letra
        for (int i = 0; i < 1; i++)
        {
            for (int let = 0; let < oracion.Length; let++)
            {
                yield return new WaitForSeconds(0.07f);
                s = s + oracion[let];
                texto.text = s;

                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
                {
                    texto.text = oracion;
                    yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                    break;
                }
            }
            yield return new WaitWhile(() => !(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)));
            s = "";
        }
        yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        panel.SetActive(false);
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].interactable = true;
        }
        s = "";
        texto.text = "";
    }
}
