using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialise : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(0);
    }
}
