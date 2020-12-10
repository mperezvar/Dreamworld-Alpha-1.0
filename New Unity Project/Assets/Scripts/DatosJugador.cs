using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DatosJugador : MonoBehaviour
{
    static private int vida = 20;
    static private int vidabase = 20;
    static private int vidaMaxG = 20;
    static private int vidabaseG = 20;
    static private int nivel = 1, nivelG = 1;
    static private int EXP = 0;
    static private int Dinero = 0;
    static private int DineroG = 0;

    private int EXPmax, Precio;
    static private int EXPBaseG = 0;

    static private int DEF = 2;
    static private int daño = 5;

    static private int DEFG=2, DañoG=5;

    static private string nombreNivel = "";
    static private string nombreNivelPausa = "";

    static private Items Armadura, Ataque;

    static private Items ArmaduraG=null, AtaqueG=null;

    static private Items[] objetos= new Items[9];

    public bool pobre;

    void Start()
    {
        EXPmax = nivel*10;
        if (EXP >= EXPmax)
        {
            nivel += 1;
            vida += 3;
            vidabase += 3;
            DEF += 1;
            daño += 1;
            EXP = 0;
        }
    }
    //Getters
    public int GetVida()
    {
        return vida;
    }
    public int GetNivel()
    {
        return nivel;
    }
    public int GetEXP()
    {
        return EXP;
    }
    public int GetDEF()
    {
        return DEF;
    }
    public int GetDaño()
    {
        return daño;
    }
    public string GetNombreLvL()
    {
        return nombreNivel;
    }
    public string GetNombreLvLP()
    {
        return nombreNivelPausa;
    }
    public int GetVidaB()
    {
        return vidabase;
    }
    public int GetVidaBG()
    {
        return vidabaseG;
    }
    public Items getArmadura()
    {
        return Armadura;
    }
    public Items getAtaque()
    {
        return Ataque;
    }
    public int getEXPG()
    {
        return EXPBaseG;
    }
    public int getNivelG()
    {
        return nivelG;
    }
    public int GetDEFG()
    {
        return DEFG;
    }
    public int GetDañoG()
    {
        return DañoG;
    }
    public Items getArmaduraG()
    {
        return ArmaduraG;
    }
    public Items getAtaqueG()
    {
        return AtaqueG;
    }
    public int GetVidaMaxG()
    {
        return vidaMaxG;
    }
    public int GetDinero()
    {
        return Dinero;
    }
    public int GetDineroG()
    {
        return DineroG;
    }
    public int GetPrecio()
    {
        return Precio;
    }


    //Setters
    public void SetVida(int v)
    {
        vida = v;
    }
    public void SetNivel(int n)
    {
        nivel= n;
    }
    public void SetEXP(int exp)
    {
        EXP= exp;
    }
    public void SetDEF(int def)
    {
        DEF= def;
    }
    public void SetDaño(int dmg)
    {
        daño = dmg;
    }
    public void setNombreLvL(string nombre)
    {
        nombreNivel = nombre;
    }
    public void setNombreLvLP(string nombre)
    {
        nombreNivelPausa = nombre;
    }
    public void SetVidaBG(int vid)
    {
        vidabaseG = vid;
    }
    public void setAtaque(Items at)
    {
        Ataque = at;
    }
    public void setArmadura(Items arm)
    {
        Armadura = arm;
    }
    public void setValoresG(int expg, int nivelg, Items arm, Items atk, int dañon, int defn, int vidam, int d)
    {
        EXPBaseG = expg;
        nivelG = nivelg;
        ArmaduraG = arm;
        AtaqueG = atk;
        DEFG = defn;
        DañoG = dañon;
        vidaMaxG = vidam;
        DineroG = d;
    }
    public void SetVidaB(int v)
    {
        vidabase = v;
    }
    public void SetDinero(int d)
    {
        Dinero = d;
    }
   

    //Métodos
    public void TP(Vector3 posicion)
    {
        GetComponent<Transform>().position = posicion;
    }

    public void Añadir(string s)
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            if (objetos[i] == null && Dinero>= GameObject.Find(s).GetComponent<Inventario>().getPrecio())
            {
                string nombre = GameObject.Find(s).GetComponent<Inventario>().getNombre();
                string tipo = GameObject.Find(s).GetComponent<Inventario>().getTipo();
                int mod = GameObject.Find(s).GetComponent<Inventario>().getModificador();
                objetos[i] = new Items(nombre, tipo, mod);
                Dinero = Dinero - GameObject.Find(s).GetComponent<Inventario>().getPrecio();
                
                break;
            }
        }
        
    }
    public void Añadir(Items obj)
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            if (objetos[i] == null)
            {
                string nombre = obj.getNombre();
                string tipo = obj.getTipo();
                int mod = obj.getModificador();
                objetos[i] = new Items(nombre, tipo, mod);
                break;
            }
        }

    }

    public void Destruir(int i)
    {
        if (objetos[i] != null)
            objetos[i]= null;
    }

    public string Prueba(int i)
    {
        if (objetos[i] != null)
            return objetos[i].toString();
        else
            return "Vacío";
    }

    public Items Obtener(int i)
    {
        return objetos[i];
    }

    public bool Lleno()
    {
        for(int i=0; i<objetos.Length; i++)
        {
            if (objetos[i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void Verificar(string s)
    {
        if (GameObject.Find(s).GetComponent<Inventario>().getPrecio()> Dinero)
        {
            pobre = true;
        }
        else
        {
            pobre = false;
        }
    }
}
public class Items
{
    private static GameObject jugador;
    private int modificador;
    private string tipo, nombre;
    public Items(string nom, string t, int mod)
    {
        nombre = nom;
        tipo = t;
        modificador = mod;
    }
    public string getTipo()
    {
        return tipo;
    }
    public int getModificador()
    {
        return modificador;
    }
    public string getNombre()
    {
        return nombre;
    }
    public string toString()
    {
        return nombre;
    }
}
