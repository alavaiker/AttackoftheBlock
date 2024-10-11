using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingController : MonoBehaviour
{
    private TextMeshProUGUI ranking;

    // Crea la lista con las cinco mejores puntuaciones
    void Start()
    {
        ranking = GetComponent<TMPro.TextMeshProUGUI>();

        int punt1 = PlayerPrefs.GetInt("Puntuacion1");
        int punt2 = PlayerPrefs.GetInt("Puntuacion2");
        int punt3 = PlayerPrefs.GetInt("Puntuacion3");
        int punt4 = PlayerPrefs.GetInt("Puntuacion4");
        int punt5 = PlayerPrefs.GetInt("Puntuacion5");

        ranking.text = punt1 + "\n" + punt2 + "\n" + punt3 + "\n" + punt4 + "\n" + punt5;
    }
}
