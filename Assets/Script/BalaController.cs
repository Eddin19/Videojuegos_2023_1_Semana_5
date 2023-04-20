using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float balaSpeed = 20f;
    public GameObject balaPrefArriba;
    public GameObject player;
    public Transform playerTrans;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrans.localScale.x > 0)
        {
            rb.velocity = new Vector2(balaSpeed, 0);
            Destroy(gameObject, 3f);
        }
        else
        {
            rb.velocity = new Vector2(balaSpeed, 0);
            Destroy(gameObject, 3f);
        }




        if (Input.GetKeyUp(KeyCode.U))
        {
            //Instantiate(balaPref, transform.position, Quaternion.identity);
            var position = new Vector3(transform.position.x, transform.position.y+1, 10);
            var balaGO = Instantiate(balaPrefArriba, position, Quaternion.identity);
            var controller = balaGO.GetComponent<ArribaController>();


            controller.balaSpeedArriba = 20f;
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
