using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class selecc : MonoBehaviour
{
    public bool permi;
    public TextMeshProUGUI SALV, ATKM, ATKF, ATKX, HUIR, OBJ, VidaJug;
    public GameObject sel,fueg,explo,jugad;
    private GameObject cop,fuego;
    private bool pres;
    private Vector3 at_mag,at_x,salv,at_fis,inve,hui;
    private GameObject bot1, bot2, bot3, bot4, bot5, bot6;

    private bool turnoJug = true;
    private bool turno = true;
    private int dañoBJugador, daño;

    private GameObject enemigo, jugador, objeto;

    // Start is called before the first frame update
    void Start()
    {
        
        permi =true;
        bot1 = GameObject.Find("1");
        bot2= GameObject.Find("2");
        bot3= GameObject.Find("3");
        bot4= GameObject.Find("4");
        bot5= GameObject.Find("5");
        bot6 = GameObject.Find("6");

        at_mag = bot1.GetComponent<Transform>().position;
        gameObject.transform.position = at_mag;
        at_x = bot2.GetComponent<Transform>().position;
        salv = bot3.GetComponent<Transform>().position;
        at_fis = bot4.GetComponent<Transform>().position;
        inve = bot5.GetComponent<Transform>().position;
        hui = bot6.GetComponent<Transform>().position;

        objeto = GameObject.Find("Posicion");
        jugador = GameObject.Find("Protagonista");
        enemigo = GameObject.Find("enemi");
        dañoBJugador = jugador.GetComponent<DatosJugador>().GetDaño();
        if (objeto.GetComponent<Datos>().getBatalla())
        {
            objeto.GetComponent<Datos>().setBatalla(false, 0);
            turno = false;
            turnoJug = false;
        }

    }

    public bool GetTurno()
    {
        return turno;
    }
    public void SetTurno(bool b)
    {
        turno = b;
    }

    public bool GetTurnoJug()
    {
        return turnoJug;
    }
    public void SetTurnoJug(bool b)
    {
        turnoJug = b;
    }

    // Update is called once per frame
    void Update()
    {
        VidaJug.text = "Vida: " + jugador.GetComponent<DatosJugador>().GetVida() + "/" + jugador.GetComponent<DatosJugador>().GetVidaB();
        if (jugador.GetComponent<DatosJugador>().GetVida() <= 0)
        {
            turnoJug = false;
            objeto.GetComponent<Datos>().setPosicion(new Vector3(0, 0, 0));
            ATKF.text = ""; ATKM.text = ""; ATKX.text = ""; HUIR.text = ""; SALV.text = ""; OBJ.text = "";
            enemigo.GetComponent<EnemigoB>().GameOver();
        }

        if (turnoJug)
        {
            ATKF.text = "Golpe Cortante"; ATKM.text = "Bola de fuego"; ATKX.text = "Ataque x"; HUIR.text = "HUIR"; SALV.text = "SALVAR"; OBJ.text = "OBJETOS";
        }
        if (gameObject.transform.position == at_mag)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                ;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                gameObject.transform.position = at_fis;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.position = at_x;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                ;
            }
            if (turnoJug && (Input.GetKeyUp("return") || Input.GetKeyUp(KeyCode.Z)))
            {
                if (permi == true)
                {
                    ATKF.text = ""; ATKM.text = ""; ATKX.text = ""; HUIR.text = ""; SALV.text = ""; OBJ.text = "";
                    turnoJug = false;
                    daño = Random.Range(dañoBJugador, dañoBJugador * 2);
                    enemigo.GetComponent<EnemigoB>().Ataque(daño);

                    cop = Instantiate(sel);
                    cop.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.122f);
                    cop.tag = "copia";
                    fuego = Instantiate(fueg);
                    fuego.tag = "fueg_temp";
                    permi = false;

                }

            }
        }
        else if (gameObject.transform.position == at_x)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                ;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                gameObject.transform.position = inve;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.position = salv;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.position = at_mag;
            }
            if (turnoJug && (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Z)))
            {
                if (permi == true)
                {
                    turnoJug = false;
                    ATKF.text = ""; ATKM.text = ""; ATKX.text = ""; HUIR.text = ""; SALV.text = ""; OBJ.text = "";
                    daño = Random.Range(1, dañoBJugador*2);
                    enemigo.GetComponent<EnemigoB>().Ataque(daño);

                    cop = Instantiate(sel);
                    cop.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.122f);
                    cop.tag = "copia";
                }

            }
        }
        else if (gameObject.transform.position == salv)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                ;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                gameObject.transform.position = hui;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                ;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.position = at_x;
            }
            if (turnoJug && (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Z)))
            {
                if (permi == true)
                {
                    ATKF.text = ""; ATKM.text = ""; ATKX.text = ""; HUIR.text = ""; SALV.text = ""; OBJ.text = "";
                    turnoJug = false;
                    enemigo.GetComponent<EnemigoB>().Salvar();

                    cop = Instantiate(sel);
                    cop.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.122f);
                    cop.tag = "copia";
                }
                
            }
        }
        else if (gameObject.transform.position == at_fis)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                gameObject.transform.position = at_mag;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                ;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.position = inve;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                ;
            }
            if (turnoJug && (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Z)))
            {
                if (permi == true)
                {
                    ATKF.text = ""; ATKM.text = ""; ATKX.text = ""; HUIR.text = ""; SALV.text = ""; OBJ.text = "";
                    turnoJug = false;
                    daño = Random.Range(dañoBJugador - dañoBJugador / 2, dañoBJugador * 2 - dañoBJugador / 2);
                    enemigo.GetComponent<EnemigoB>().Ataque(daño);

                    cop = Instantiate(sel);
                    cop.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.122f);
                    cop.tag = "copia";
                    jugad.GetComponent<personaje>().at_fis = true;
                }
            }
        }
        else if (gameObject.transform.position == inve)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                gameObject.transform.position = at_x;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                ;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.position = hui;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.position = at_fis;
            }
            if (turnoJug && Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Z))
            {
                if (permi == true)
                {
                    turno = false;
                    objeto.GetComponent<Datos>().setBatalla(true, enemigo.GetComponent<EnemigoB>().getVidaE());
                    SceneManager.LoadScene("Objetos");
                    cop = Instantiate(sel);
                    cop.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.122f);
                    cop.tag = "copia";
                }

            }
        }
        else if (gameObject.transform.position == hui)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                gameObject.transform.position = salv;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                ;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                ;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.position = inve;
            }
            if (turnoJug && (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Z)))
            {
                if (permi == true)
                {
                    cop = Instantiate(sel);
                    cop.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.122f);
                    cop.tag = "copia";
                    SceneManager.LoadScene(jugador.GetComponent<DatosJugador>().GetNombreLvLP());
                }
            }
        }
    }

}
