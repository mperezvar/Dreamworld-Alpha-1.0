using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOvBotones : MonoBehaviour
{
    private GameObject jugador, objeto;
    void Start()
    {
        objeto = GameObject.Find("Posicion");
        jugador = GameObject.Find("Protagonista");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Fondo animado menu");
    }
    public void Intentarlo()
    {
        if (jugador.GetComponent<DatosJugador>().GetNombreLvL() != "")
        {
            SceneManager.LoadScene(jugador.GetComponent<DatosJugador>().GetNombreLvL());
        }
        else
        {
            SceneManager.LoadScene("Habitación");
        }
    }
}
