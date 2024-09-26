using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public string GameOver;

    // Metodo que al ser llamado cambia de escena a la de game over
    private void EndGame()
    {
        SceneManager.LoadScene(GameOver);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Cuando derecta que el jugador colisione con el GameObject con el tag de enemy llama al metodo "EndGame"
        if (other.gameObject.tag == "Enemy")
        {
            // EndGame();
        }
    }
}
