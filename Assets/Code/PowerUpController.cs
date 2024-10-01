using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private GameObject powerBall;
    private GameObject powerBallInstance;
    public static PowerUpController Instance;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(this.gameObject);
        } 
    }

    // Update is called once per frame
    void Start()
    {
        if (powerBall)
        {
            InvokeRepeating(nameof(Spawn), 0, 20);
        }
    }

    void Spawn()
    {
        if (powerBallInstance == null)
        {
            powerBallInstance = Instantiate(powerBall) ;
        }
    }

    void ReturnTime()
    {
        Time.timeScale = 1;
    }

    public void ActivatePowerUp()
    {
        Time.timeScale = .5f;
        Invoke(nameof(ReturnTime), 3*Time.timeScale);
    }
}
