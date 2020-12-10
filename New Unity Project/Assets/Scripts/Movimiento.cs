using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Animacion
{
    private Animator caminar;
    private bool mov;

    public Animacion(Animator a)
    {
        caminar = a;
    }
    public void Normal(float x, float y)
    {
        switch (y)
        {
            case 1.0f:
                caminar.SetFloat("MovY", 2.0f);
                break;
            case -1.0f:
                caminar.SetFloat("MovY", -2.0f);
                break;
            case 0.0f:
                caminar.SetFloat("MovY", 0.0f);
                break;
            default:
                caminar.SetFloat("MovY", 0.0f);
                break;
        }
        switch (x)
        {
            case 1.0f:
                caminar.SetFloat("MovX", 2.0f);
                break;
            case -1.0f:
                caminar.SetFloat("MovX", -2.0f);
                break;
            case 0.0f:
                caminar.SetFloat("MovX", 0.0f);
                break;
            default:
                caminar.SetFloat("MovX", 0.0f);
                break;
        }
    }
    public void Pasto(float x, float y)
    {
        caminar.SetLayerWeight(1, 1);
        if (x != 0.0 || y != 0.0)
            caminar.SetBool("mov", true);
        else
            caminar.SetBool("mov", false);
    }
    public void Agua(float x, float y)
    {
        switch (y)
        {
            case 1.0f:
                caminar.SetFloat("MovY", 2.0f);
                break;
            case -1.0f:
                caminar.SetFloat("MovY", -2.0f);
                break;
            case 0.0f:
                caminar.SetFloat("MovY", 0.0f);
                break;
            default:
                caminar.SetFloat("MovY", 0.0f);
                break;
        }
        switch (x)
        {
            case 1.0f:
                caminar.SetFloat("MovX", 2.0f);
                break;
            case -1.0f:
                caminar.SetFloat("MovX", -2.0f);
                break;
            case 0.0f:
                caminar.SetFloat("MovX", 0.0f);
                break;
            default:
                caminar.SetFloat("MovX", 0.0f);
                break;
        }
    }
}
public class Movimiento : MonoBehaviour
{
    public float velocidad;
    public Animator animator;
    Rigidbody2D rb;
    Vector2 movimiento;
    private Animacion animMov;
    private bool pasto= false;
    private bool agua = false;

    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animMov = new Animacion(animator);
        desactCapas();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        movimiento = new Vector2(
           x,
           y
           );
        rb.MovePosition(rb.position + movimiento * velocidad * Time.deltaTime);
        if (pasto)
        {
            animator.SetLayerWeight(1, 1);
            animMov.Pasto(x, y);
        }
        else if (agua)
        {
            animator.SetLayerWeight(2, 1);
            animMov.Agua(x, y);
        }
        else
        {
            animator.SetLayerWeight(0, 1);
            animMov.Normal(x, y);
        }

    }
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Arbustos"))
        {
            desactCapas();
            pasto = true;
            Debug.Log("Pasto"+ pasto);
        }
        else if (otro.CompareTag("Agua"))
        {
            desactCapas();
            agua = true;
            Debug.Log("Agua" + agua);
        }

    }
    void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Arbustos"))
        {
            desactCapas();
            pasto = false;
        }
        else if (otro.CompareTag("Agua"))
        {
            desactCapas();
            agua = false;
        }


    }
    public void desactCapas()
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
    }


}
