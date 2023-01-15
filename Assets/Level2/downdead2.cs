using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class downdead2 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 18 || transform.position.y < -19)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Level2");
    }
}