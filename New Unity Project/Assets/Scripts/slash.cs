using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    public GameObject perso;
    public float dura;
    private int acum;
    private float lim;
    private GameObject enemigo;
    // Start is called before the first frame update
    void Start()
    {
        enemigo = GameObject.Find("enemi");
        lim=dura*60;
        if(gameObject.tag=="sla_temp"){
            gameObject.transform.position=enemigo.GetComponent<Transform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag=="sla_temp"){
            acum++;
            if(acum>lim){
                perso.GetComponent<personaje>().devu=true;
                Destroy(gameObject);
            } 
        }
    }
}
