using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceUI : MonoBehaviour
{
    public static InterfaceUI instancia;
    public bool ativarTempo, fade, contarPontos;
    public Image tempo, fadeInOut, teste;
    public Text pontos;
    public long somadorDePontos;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        tempo.fillAmount = 1;
    }

    private void FixedUpdate()
    {
        Tempo();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            contarPontos = true;
        }
    }

    public void Tempo()
    {
        if (ativarTempo)
        {
            tempo.fillAmount -= Time.fixedDeltaTime * 0.7f * Time.fixedDeltaTime;
            if (tempo.fillAmount > 0.6f)
            {
                tempo.color = Color.Lerp(tempo.color, Color.blue, 0.08f);

                if (contarPontos)
                {
                    somadorDePontos += 100;
                    pontos.text = somadorDePontos.ToString();
                    contarPontos = false;
                }
            }
            else if (tempo.fillAmount > 0.3f && tempo.fillAmount <= 0.6f)
            {
                tempo.color = Color.Lerp(tempo.color, Color.yellow, 0.08f);

                if (contarPontos)
                {
                    somadorDePontos += 50;
                    pontos.text = somadorDePontos.ToString();
                    contarPontos = false;
                }
            }
            else if (tempo.fillAmount < 0.3f)
            {
                tempo.color = Color.Lerp(tempo.color, Color.red, 0.08f);

                if (contarPontos)
                {
                    somadorDePontos += 30;
                    pontos.text = somadorDePontos.ToString();
                    contarPontos = false;
                }
            }
        } else {
            tempo.color = Color.blue;
            tempo.fillAmount = 1;
        }

        if (tempo.fillAmount == 0) {
            Credito.Score = somadorDePontos.ToString();
            SceneManager.LoadScene(2);
        }
    }
}
