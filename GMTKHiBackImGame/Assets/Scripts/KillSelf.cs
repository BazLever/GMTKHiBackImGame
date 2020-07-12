using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{

    int death = 3;
    float timer;
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= death)
        {
            Destroy(gameObject);
        }

    }
}
