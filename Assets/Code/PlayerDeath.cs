using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Color = UnityEngine.Color;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]private string gameOver;
    [SerializeField]public int lives;
    [SerializeField]private float iframeSecs;
    private bool inv;

    [SerializeField]private Sprite playerHitSprite;

    private SpriteRenderer SR;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            EndGame();
        }
    }

    // Metodo que al ser llamado cambia de escena a la de game over
    private void EndGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(gameOver);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Cuando derecta que el jugador colisione con el GameObject con el tag de enemy llama al metodo "EndGame"
        if (other.gameObject.tag == "Enemy")
        {
            if (!inv)
            {
                StartCoroutine(HitPlayer());
            }
        }
    }

    IEnumerator HitPlayer()
    {
        lives--;
        Debug.Log("" + lives);
        inv = true;
        Color player = SR.color;
        player = new Color(255, 255, 255, 0.3f);
        SR.color = player;
        Sprite Currentsprite= SR.sprite;
        SR.sprite = playerHitSprite;
        yield return new WaitForSeconds(iframeSecs);
        player = new Color(255, 255, 255, 255);
        SR.color = player;
        SR.sprite = Currentsprite;
        inv = false;
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
