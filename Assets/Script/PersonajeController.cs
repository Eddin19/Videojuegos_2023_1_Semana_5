using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    //public FootController footController;
    public GameObject balaPref;
    public bool direccionBala = true;
    Rigidbody2D rb;
    Animator animator;
    private int currentAnimation = 1;
    SpriteRenderer sr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        currentAnimation = 1;
        var velocityY = rb.velocity.y;
        rb.velocity = new Vector2(0, velocityY);
        //derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(12, velocityY);
            sr.flipX = false;
            direccionBala = true;

        }
        //correr
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(20, velocityY);
            sr.flipX = false;

        }
        //izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(-12, velocityY);
            sr.flipX = true;
            direccionBala = false;

        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        {
            currentAnimation = 2;
            rb.velocity = new Vector2(-20, velocityY);
            sr.flipX = true;

        }
        //deslizar
        if (Input.GetKey(KeyCode.D))
        {

            bool verificar = sr.flipX;
            if (verificar == true && Input.GetKey(KeyCode.D))
            {
                currentAnimation = 4;
                rb.velocity = new Vector2(-5, velocityY);
            }
            if (verificar == false && Input.GetKey(KeyCode.D))
            {
                currentAnimation = 4;
                rb.velocity = new Vector2(5, velocityY);
            }
        }
        //ataque
        if (Input.GetKey(KeyCode.B))
        {
            currentAnimation = 5;
            rb.velocity = new Vector2(0, velocityY);

        }
        //TIRAR
        if (Input.GetKey(KeyCode.T))
        {
            currentAnimation = 3;
            rb.velocity = new Vector2(0, velocityY);
        }
        //muerte
        if (Input.GetKey(KeyCode.M))
        {
            currentAnimation = 6;
            rb.velocity = new Vector2(0, velocityY);
        }
        //Disparar
        if (Input.GetKeyUp(KeyCode.F))
        {
            //Instantiate(balaPref, transform.position, Quaternion.identity);
            var position = new Vector3(transform.position.x, transform.position.y, 10);
            var balaGO = Instantiate(balaPref, position, Quaternion.identity);
            var controller = balaGO.GetComponent<BalaController>();
            

            if(direccionBala == true)
            {
                controller.balaSpeed = 20f;
            }
            else
            {
                controller.balaSpeed = -20f;
            }
        }
        
        animator.SetInteger("Estado", currentAnimation);
    }
}
