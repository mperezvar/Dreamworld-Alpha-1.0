using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject enemigo;
    public float tiem;
    private float fin;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag=="explo_temp"){
            transform.position=enemigo.GetComponent<Transform>().position;
            enemigo.GetComponent<EnemigoB>().expl=true;
        }
        fin=Time.time+tiem;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>fin && gameObject.tag=="explo_temp"){
            Destroy(gameObject);
        }
    }
}
