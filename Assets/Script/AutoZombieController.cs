using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoZombieController : MonoBehaviour
{
    public GameObject autoZombiePref;
    public float auto;
    public float tiempEnemigos = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        auto += Time.deltaTime;
        if (auto >= tiempEnemigos)
        {
            auto = 0;
            if (autoZombiePref != null)
            {
                Instantiate(autoZombiePref, transform.position, Quaternion.identity);
            }
        }
    }
}
