using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public bool ativarTempo, fade, contarPontos;
    public Image tempo, fadeInOut;
    public Text pontos;
    public long somadorDePontos;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Tempo();
        FadeInOut();
        
    }

    public void Tempo()
    {
        if (ativarTempo)
        {
            tempo.fillAmount -= Time.fixedDeltaTime * 0.05f;

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
        }
        else
        {
            tempo.color = Color.blue;
            tempo.fillAmount = 1;
        }
    }

    public void FadeInOut()
    {
        if (fade)
        {
            fadeInOut.color = Color.Lerp(fadeInOut.color, new Color(1, 1, 1, 0), 0.05f);
        }
    }

}
