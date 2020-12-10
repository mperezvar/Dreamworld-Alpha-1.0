using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cofre : MonoBehaviour
{
    public TextMeshProUGUI[] inventario;
    public TextMeshProUGUI[] cofre;
    private GameObject jugador, cuadro;
    private int i=0;
    static private Items[] objCofre = new Items[9];
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Protagonista");
        cuadro = GameObject.Find("Cuadro");
        cuadro.GetComponent<Transform>().position = cofre[i].GetComponent<Transform>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cuadro.GetComponent<Transform>().position == cofre[i].GetComponent<Transform>().position)
        {
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                if (i + 1 >= 0 && i + 1 < 9)
                {
                    i += 1;
                    cuadro.GetComponent<Transform>().position = cofre[i].GetComponent<Transform>().position;
                }

            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                if (i - 1 >= 0 && i - 1 < 9)
                {
                    i -= 1;
                    cuadro.GetComponent<Transform>().position = cofre[i].GetComponent<Transform>().position;
                }

            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                i = 0;
                cuadro.GetComponent<Transform>().position = inventario[i].GetComponent<Transform>().position;
            }
            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
            {
                if (objCofre[i] != null)
                {
                    jugador.GetComponent<DatosJugador>().Añadir(objCofre[i]);
                    DestruirObj(i);
                }
            }
        }
        else if(cuadro.GetComponent<Transform>().position == inventario[i].GetComponent<Transform>().position)
        {
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                if (i + 1 >= 0 && i + 1 < 9)
                {
                    i += 1;
                    cuadro.GetComponent<Transform>().position = inventario[i].GetComponent<Transform>().position;
                }

            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                if (i - 1 >= 0 && i - 1 < 9)
                {
                    i -= 1;
                    cuadro.GetComponent<Transform>().position = inventario[i].GetComponent<Transform>().position;
                }

            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                i = 0;
                cuadro.GetComponent<Transform>().position = cofre[i].GetComponent<Transform>().position;
            }
            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
            {
                if (jugador.GetComponent<DatosJugador>().Obtener(i) != null)
                {
                    AgregarObj(jugador.GetComponent<DatosJugador>().Obtener(i));
                    jugador.GetComponent<DatosJugador>().Destruir(i);
                }
            }
        }
        // Cambia los strings y así se ve el intercambio de objetos
        for (int i = 0; i < objCofre.Length; i++)
        {
            if (objCofre[i] != null)
            {
                cofre[i].text = objCofre[i].toString();
            }
            else
            {
                cofre[i].text = "Vacío";
            }
        }
        for (int i = 0; i < objCofre.Length; i++)
        {
            if (jugador.GetComponent<DatosJugador>().Obtener(i) != null)
            {
                inventario[i].text = jugador.GetComponent<DatosJugador>().Obtener(i).toString();
            }
            else
            {
                inventario[i].text = "Vacío";
            }
        }
    }
    void AgregarObj(Items obj)
    {
        for(int i=0; i<objCofre.Length; i++)
        {
            if (objCofre[i] == null)
            {
                cofre[i].text = obj.toString();
                objCofre[i] = obj;
                break;
            }
        }
    }
    void DestruirObj(int i)
    {
        objCofre[i] = null;
    }
}
