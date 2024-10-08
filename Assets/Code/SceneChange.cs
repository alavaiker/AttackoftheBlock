using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EsceneChange : MonoBehaviour
{
    // Script que lleva a la escena de juego
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    // Script que lleva al menu principal
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    // Script que termina el juego
    public void Exit()
    {
        Application.Quit();
    }
}
