using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segui : MonoBehaviour
{
    public GameObject selec;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(selec.transform.position.x,selec.transform.position.y,-1.12f);
    }
}
