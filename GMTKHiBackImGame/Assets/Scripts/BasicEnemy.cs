using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemy : MonoBehaviour
{

    public GameObject scream;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Kill()
    {
        GameObject GO = Instantiate(scream, gameObject.transform.position, Quaternion.identity) as GameObject;
        GameObject levelEnd;
        levelEnd = GameObject.Find("LevelEnd");
        levelEnd.GetComponent<LevelEnd>().robotsRemaining -= 1;
        Destroy(gameObject);
    }
}
