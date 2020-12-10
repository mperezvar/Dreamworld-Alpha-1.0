using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesInve : MonoBehaviour
{
    private GameObject posicion;
    // Start is called before the first frame update
    public void salir()
    {
        if (posicion.GetComponent<Datos>().getPausa())
        {
            SceneManager.LoadScene("Pausa");
        }
        else
        {
            SceneManager.LoadScene("Batalla");
        }

    }

    // Update is called once per frame
    void Start()
    {
        posicion = GameObject.Find("Posicion");
    }
}
