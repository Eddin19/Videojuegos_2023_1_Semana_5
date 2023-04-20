using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieController : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float velocity = 0.9f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(-velocity, 0);
        sr.flipX = true;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("*****");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Juego en pausa");
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MuereZombie"))
        {
            Destroy(this.gameObject);
        }
    }
}
