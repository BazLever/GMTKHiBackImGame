using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fireRate;
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
        float soundRange;
        soundRange = Random.Range(0.8f, 1);

        playerBody.velocity = new Vector3(0,0,0);
        playerBody.AddForce(transform.forward * -shotgunForce);

        gameObject.GetComponent<AudioSource>().pitch = soundRange;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
