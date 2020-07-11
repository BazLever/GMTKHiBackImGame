using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int fireRate;
    public int shotgunForce;
    float fireTime;
    bool hasFired;
    public Rigidbody playerBody;


    void Start()
    {
        hasFired = false;
    }


    void Update()
    {

        fireTime += Time.deltaTime;
        if (fireTime >= fireRate)
        {
            shoot();
            fireTime -= fireRate;
        }



    }



     void shoot()
    {
        playerBody.velocity = new Vector3(0,0,0);
        playerBody.AddForce(transform.forward * -shotgunForce);
    }
}
