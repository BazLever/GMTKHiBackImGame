using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float fireRate;
    public float shotgunForce;
    float fireTime;

    public float blunderFireRate;
    public float modernFireRate;
    public float smgFireRate;

    public float blunderForce;
    public float modernForce;
    public float smgForce;

    public Rigidbody playerBody;


    public GameObject blunderbussGun;
    public GameObject modernGun;
    public GameObject subMGun;

    //Gameobject for the projectile fired by the guns
    public GameObject projectile;

    //Hardpoint for the projectile spawn point
    public Transform weaponHardPoint;

    public int projectileSpeed;

    public bool isBlunder;
    public bool isModern;
    public bool isSMG;

    //UI Elements
    private GameObject shotTimer;
    private GameObject shotBackground;

    void Start()
    {

        shotTimer = GameObject.Find("TimeLeft");
        shotBackground = GameObject.Find("Background");

        isBlunder = true;
        isModern = false;
    }


    void Update()
    {

        fireTime += Time.deltaTime;
        if (fireTime >= fireRate)
        {
            shoot();
            fireTime -= fireRate;
        }

        



        //Weapon Swap 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isBlunder = true;
            isModern = false;
            isSMG = false;

            blunderbussGun.SetActive(true);
            modernGun.SetActive(false);
            subMGun.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isBlunder = false;
            isModern = true;
            isSMG = false;

            blunderbussGun.SetActive(false);
            modernGun.SetActive(true);
            subMGun.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isBlunder = false;
            isModern = false;
            isSMG = true;

            blunderbussGun.SetActive(false);
            modernGun.SetActive(false);
            subMGun.SetActive(true);
        }






        //Weapons
        if (isBlunder == true)
        {
            fireRate = blunderFireRate;
            shotgunForce = blunderForce;
        }

        if (isModern == true)
        {
            fireRate = modernFireRate;
            shotgunForce = modernForce;
        }

        if (isSMG == true)
        {
            fireRate = smgFireRate;
            shotgunForce = smgForce;
        }


        shotTimer.GetComponent<RectTransform>().localScale = new Vector3(fireTime, 0.14f, 0);
        shotBackground.GetComponent<RectTransform>().localScale = new Vector3(fireRate, 0.14f, 0);

    }



     void shoot()
    {
        float soundRange;
        soundRange = Random.Range(0.8f, 1);

        GameObject GO = Instantiate(projectile, weaponHardPoint.position, Quaternion.identity) as GameObject;
        GO.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * projectileSpeed, ForceMode.Impulse);

        if (!isSMG)
        {
            playerBody.velocity = new Vector3(0, 0, 0);
        }
        
        

        playerBody.AddForce(transform.forward * -shotgunForce);

        gameObject.GetComponent<AudioSource>().pitch = soundRange;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
