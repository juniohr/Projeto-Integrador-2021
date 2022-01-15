using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public float timer;
    public GameObject text;

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 0.5) {
            text.SetActive(true); ;
        }

        if (timer >= 1) {
            text.SetActive(false);
            timer = 0;
        }
    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}

