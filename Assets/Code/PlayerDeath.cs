using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]private string gameOver;
    [SerializeField]public int lives;
    [SerializeField]private int iframeSecs;

    // Metodo que al ser llamado cambia de escena a la de game over
    private void EndGame()
    {
        SceneManager.LoadScene(gameOver);
    }

    void hitPlayer()
    {
        for (int i = 0; i < iframeSecs; i += (int)Time.deltaTime)
        {
            Debug.Log("BBBBBBBBBBBBBBBBBBBB");
            
            lives--;
            Debug.Log("Te quedan " + lives + " vidas");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Cuando derecta que el jugador colisione con el GameObject con el tag de enemy llama al metodo "EndGame"
        if (other.gameObject.tag == "Enemy")
        {
            hitPlayer();
        }
    }
}
