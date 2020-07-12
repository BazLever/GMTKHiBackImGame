using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float fireRate;
    public float shotgunForce;
    float fireTime;

    float blunderFireTime;
    float rifleFireTime;
    float smgFireTime;


    public float blunderFireRate;
    public float modernFireRate;
    public float smgFireRate;

    public float blunderForce;
    public float modernForce;
    public float smgForce;


    float flashTimer = 0.05f;
    float flashDelta;

    public Rigidbody playerBody;


    public GameObject blunderbussGun;
    public GameObject modernGun;
    public GameObject subMGun;

    public GameObject blunderFlash;
    public GameObject rifleFlash;
    public GameObject smgFlash;

    //sound elements
    public AudioSource blunderbusSound;
    public AudioSource rifleSound;
    public AudioSource smgSound;


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

    private GameObject blunderShotTimer;
    private GameObject blunderBackground;

    private GameObject rifleShotTimer;
    private GameObject rifleBackground;

    private GameObject smgShotTimer;
    private GameObject smgBackground;

    bool isDead;


    //Death related
    public GameObject deathCam;


    //Animation related
    public Animator blunderbusAnimation, rifleAnimation, smgAnimation;

    void Start()
    {
        isDead = false;
        shotTimer = GameObject.Find("TimeLeft");
        shotBackground = GameObject.Find("Background");

        blunderShotTimer = GameObject.Find("BTimeLeft");
        blunderBackground = GameObject.Find("BBackground");

        rifleShotTimer = GameObject.Find("RTimeLeft");
        rifleBackground = GameObject.Find("RBackground");

        smgShotTimer = GameObject.Find("STimeLeft");
        smgBackground = GameObject.Find("SBackground");

        isBlunder = true;
        isModern = false;

        blunderbusAnimation.Play("IdleBlunderbus");
        rifleAnimation.Play("IdleRifle");
        smgAnimation.Play("IdleSMG");
    }


    void Update()
    {
        if (!isDead) { 
        flashDelta += Time.deltaTime;
        fireTime += Time.deltaTime;

        blunderFireTime += Time.deltaTime;
        rifleFireTime += Time.deltaTime;
        smgFireTime += Time.deltaTime;

        /*
                fireTime += Time.deltaTime;
                if (fireTime >= fireRate)
                {
                    shoot();
                    fireTime = 0;
                }
                */




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
            //fireRate = blunderFireRate;
            shotgunForce = blunderForce;
            if (Input.GetMouseButton(0))
            {
                if (blunderFireTime >= blunderFireRate)
                {
                    shoot();
                    blunderFireTime = 0;
                } 
            }
            else if (blunderFireTime >= blunderFireRate)
            {
                    blunderbusAnimation.Play("IdleBlunderbus");
                    blunderFireTime = blunderFireRate;
            }
        } else if (!isBlunder)
        {
            if (blunderFireTime >= blunderFireRate)
            {
                blunderFireTime = blunderFireRate;
            }
        }

        if (isModern == true)
        {
            //fireRate = modernFireRate;
            shotgunForce = modernForce;
            if (Input.GetMouseButton(0))
            {
                if (rifleFireTime >= modernFireRate)
                {
                    shoot();
                    rifleFireTime = 0;
                } 
            }
            else if (rifleFireTime >= modernFireRate)
            {
                    rifleAnimation.Play("IdleRifle");
                    rifleFireTime = modernFireRate;
            }
        } else if (!isModern)
        {
            if (rifleFireTime >= modernFireRate)
            {
                rifleFireTime = modernFireRate;
            }
        }

        if (isSMG == true)
        {
            //fireRate = smgFireRate;
            shotgunForce = smgForce;
            if (Input.GetMouseButton(0))
            {
                if (smgFireTime >= smgFireRate)
                {
                    shoot();
                    smgFireTime = 0;
                }
            }
            else if (smgFireTime >= smgFireRate)
            {
                    smgAnimation.Play("IdleSMG");
                    smgFireTime = smgFireRate;
            }
        }
        else if (!isSMG)
        {
            if (smgFireTime >= smgFireRate)
            {
                smgFireTime = smgFireRate;
            }
        }


            blunderShotTimer.GetComponent<RectTransform>().localScale = new Vector3(blunderFireTime, 0.24f, 0);
        blunderBackground.GetComponent<RectTransform>().localScale = new Vector3(blunderFireRate, 0.24f, 0);

        rifleShotTimer.GetComponent<RectTransform>().localScale = new Vector3(rifleFireTime, 0.24f, 0);
        rifleBackground.GetComponent<RectTransform>().localScale = new Vector3(modernFireRate, 0.24f, 0);

        smgShotTimer.GetComponent<RectTransform>().localScale = new Vector3(smgFireTime, 0.24f, 0);
        smgBackground.GetComponent<RectTransform>().localScale = new Vector3(smgFireRate, 0.24f, 0);


        /*
        shotTimer.GetComponent<RectTransform>().localScale = new Vector3(fireTime, 0.14f, 0);
        shotBackground.GetComponent<RectTransform>().localScale = new Vector3(fireRate, 0.14f, 0);
        */


        

        if (flashDelta >= flashTimer)
        {
            blunderFlash.SetActive(false);
            rifleFlash.SetActive(false);
            smgFlash.SetActive(false);
            flashDelta = 0;
        }
        }

    }



     void shoot()
    {
        blunderbusAnimation.Play("ShootingBlunderbus");
        rifleAnimation.Play("ShootingRifle");
        smgAnimation.Play("ShootingSMG");

        blunderFlash.SetActive(true);
        rifleFlash.SetActive(true);
        smgFlash.SetActive(true);

        float soundRange;
        soundRange = Random.Range(0.9f, 1.1f);

        float randomRotation;
        randomRotation = Random.Range(0.0f, 180.0f);

        GameObject GO = Instantiate(projectile, weaponHardPoint.position, Quaternion.identity) as GameObject;
        GO.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * projectileSpeed, ForceMode.Impulse);

        if (!isSMG)
        {
            playerBody.velocity = new Vector3(0, 0, 0);
        }
        
        

        playerBody.AddForce(transform.forward * (-shotgunForce));

        if (isBlunder)
        {
            
            blunderbusSound.pitch = soundRange;
            blunderbusSound.Play();
        } else if (isModern)
        {
                        rifleSound.pitch = soundRange;
            rifleSound.Play();
        } else if (isSMG)
        {
            
            smgSound.pitch = soundRange;
            smgSound.Play();
        }


        blunderFlash.transform.localRotation = Quaternion.Euler(randomRotation, 0, 0);
        rifleFlash.transform.localRotation = Quaternion.Euler(randomRotation, 0, 0);
        smgFlash.transform.localRotation = Quaternion.Euler(randomRotation, 0, 0);

        flashDelta = 0;

        

    }


    public void Death()
    {
        isDead = true;
        gameObject.transform.GetComponent<CameraMovement>().enabled = false;
        Camera.main.transform.gameObject.GetComponent<Camera>().enabled = false;
        GameObject GO = Instantiate(deathCam, weaponHardPoint.position, Quaternion.identity) as GameObject;
    }

}
