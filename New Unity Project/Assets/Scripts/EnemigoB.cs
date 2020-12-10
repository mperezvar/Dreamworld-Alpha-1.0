using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemigoB : MonoBehaviour
{
    public float osci;
    public bool expl;

    public GameObject Panel, selecci;
    public TextMeshProUGUI mensaje;

    private int vida, vidainicial, dañoBase, DEF, daño, acum;

    private GameObject jugador, selec, objeto;

    private bool solo1 = true;
    private bool debil = false;
    private bool gameover = false;
    
    // Start is called before the first frame update

    public int getVidaE()
    {
        return vida;
    }
    void Start()
    {
        jugador = GameObject.Find("Protagonista");
        selec = GameObject.Find("seleccion");
        objeto = GameObject.Find("Posicion");

        acum = 0;
        expl = false;


        DEF = jugador.GetComponent<DatosJugador>().GetDEF() / 2 + 1;
        dañoBase = jugador.GetComponent<DatosJugador>().GetDaño() / 2;
        if (objeto.GetComponent<Datos>().getBatalla())
        {
            vida = objeto.GetComponent<Datos>().getVidaE();
        }
        else
        {
            vida = jugador.GetComponent<DatosJugador>().GetVida() / 2 + 3;
        }

        vidainicial = jugador.GetComponent<DatosJugador>().GetVida() / 2 + 3;
}
    public void Salvar()
    {
        if (debil && solo1)
        {
            int dinero = Random.Range(1, 6);
            jugador.GetComponent<DatosJugador>().SetDinero(jugador.GetComponent<DatosJugador>().GetDinero() + dinero);
            string[] oraciones = { "El enemigo estaba muy débil. ¡Lograste salvarlo de sus pesadillas!", "¡Has obtenido "+ dinero+" lunas!"};
            jugador.GetComponent<DatosJugador>().SetEXP(jugador.GetComponent<DatosJugador>().GetEXP() + 5);
            solo1 = false;
            StopAllCoroutines();
            StartCoroutine(Escribir(oraciones, true, true));
        }
        else if (solo1)
        {
            solo1 = false;
            string[] oraciones = { "Aún no lo puedes salvar... ¡Es muy fuerte!" };
            StopAllCoroutines();
            StartCoroutine(Escribir(oraciones, true, false));
        }
    }
    public void Ataque(int atk)
    {
        if (solo1)
        {
            solo1 = false;
            atk = atk - DEF;
            if (atk > 0)
            {
                string[] oraciones = { "¡Has hecho " + atk + " puntos de daño al enemigo!" };
                vida = vida - atk;
                StopAllCoroutines();
                StartCoroutine(Escribir(oraciones, true, false));
            }
            else
            {
                string[] oraciones = { "¡El enemigo ha esquivado el ataque!" };
                StopAllCoroutines();
                StartCoroutine(Escribir(oraciones, true, false));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (expl) {
            acum++;
            if (acum % 2 == 0) {
                transform.position += new Vector3(0.1f, 0, 0);
            }
            else if (acum % 2 != 0) {
                transform.position += new Vector3(-0.1f, 0, 0);
            }
            if (acum > osci) {
                expl = false;
                selecci.GetComponent<selecc>().permi = true;
            }
        }
        else {
            acum = 0;
        }
        if (vida < vidainicial / 2)
        {
            debil = true;
        }
        //Acciones del enemigo
        if (vida <= 0)
        {
            if (solo1)
            {
                int dinero = Random.Range(5, 10);
                jugador.GetComponent<DatosJugador>().SetDinero(jugador.GetComponent<DatosJugador>().GetDinero() + dinero);
                string[] oraciones = { "Has acabado con el delirio" , "¡Has obtenido " + dinero + " lunas!" };

                jugador.GetComponent<DatosJugador>().SetEXP(jugador.GetComponent<DatosJugador>().GetEXP() + 5);
                solo1 = false;
                StopAllCoroutines();
                
                StartCoroutine(Escribir(oraciones, false, true));
            }

        }
        else if (selec.GetComponent<selecc>().GetTurno() == false)
        {
            if (solo1)
            {
                string[] aleatorio = { "“Con que quieres pelear eh?”", "“Simplemente eres un obstáculo al que debo derribar.”" ,
            "“Mis habilidades son infinitamente superiores, prepárate para perder.”", "“Nunca he perdido en el tiempo que llevo aquí, no va a ser esta la excepción.”",
        "“Rendirte es tu única opción.”", "“Deja de molestar mi camino, aléjate!.”"};
                string[] aleatorioDeb = { "“Oye, jajaja, no es necesario pelear!.”", "“Por favor amigo, perdóname, yo sólo quería estar en paz.”", "“Nunca había sido derrotado, pido piedad noble guerrero.”",
            "“NOOOOO misericordiaaa!”", "“Demonios, creo que he perdido.”" };
                //Frases en batalla
                solo1 = false;
                print(vida);
                daño = Random.Range(dañoBase, dañoBase * 2 + 2);
                daño = daño - jugador.GetComponent<DatosJugador>().GetDEF();
                int aleatorio1 = Random.Range(0, 6);
                int aleatorio2 = Random.Range(0, 5);

                if (vida >= vidainicial / 2 && daño > 0)
                {
                    string[] oraciones = { "¡Te han hecho " + daño + " puntos de daño!", aleatorio[aleatorio1]};
                    jugador.GetComponent<DatosJugador>().SetVida(jugador.GetComponent<DatosJugador>().GetVida() - daño);
                    print("Vida jugador " + jugador.GetComponent<DatosJugador>().GetVida());
                    StopAllCoroutines();
                    StartCoroutine(Escribir(oraciones, false, false));
                }
                else if (vida < vidainicial / 2 && daño > 0)
                {
                    debil = true;
                    string[] oraciones = { "¡Te han hecho " + daño + " puntos de daño!", " ¡El enemigo está débil!" , aleatorioDeb[aleatorio2]};
                    jugador.GetComponent<DatosJugador>().SetVida(jugador.GetComponent<DatosJugador>().GetVida() - daño);
                    print("Vida jugador " + jugador.GetComponent<DatosJugador>().GetVida());
                    StopAllCoroutines();
                    StartCoroutine(Escribir(oraciones, false, false));
                }
                else if(vida < vidainicial / 2 && daño <= 0)
                {
                    debil = true;
                    string[] oraciones = { "¡Esquivaste el ataque!", "¡El enemigo está débil!", aleatorioDeb[aleatorio2]};
                    StopAllCoroutines();
                    StartCoroutine(Escribir(oraciones, false, false));
                }
                else
                {
                    string[] oraciones = { "¡Esquivaste el ataque!", aleatorio[aleatorio1]};
                    StopAllCoroutines();
                    StartCoroutine(Escribir(oraciones, false, false));
                }
            }

        }
    }

    public void GameOver()
    {
        if (solo1)
        {
            gameover = true;
            string[] oraciones = { "Has sido derrotado... ¡Vuelve a intentarlo!" };
            solo1 = false;
            StopAllCoroutines();
            StartCoroutine(Escribir(oraciones, false, false));
        }
    }

    IEnumerator Escribir(string[] oracion, bool b, bool exit)
    {
        string s = "";
        Panel.SetActive(true);

        //Ciclo for que muestra las oraciones en pantalla letra por letra
        for (int i = 0; i < oracion.Length; i++)
        {
            for (int let = 0; let < oracion[i].Length; let++)
            {
                yield return new WaitForSeconds(0.07f);
                s = s + oracion[i][let].ToString();
                mensaje.text = s;

                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
                {
                    mensaje.text = oracion[i];
                    yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                    break;
                }
            }
            yield return new WaitWhile(() => !(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)));
            s = "";
        }
        yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        s = "";
        if (gameover)
        {
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            jugador.GetComponent<DatosJugador>().SetVida(jugador.GetComponent<DatosJugador>().GetVidaBG());

            int expG = jugador.GetComponent<DatosJugador>().getEXPG();
            int nivelG = jugador.GetComponent<DatosJugador>().getNivelG();
            int dañoG = jugador.GetComponent<DatosJugador>().GetDañoG();
            int defG = jugador.GetComponent<DatosJugador>().GetDEFG();
            int vidaM = jugador.GetComponent<DatosJugador>().GetVidaMaxG();
            int dineroG = jugador.GetComponent<DatosJugador>().GetDineroG();

            Items armG= jugador.GetComponent<DatosJugador>().getArmaduraG();
            Items atkG = jugador.GetComponent<DatosJugador>().getAtaqueG();

            jugador.GetComponent<DatosJugador>().SetEXP(expG);
            jugador.GetComponent<DatosJugador>().SetNivel(nivelG);
            jugador.GetComponent<DatosJugador>().SetDaño(dañoG);
            jugador.GetComponent<DatosJugador>().SetDEF(defG);
            jugador.GetComponent<DatosJugador>().setArmadura(armG);
            jugador.GetComponent<DatosJugador>().setAtaque(atkG);
            jugador.GetComponent<DatosJugador>().SetVidaB(vidaM);
            jugador.GetComponent<DatosJugador>().SetDinero(dineroG);


            SceneManager.LoadScene("GameOver");
        }
        else if (exit)
        {
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            SceneManager.LoadScene(jugador.GetComponent<DatosJugador>().GetNombreLvLP());
        }
        if (b)
        {
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            selec.GetComponent<selecc>().SetTurno(false);
        }
        else
        {
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            selec.GetComponent<selecc>().SetTurnoJug(true);
            selec.GetComponent<selecc>().SetTurno(true);
            Panel.SetActive(false);
            mensaje.text = "";
        }
        solo1 = true;
    }
}
