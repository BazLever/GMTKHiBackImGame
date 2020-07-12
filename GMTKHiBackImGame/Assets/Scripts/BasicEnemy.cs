using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Kill()
    {
        GameObject levelEnd;
        levelEnd = GameObject.Find("LevelEnd");
        levelEnd.GetComponent<LevelEnd>().robotsRemaining -= 1;
        Destroy(gameObject);
    }
}
