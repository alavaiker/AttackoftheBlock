using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreBar;
    public int score;

    // Controla la puntuacion de la partida sumando 10 puntos por segundo

    private void Start() {
        score = 0;
        scoreBar = GetComponent<TMPro.TextMeshProUGUI>();
        InvokeRepeating(nameof(UpdateCounter), 1, 1);
    }

    void UpdateCounter()
    {
        score += 10;
        scoreBar.text = score.ToString();
    }
}
