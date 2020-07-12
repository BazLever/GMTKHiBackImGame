using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    GameObject player;

    private void Start()
    {


        player = GameObject.Find("Main Camera");


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            player.GetComponent<PlayerController>().Death();
            Destroy(gameObject);
        }
        if (collision.collider.name == "RobotEnemy")
        {
            return;
        }
        if (collision.collider.tag == "Geo")
        {
            Destroy(gameObject);
        }


    }
}
