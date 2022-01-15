using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credito : MonoBehaviour
{
    public Text FinalScore;
    public static string Score;
    void Update()
    {
        FinalScore.text = Score + " Pontos";
        StartCoroutine(WaitCredits());
    }

    IEnumerator WaitCredits()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}
