using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinero : MonoBehaviour
{
    public TextMeshProUGUI dinero;
    private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Protagonista");
    }

    // Update is called once per frame
    void Update()
    {
        dinero.text = "Lunas: " + jugador.GetComponent<DatosJugador>().GetDinero();
    }
}
