using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TextInventario : MonoBehaviour
{
    public TextMeshProUGUI[] objetos;
    private GameObject jugador, cuadro;
    private int i, moda;
    private Items Objeto;
    private bool flag = true;
    private Items arm, atk;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Protagonista");
        cuadro = GameObject.Find("Cuadro");
        cuadro.GetComponent<Transform>().position = objetos[0].GetComponent<Transform>().position;
        i = 0;
        for(int i=0; i<9; i++)
            objetos[i].text = jugador.GetComponent<DatosJugador>().Prueba(i);
    }

    // Update is called once per frame
    void Update()
    {
        if(cuadro.GetComponent<Transform>().position == objetos[i].GetComponent<Transform>().position)
        {
            if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                if(i+3>=0 && i + 3 < 9)
                {
                    i += 3;
                    cuadro.GetComponent<Transform>().position = objetos[i].GetComponent<Transform>().position;
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                if(i+1>=0 && i + 1 < 9)
                {
                    i += 1;
                    cuadro.GetComponent<Transform>().position = objetos[i].GetComponent<Transform>().position;
                }

            }
            else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                if (i-1 >= 0 && i-1 < 9)
                {
                    i -= 1;
                    cuadro.GetComponent<Transform>().position = objetos[i].GetComponent<Transform>().position;
                }

            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                if (i - 3 >= 0 && i - 3 < 9)
                {
                    i -= 3;
                    cuadro.GetComponent<Transform>().position = objetos[i].GetComponent<Transform>().position;
                }

            }
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return))
        {
            if(jugador.GetComponent<DatosJugador>().Obtener(i)!= null)
            {
                Objeto = jugador.GetComponent<DatosJugador>().Obtener(i);
                print(Objeto.toString());
                switch (Objeto.getTipo())
                {
                    case "Consumible":
                        int vidaN = jugador.GetComponent<DatosJugador>().GetVida() + Objeto.getModificador();
                        objetos[i].text = "Vacío";
                        if (vidaN > jugador.GetComponent<DatosJugador>().GetVidaB())
                        {
                            jugador.GetComponent<DatosJugador>().SetVida(jugador.GetComponent<DatosJugador>().GetVidaB());
                        }
                        else
                        {
                            jugador.GetComponent<DatosJugador>().SetVida(vidaN);
                        }
                        jugador.GetComponent<DatosJugador>().Destruir(i);
                        break;
                    case "EquipableDEF":
                        arm = jugador.GetComponent<DatosJugador>().getArmadura();
                        if (arm !=null)
                        {
                            jugador.GetComponent<DatosJugador>().SetDEF(jugador.GetComponent<DatosJugador>().GetDEF() - arm.getModificador());
                            jugador.GetComponent<DatosJugador>().SetDEF(jugador.GetComponent<DatosJugador>().GetDEF() + Objeto.getModificador());
                            jugador.GetComponent<DatosJugador>().setArmadura(Objeto);
                        }
                        else
                        {
                            jugador.GetComponent<DatosJugador>().SetDEF(jugador.GetComponent<DatosJugador>().GetDEF() + Objeto.getModificador());
                            jugador.GetComponent<DatosJugador>().setArmadura(Objeto);
                        }
                        objetos[i].text = "Vacío";
                        print("Nueva armadura: "+ jugador.GetComponent<DatosJugador>().getArmadura().toString());
                        jugador.GetComponent<DatosJugador>().Destruir(i);
                        break;
                    case "EquipableATK":
                        atk = jugador.GetComponent<DatosJugador>().getAtaque();
                        if (atk != null)
                        {
                            jugador.GetComponent<DatosJugador>().SetDaño(jugador.GetComponent<DatosJugador>().GetDaño() - atk.getModificador());
                            jugador.GetComponent<DatosJugador>().SetDaño(jugador.GetComponent<DatosJugador>().GetDaño() + Objeto.getModificador());
                            jugador.GetComponent<DatosJugador>().setAtaque(Objeto);
                        }
                        else
                        {
                            jugador.GetComponent<DatosJugador>().SetDaño(jugador.GetComponent<DatosJugador>().GetDaño() + Objeto.getModificador());
                            jugador.GetComponent<DatosJugador>().setAtaque(Objeto);
                        }
                        objetos[i].text = "Vacío";
                        print("Nuevo ataque: " + jugador.GetComponent<DatosJugador>().getAtaque().toString());
                        jugador.GetComponent<DatosJugador>().Destruir(i);
                        break;
                    default:
                        print("vacío");
                        break;
                }
            }
            else
            {
                print("vacío");
            }

        }
    }

}

