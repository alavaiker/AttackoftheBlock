using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]private string gameOver;
    [SerializeField]public int totalLives;
    [SerializeField]private float iframeSecs;
    private bool invulnerable;
    [SerializeField]private Sprite playerHitSprite;
    private SpriteRenderer SR;
    [SerializeField] RawImage[] lives;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Metodo que al ser llamado cambia de escena a la de game over
    private void EndGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(gameOver);
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
