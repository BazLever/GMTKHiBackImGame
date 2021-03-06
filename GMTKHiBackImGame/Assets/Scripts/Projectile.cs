﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = transform.forward * moveSpeed * Time.deltaTime;
    }


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.gameObject.GetComponent<BasicEnemy>().Kill();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Projectile has hit another object, destroying projectile.");
            Destroy(gameObject);
        }
    }
}
