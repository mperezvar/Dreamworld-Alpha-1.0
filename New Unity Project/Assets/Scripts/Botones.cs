using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Botones : MonoBehaviour
{
    public TextMeshProUGUI mensaje;
    public Button[] Opciones;
    public GameObject jugador;
    public GameObject objeto;
    public string[] CerrarCama;
    public string[] CerrarCofre;
    public string[] CerrarOso;
    public string[] CerrarTienda;
    public string[] Guardado;

    private string[] error = { "Ha habido un error cargando la escena. Código 3312" };
    private string s = "";

    private bool errorBool = false;

    private bool camaR=true;
    private bool camaG=true;
    private bool camasinG= true;
    private bool Cofre=true;
    private bool OsoG=true;
    private bool NuevaE=true;
    private bool AnteriorE = true;
    private bool Tienda = true;


    IEnumerator Escribir(string[] str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            yield return new WaitForSeconds(0.2f);
            for (int let = 0; let < str[i].Length; let++)
            {
                yield return new WaitForSeconds(0.07f);
                s = s + str[i][let].ToString();
                mensaje.text = s;
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
                {
                    mensaje.text = str[i];
                    yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                    break;
                }
            }
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            s = "";
        }
        jugador.GetComponent<Movimiento>().enabled = true;

        errorBool = false;
    }

    IEnumerator EscribirGuardado(string[] str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            yield return new WaitForSeconds(0.6f);
            for (int let = 0; let < str[i].Length; let++)
            {
                yield return new WaitForSeconds(0.08f);
                s = s + str[i][let].ToString();
                mensaje.text = s;
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
                {
                    mensaje.text = str[i];
                    yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                    break;
                }
            }
            s = "";
        }
        jugador.GetComponent<Movimiento>().enabled = true;

    }

    void nombreEscena(int i)
    {
        switch (i)
        {
            case 1:
                jugador.GetComponent<DatosJugador>().setNombreLvL("Habitación");
                break;
            case 2:
                jugador.GetComponent<DatosJugador>().setNombreLvL("Bosque inicial");
                break;
            case 3:
                jugador.GetComponent<DatosJugador>().setNombreLvL("Montañas");
                break;
            default:
                jugador.GetComponent<DatosJugador>().setNombreLvL("Habitación");
                s = "";
                errorBool = true;
                break;
        }
    }

    void Update()
    {
        if (objeto.GetComponent<Datos>().getCamaR() && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) && camaR)
        {
            print("Cama Return");
            camaR = false; 
            Opciones[0].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getCamaR())
                {
                    objeto.GetComponent<Datos>().DesactivarTags();
                    CambiarEscena("Habitación");
                    Opciones[0].onClick.RemoveAllListeners();
                }

            });
            Opciones[1].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getCamaR())
                {
                    objeto.GetComponent<Datos>().DesactivarTags();
                    Cerrar(CerrarCama);
                    Opciones[1].onClick.RemoveAllListeners();
                }
                  
            });
        }
        else if (objeto.GetComponent<Datos>().getCama() && jugador.GetComponent<DatosJugador>().GetNombreLvL() == "" && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) && camasinG)
        {
            print("Cama sin guardado");
            camasinG = false;

            Opciones[0].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getCama())
                {
                    print("se mimió");
                    objeto.GetComponent<Datos>().DesactivarTags();
                    CambiarEscena(SceneManager.GetActiveScene().buildIndex + 1);
                    Opciones[0].onClick.RemoveAllListeners();
                }
            });

            Opciones[1].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getCama())
                {
                    print("No se mimió");
                    objeto.GetComponent<Datos>().DesactivarTags();
                    Cerrar(CerrarCama);
                    Opciones[1].onClick.RemoveAllListeners();
                }
            });
        }
        else if (objeto.GetComponent<Datos>().getCama() && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) && camaG)
        {
            print("Cama con guardado");
            camaG = false;

            Opciones[0].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getCama())
                {
                    print("Se mimió");
                    objeto.GetComponent<Datos>().DesactivarTags();
                    CambiarEscena(jugador.GetComponent<DatosJugador>().GetNombreLvL());
                    Opciones[0].onClick.RemoveAllListeners();
                }

            });

            Opciones[1].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getCama())
                {
                    print("No se mimió");
                    objeto.GetComponent<Datos>().DesactivarTags();
                    Cerrar(CerrarCama);
                    Opciones[1].onClick.RemoveAllListeners();
                }
                   
            });
            
        }
        else if (objeto.GetComponent<Datos>().getCofre() && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) && Cofre)
        {
            print("Cofre");
            Cofre = false;

            Opciones[1].onClick.AddListener(delegate
            {
                if (objeto.GetComponent<Datos>().getCofre())
                {
                    print("Se cerró");
                    objeto.GetComponent<Datos>().DesactivarTags();
                    Cerrar(CerrarCofre);
                }
            });

            Opciones[0].onClick.AddListener(delegate
            {
                if (objeto.GetComponent<Datos>().getCofre())
                {
                    print("Se abrió el cofre");
                    objeto.GetComponent<Datos>().setPosicion(jugador.GetComponent<Transform>().position);
                    jugador.GetComponent<DatosJugador>().setNombreLvLP(Nombre(SceneManager.GetActiveScene().buildIndex));
                    CambiarEscena("Cofre");
                    objeto.GetComponent<Datos>().DesactivarTags();
                }
            });
        }
        else if (objeto.GetComponent<Datos>().getOso() && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) && OsoG)
        {
            print("Guardado Oso");
            OsoG = false;

            Opciones[0].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getOso())
                {
                    print("Se guardó");
                    Guardar(Guardado, SceneManager.GetActiveScene().buildIndex);
                    objeto.GetComponent<Datos>().DesactivarTags();
                }
            });

            Opciones[1].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getOso())
                {
                    print("Se cerró");
                    Cerrar(CerrarOso);
                    objeto.GetComponent<Datos>().DesactivarTags();
                    Opciones[1].onClick.RemoveAllListeners();
                }

            });
        }

        else if (objeto.GetComponent<Datos>().getNE() && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) && NuevaE)
        {
            NuevaE = false;
            print("Nueva Escena");

            Opciones[0].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getNE())
                {
                    print("se cambió de escena");
                    CambiarEscena(SceneManager.GetActiveScene().buildIndex + 1);
                    objeto.GetComponent<Datos>().DesactivarTags();
                }

            });

            Opciones[1].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getNE())
                {
                    print("Se cerró");
                    Cerrar(CerrarCama);
                    objeto.GetComponent<Datos>().DesactivarTags();
                }

            });
        }

        else if (objeto.GetComponent<Datos>().getAE() && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) && AnteriorE)
        {
            AnteriorE = false;
            print("Nueva Escena");

            Opciones[0].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getAE())
                {
                    print("se cambió de escena");
                    objeto.GetComponent<Datos>().setPosicion(new Vector3(-10, 34.57f, 0));
                    CambiarEscena(SceneManager.GetActiveScene().buildIndex - 1);
                    objeto.GetComponent<Datos>().DesactivarTags();
                }

            });

            Opciones[1].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getAE())
                {
                    print("Se cerró");
                    Cerrar(CerrarCama);
                    objeto.GetComponent<Datos>().DesactivarTags();
                }

            });
        }
        else if (objeto.GetComponent<Datos>().getTienda() && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) && Tienda)
        {
            Tienda = false;

            Opciones[0].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getTienda())
                {
                    print("se cambió de escena");
                    jugador.GetComponent<DatosJugador>().setNombreLvLP(Nombre(SceneManager.GetActiveScene().buildIndex));
                    objeto.GetComponent<Datos>().setPosicion(jugador.GetComponent<Transform>().position);
                    CambiarEscena("Tienda");
                    objeto.GetComponent<Datos>().DesactivarTags();
                }

            });

            Opciones[1].onClick.AddListener(delegate {
                if (objeto.GetComponent<Datos>().getTienda())
                {
                    print("Se cerró");
                    Cerrar(CerrarTienda);
                    objeto.GetComponent<Datos>().DesactivarTags();
                }

            });
        }
    }


    //Funciones de los botones

    void CambiarEscena(String nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    void CambiarEscena(int index)
    {
        SceneManager.LoadScene(index);
    }

    void Cerrar(string[] oraciones)
    {
        StopAllCoroutines();
        StartCoroutine(Escribir(oraciones));

        s = "";

        for(int i=0; i<Opciones.Length; i++)
        {
            Opciones[i].interactable = false;
            Opciones[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

    }

    void Guardar(string[] oraciones, int indx)
    {
        nombreEscena(indx);
        if (errorBool)
        {
            StopAllCoroutines();
            StartCoroutine(Escribir(error));
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(EscribirGuardado(oraciones));
            s = "";
        }
        jugador.GetComponent<DatosJugador>().SetVidaBG(jugador.GetComponent<DatosJugador>().GetVida());
        objeto.GetComponent<Datos>().PosicionGuardado();

        int expG = jugador.GetComponent<DatosJugador>().GetEXP();
        int nivelG = jugador.GetComponent<DatosJugador>().GetNivel();
        int DEFG = jugador.GetComponent<DatosJugador>().GetDEF();
        int DañoG = jugador.GetComponent<DatosJugador>().GetDaño();
        int vidaM = jugador.GetComponent<DatosJugador>().GetVidaB();
        int DineroG = jugador.GetComponent<DatosJugador>().GetDinero();

        Items armadura = jugador.GetComponent<DatosJugador>().getArmadura();
        Items ataque = jugador.GetComponent<DatosJugador>().getAtaque();

        jugador.GetComponent<DatosJugador>().setValoresG(expG, nivelG, armadura, ataque, DañoG, DEFG, vidaM, DineroG);

        for (int i = 0; i < Opciones.Length; i++)
        {
            Opciones[i].interactable = false;
            Opciones[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

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
/**/