using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class STATSPausa : MonoBehaviour
{
    private GameObject jugador;
    public TextMeshProUGUI vida;
    public TextMeshProUGUI def;
    public TextMeshProUGUI daño;
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI exp;
    public TextMeshProUGUI dinero;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Protagonista");
        vida.text = "VIDA: " + jugador.GetComponent<DatosJugador>().GetVida()+"/"+ jugador.GetComponent<DatosJugador>().GetVidaB();
        def.text = "DEF: "+ jugador.GetComponent<DatosJugador>().GetDEF();
        exp.text = "EXP: " + jugador.GetComponent<DatosJugador>().GetEXP();
        daño.text = "DAÑO: " + jugador.GetComponent<DatosJugador>().GetDaño();
        lvl.text = "NIVEL: " + jugador.GetComponent<DatosJugador>().GetNivel();
        dinero.text = "LUNAS: " + jugador.GetComponent<DatosJugador>().GetDinero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
