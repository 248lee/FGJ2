using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    List<string> targetTag = new List<string>(){"Enemy", "Player"};
    public bool isEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEnemy)
        {
            if (other.gameObject.CompareTag(targetTag[0]))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
        else
        {
            if (other.gameObject.CompareTag(targetTag[1]))
            {
                Destroy(gameObject);
                other.gameObject.GetComponent<PlayerController>().DropHP(1);
            }
        }
    }
}
