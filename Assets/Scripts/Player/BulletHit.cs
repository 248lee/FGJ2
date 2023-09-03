using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    List<string> targetTag = new List<string>(){"Enemy", "Player"};
    public GameObject enemyBombVFX;
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
            if (other.gameObject.transform.root.CompareTag(targetTag[0])) // if players bullet hits enemies
            {
                //Destroy(gameObject);
                GameObject vfx = Instantiate(enemyBombVFX, transform.position, Quaternion.identity);
                gameObject.SetActive(false); // destroy in PlayerController
                GameObject.FindWithTag("Player").GetComponent<Skill6_ReverseDamage>().SetHitEnemySignal();
                Destroy(other.gameObject);
                Destroy(vfx, 4f);
            }
        }
        else
        {
            if (other.gameObject.transform.root.CompareTag(targetTag[1])) // if enemies bullet hits player
            {
                //Destroy(gameObject);
                gameObject.SetActive(false); // destroy in PlayerController
                other.gameObject.transform.root.GetComponent<PlayerController>().DropHP(1);
                other.gameObject.transform.root.GetComponent<Skill7_Absorb>().SetHitPlayerSignal();

                int changingWinCondtion = Random.Range(0, 21);
                if (changingWinCondtion < 1) // 10% to change
                {
                  FindObjectOfType<Bomb>().Bombed();
                }
            }
        }
    }
}
