using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");

        if (other.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("Hitttt");
            Destroy(gameObject);

        }

    }

    void OnTriggerStay(Collider other)
    {

        Debug.Log("Stay");

        if (other.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("Hitttt");
            Destroy(gameObject);

        }

    }
}
