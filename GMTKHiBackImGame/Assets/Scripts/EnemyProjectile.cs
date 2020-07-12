using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerController>().Death();
        }
    }
}
