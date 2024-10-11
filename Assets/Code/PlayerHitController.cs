using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Color = UnityEngine.Color;
using TMPro;

public class PlayerHitController : MonoBehaviour
{
    [SerializeField]private string gameOver;
    [SerializeField]public int totalLives;
    [SerializeField]private float iframeSecs;
    [SerializeField]private float parrySecs;
    [SerializeField]private float parryCd;
    private bool invulnerable;
    [SerializeField]private Sprite playerHitSprite;
    [SerializeField]private Sprite playerParrySprite;
    private SpriteRenderer SR;
    [SerializeField] RawImage[] lives;
    private bool parryStance;
    public ScoreCounter scores;
    public TextMeshProUGUI message;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        parryStance = false;
    }

    // Metodo que al ser llamado cambia de escena a la de game over
    private void EndGame()
    {
        if (scores.score > PlayerPrefs.GetInt("Puntuacion5"))
        {
            updateScoreBoard();
        }
        Cursor.visible = true;
        SceneManager.LoadScene(gameOver);
    }

    // Actualiza las mejores puntuaciones
    private void updateScoreBoard()
    {
        List<int> scoreList = new List<int>();

        scoreList.Add(PlayerPrefs.GetInt("Puntuacion1"));
        scoreList.Add(PlayerPrefs.GetInt("Puntuacion2"));
        scoreList.Add(PlayerPrefs.GetInt("Puntuacion3"));
        scoreList.Add(PlayerPrefs.GetInt("Puntuacion4"));
        scoreList.Add(PlayerPrefs.GetInt("Puntuacion5"));
        scoreList.Add(scores.score);

        scoreList = scoreList.OrderByDescending(i => i).ToList();

        for (int i = 0; i < scoreList.Count-1; i++)
        {
            var t = "Puntuacion" + (i+1);
            PlayerPrefs.SetInt(t, scoreList[i]);
        }
    }

    void Update() {
        // Cuando el jugador presione la tecla de espacio dependiendo de dependiendo del estado del jugador, este hara un parry o no
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!invulnerable && !parryStance)
            {
                StartCoroutine(Parry());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Cuando derecta que el jugador colisione con el GameObject con el tag de enemy llama al metodo empieza la corrutina de HitPlayer
        if (other.gameObject.tag == "Enemy")
        {
            if (!invulnerable)
            {
                StartCoroutine(HitPlayer());
            }
        }
    }

    // Corrutina que controla los parrys y los tiempos de espera cambiando tambien el sprite del jugador
    IEnumerator Parry()
    {
        invulnerable = true;

        Sprite Currentsprite= SR.sprite;
        SR.sprite = playerParrySprite;

        message.enabled = false;

        yield return new WaitForSeconds(parrySecs);

        SR.sprite = Currentsprite;
        
        StartCoroutine(ParryCd());

        invulnerable = false;
    }

    IEnumerator ParryCd()
    {
        parryStance = true;

        yield return new WaitForSeconds(parryCd);

        message.enabled = true;

        parryStance = false;
    }

    // Corrutina que controla todo lo que hay que vigilar sobre la vida del jugador
    // Controla las vidas del jugador junto a las del camvas
    // Controla los tiempos de invulnerabilidad al ser golpeado
    IEnumerator HitPlayer()
    {
        totalLives--;

        if (totalLives <= 0)
        {
            EndGame();
        }

        lives[totalLives].enabled = false;

        invulnerable = true;

        Color player = SR.color;
        player = new Color(255, 255, 255, 0.3f);
        SR.color = player;

        Sprite Currentsprite= SR.sprite;
        SR.sprite = playerHitSprite;

        yield return new WaitForSeconds(iframeSecs);

        player = new Color(255, 255, 255, 255);
        SR.color = player;

        SR.sprite = Currentsprite;
        
        invulnerable = false;
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
