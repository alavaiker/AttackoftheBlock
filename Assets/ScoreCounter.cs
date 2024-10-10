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

    private void Start() {
        score = 0;
        scoreBar = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        score = (int)Time.time * 10;
        Debug.Log(score);
        scoreBar.SetText(score.ToString());
    }
}
