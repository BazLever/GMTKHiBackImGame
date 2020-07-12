using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{

    public int robotsRemaining;
    public int nextScene;

    //Material stored to swap to when all the enemies are defeated
    public Material levelEndActive;

    void Update()
    {
        if (robotsRemaining == 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = levelEndActive;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EndOfLevel();
        }
    }

    public void EndOfLevel()
    {
        if (robotsRemaining == 0)
        {
            int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextBuildIndex);
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("Go Back and Destory all the robots!");
        }
    }
}
