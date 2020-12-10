using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        target.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
            otro.transform.position = target.transform.GetChild(0).transform.position;
    }

}
