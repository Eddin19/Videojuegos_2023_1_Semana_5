using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArribaController : MonoBehaviour
{
    public float balaSpeedArriba = 20f;
    public GameObject playerArriba;
    public Transform playerTransArriba;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerArriba = GameObject.FindGameObjectWithTag("PlayerBala");
        playerTransArriba = playerArriba.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransArriba.localScale.x > 0)
        {
            rb.velocity = new Vector2(balaSpeedArriba, 0);
            Destroy(gameObject, 3f);
        }
        else
        {
            rb.velocity = new Vector2(balaSpeedArriba, 0);
            Destroy(gameObject, 3f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Destroy(this.gameObject);
        }
    }
}
