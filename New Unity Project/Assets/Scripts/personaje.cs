using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    public GameObject slash;
    public bool at_fis, devu;
    public float dura;
    private float aumx, aumy;
    private Vector3 temp;
    private GameObject cop_sl, enemigo;
    private bool ya, solo1;
    // Start is called before the first frame update
    void Start()
    {
        devu=false;
        solo1 = true;
        ya=false;
        at_fis=false;
        temp= this.gameObject.GetComponent<Transform>().position;
        enemigo = GameObject.Find("enemi");
    }

    // Update is called once per frame
    void Update()
    {
        if(at_fis==true){
            if(gameObject.transform.position.x<enemigo.GetComponent<Transform>().position.x && gameObject.transform.position.y< enemigo.GetComponent<Transform>().position.y && devu==false){
                aumx=10.0f/(dura*60);
                aumy=1.3f/(dura*60);
                transform.position+=new Vector3(aumx,aumy,0);   
            }
            else if(gameObject.transform.position.x>= enemigo.GetComponent<Transform>().position.x && devu==false || gameObject.transform.position.y>= enemigo.GetComponent<Transform>().position.y && devu==false){
                transform.position=enemigo.GetComponent<Transform>().position;
            }
            if(gameObject.transform.position.x>= enemigo.GetComponent<Transform>().position.x || gameObject.transform.position.y>= enemigo.GetComponent<Transform>().position.y && ya==false){
                ya=true;
                if (solo1)
                {
                    solo1 = false;
                    cop_sl = Instantiate(slash);
                    cop_sl.tag = "sla_temp";
                }
                
            }
            if(devu==true && gameObject.transform.position.x>temp.x){
                transform.position+=new Vector3(-aumx,-aumy,0);
            }
            else if(devu==true && (gameObject.transform.position.x<=temp.x || gameObject.transform.position.y<= temp.y))
            {
                devu=false;
                transform.position = temp;
                ya = false;
                at_fis=false;
            }
        }
        else
        {
            solo1 = true;
        }
    }
}
