using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roln : MonoBehaviour
{
    private int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
         
        if (collision.gameObject.tag == "Enemy" && x == 0)
        {
            x = 1;
            Transform enemy = collision.gameObject.GetComponent<Transform>();
            enemy.position = enemy.position + transform.up;
            EnemyAi e = enemy.GetComponent<EnemyAi>();
            e.Damage(25);

        }
    }
}
