using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill8_Float : Skill
{
    public float floatingHeight = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void CastSkill()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = transform.position + new Vector3(0f, floatingHeight, 0f);
    }
    public override void ClearSkill()
    {
        GetComponent<Rigidbody>().useGravity = true;
        StartCoroutine(FallDown());
    }
    IEnumerator FallDown()
    {
        for (int i = 0; i < 90; i++)
        {
            transform.position += new Vector3(0f, -10f, 0f) * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        GetComponent<PlayerController>().DropHP(2);
    }
}
