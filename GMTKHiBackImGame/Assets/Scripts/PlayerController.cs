using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int fireRate;
    public int shotgunForce;
    float fireTime;
    bool hasFired;



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
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -shotgunForce);
    }
}
