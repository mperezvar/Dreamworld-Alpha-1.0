using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public int modificador, precio;
    public string tipo, nombre;

    public string getTipo()
    {
        return tipo;
    }
   
    public string getNombre()
    {
        return nombre;
    }
    public int getModificador()
    {
        return modificador;
    }
    public string toString()
    {
        return nombre;
    }
    public int getPrecio()
    {
        return precio;
    }
}
