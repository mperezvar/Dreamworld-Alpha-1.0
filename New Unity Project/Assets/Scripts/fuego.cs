using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuego : MonoBehaviour
{
    public GameObject expl;
    private GameObject explo, personaje, enemigo;
    public float duracion;
    private float aumx,aumy;
    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("personaje");
        enemigo = GameObject.Find("enemi");
        if (gameObject.tag=="fueg_temp"){
            transform.position=personaje.GetComponent<Transform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag=="fueg_temp"){
            if(gameObject.transform.position.x< enemigo.GetComponent<Transform>().position.x && gameObject.transform.position.y < enemigo.GetComponent<Transform>().position.y)
            {
                aumx=16.0f/(duracion*60);
                aumy=1.3f/(duracion*60);
                transform.position+=new Vector3(aumx,aumy,0);
            }
            else{
                explo=Instantiate(expl);
                explo.tag="explo_temp";
                Destroy(gameObject);
            }
        }
    }
}
