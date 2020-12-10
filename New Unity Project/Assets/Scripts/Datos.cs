using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datos : MonoBehaviour
{

    static private Vector3 posicion;
    static private Vector3 posGuardado;

    static int numValle = 5;
    static int numMontañas = 15;
    static private bool pausa = false, batalla=false;
    static int vidaEnemigo;

    private GameObject jugador;
    private GameObject enemigo;
    private bool cama = false;
    private bool cofre = false;
    private bool camaReturn = false;
    private bool oso = false;
    private bool NuevaEscena = false;
    private bool AnteriorEscena = false;
    private bool Tienda = false;
    private Vector3 nulo = new Vector3(0, 0, 0);

    //Setters
    public void setCama(bool b)
    {
        cama = b;
    }
    public void setCofre(bool b)
    {
        cofre = b;
    }
    public void setCamaR(bool b)
    {
        camaReturn = b;
    }
    public void setOso(bool b)
    {
        oso = b;
    }
    public void setPosicion(Vector3 pos)
    {
        posicion = pos;
    }
    public void setPosG(Vector3 pos)
    {
        posGuardado = pos;
    }
    public void setNE(bool b)
    {
        NuevaEscena = b;
    }
    public void setAE(bool b)
    {
        AnteriorEscena = b;
    }
    public void setTienda(bool b)
    {
        Tienda = b;
    }
    public void setPausa(bool b)
    {
        pausa = b;
    }
    public void setBatalla(bool b, int num)
    {
        batalla = b;
        vidaEnemigo = num;
    }

    //Getters
    public bool getCama()
    {
        return cama;
    }
    public bool getCofre()
    {
        return cofre;
    }
    public bool getCamaR()
    {
        return camaReturn;
    }
    public bool getOso()
    {
        return oso;
    }
    public Vector3 getPosicion()
    {
        return posicion;
    }
    public Vector3 getPosG()
    {
        return posGuardado;
    }
    public bool getNE()
    {
        return NuevaEscena;
    }
    public bool getAE()
    {
        return AnteriorEscena;
    }
    public bool getTienda()
    {
        return Tienda;
    }
    public bool getPausa()
    {
        return pausa;
    }
    public bool getBatalla()
    {
        return batalla;
    }
    public int getVidaE()
    {
        return vidaEnemigo;
    }


    //Métodos 
    public void DesactivarTags()
    {
        setCama(false);
        setCamaR(false);
        setCofre(false);
        setOso(false);
        setNE(false);
        setAE(false);
        setTienda(false);
        print("Se han desactivado todos los tags");
    }

    public void Start()
    {
        cama = false;
        cofre = false;
        camaReturn = false;
        oso = false;
        NuevaEscena = false;
        AnteriorEscena = false;
        Tienda = false;

        GenEnemigo();
        
        print("Posicion: " + posicion);
        print("Posicion G: " + posGuardado);

        if (posicion!= nulo && !(SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 9))
        {
            jugador.GetComponent<DatosJugador>().TP(posicion);
            posicion = nulo;
        }
        else if (jugador.GetComponent<DatosJugador>().GetNombreLvL() != "" && Nombre(SceneManager.GetActiveScene().buildIndex) == jugador.GetComponent<DatosJugador>().GetNombreLvL())
        {
            jugador.GetComponent<DatosJugador>().TP(posGuardado);
        }

    }
    public void PosicionGuardado()
    {
        if(oso)
            posGuardado = jugador.GetComponent<Transform>().position;
    }

    public void Awake()
    {
        jugador = GameObject.Find("Protagonista");
        enemigo = GameObject.Find("Enemigo");
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

    void GenEnemigo()
    {
        if (Nombre(SceneManager.GetActiveScene().buildIndex) == "Bosque inicial")
        {
            for (int i = 0; i < numValle; i++)
            {
                if(i < numValle / 2)
                {
                    Vector3 posicion = new Vector3(Random.Range(-95.02f, -76.93f), Random.Range(52.94f, 40.44f), 0);
                    Instantiate(enemigo, posicion, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                }
                else
                {
                    Vector3 posicion = new Vector3(Random.Range(-61.58f, -44.42f), Random.Range(73.29f, 51.07f), 0);
                    Instantiate(enemigo, posicion, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                }
            }

        }
        else if (Nombre(SceneManager.GetActiveScene().buildIndex) == "Montañas")
        {
            for (int i = 0; i < numMontañas; i++)
            {
                if(i < numMontañas / 2)
                {
                    Vector3 posicion = new Vector3(Random.Range(-16.15f, 15.83f), Random.Range(-78.01f, 20.92f), 0);
                    Instantiate(enemigo, posicion, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                }
                else
                {
                    Vector3 posicion = new Vector3(Random.Range(102.42f, 148.0f), Random.Range(-81.4f, 16.39f), 0);
                    Instantiate(enemigo, posicion, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                }
            }
        }

    }
}
