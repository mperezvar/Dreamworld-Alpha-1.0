using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Pausa : MonoBehaviour
{
    public GameObject jugador;
    public GameObject objeto;

    static private Vector3 posicion;
    public bool enabled;

    public void volver()
    {
        objeto.GetComponent<Datos>().setPausa(false);
        SceneManager.LoadScene(jugador.GetComponent<DatosJugador>().GetNombreLvLP());
    }
    public void inventario()
    {
        SceneManager.LoadScene("Objetos");
    }
    public void menu()
    {
        objeto.GetComponent<Datos>().setPosicion(new Vector3(0,0,0));
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) && enabled)
        {
            objeto.GetComponent<Datos>().setPausa(true);
            objeto.GetComponent<Datos>().setPosicion(jugador.GetComponent<Transform>().position);
            nombreEscena(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Pausa");
        }
    }
    void nombreEscena(int i)
    {
        switch (i)
        {
            case 1:
                jugador.GetComponent<DatosJugador>().setNombreLvLP("Habitación");
                break;
            case 2:
                jugador.GetComponent<DatosJugador>().setNombreLvLP("Bosque inicial");
                break;
            case 3:
                jugador.GetComponent<DatosJugador>().setNombreLvLP("Montañas");
                break;
            default:
                jugador.GetComponent<DatosJugador>().setNombreLvLP("Habitación");
                break;
        }
    }

}
