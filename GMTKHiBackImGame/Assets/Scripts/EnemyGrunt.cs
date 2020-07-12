using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt : MonoBehaviour
{

    GameObject player;

    public float fireRate;
    public GameObject projectile;

    public float projectileSpeed;

    public Transform projectileSpawn;

    float fireDelta;

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {
        fireDelta += Time.deltaTime;

        transform.LookAt(player.transform);


        RaycastHit hit;

        float distanceOfRay = 200;

        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, distanceOfRay))
        {
            if (hit.transform.name == "Player")
            {
                ShootAtPlayer();
            }
        }


    }



    void ShootAtPlayer()
    {
        float soundRange;
        soundRange = Random.Range(0.8f, 1.0f);
        fireRate = Random.Range(2, 5);

        if (fireDelta >= fireRate)
        {
            GameObject GO = Instantiate(projectile, projectileSpawn.position, Quaternion.identity) as GameObject;
            GO.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * projectileSpeed, ForceMode.Impulse);
            fireDelta = 0;

            gameObject.GetComponent<AudioSource>().pitch = soundRange;
            gameObject.GetComponent<AudioSource>().Play();
        }

        
    }

}
