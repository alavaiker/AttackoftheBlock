using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;
    public PlayerMovement playerMovement;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);

        // Input.mousePosition.Set(playerMovement.gameObject.transform.position.x, playerMovement.gameObject.transform.position.y, 0);
        
        Vector2 pos = Camera.main.WorldToScreenPoint(playerMovement.gameObject.transform.position);
        Mouse.current.WarpCursorPosition(pos);
        
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.visible = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
