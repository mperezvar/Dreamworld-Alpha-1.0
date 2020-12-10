using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pres : MonoBehaviour
{
    public int obje;
    private int acum;
    // Start is called before the first frame update
    void Start()
    {
        acum=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag=="copia" && acum<obje){
            acum++;
        }
        else if(gameObject.tag=="copia" && acum>=obje){
            Destroy(gameObject);
        }
    }
}
