using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private GameObject[] powerBall;
    private GameObject powerBallInstance;
    
    //*******************************************************************
    // Creamos un sigleton
    //*******************************************************************
    private static PowerUpController _Instance;
    public static PowerUpController GetInstance => _Instance;

    private void Awake() 
    { 
        // Si se crea una instacia y ya existe una se borra la creada
        
        if (_Instance != null && _Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            _Instance = this; 
            DontDestroyOnLoad(this.gameObject);
        } 
    }

    //*******************************************************************
    // Hasta aqui es la creacion del singleton
    //*******************************************************************

    // Update is called once per frame
    void Start()
    {
        if (powerBall.Length > 0)
        {
            if (powerBall[0])
            {
                InvokeRepeating(nameof(Spawn), 10, 20);
            }
        }
    }

    void Spawn()
    {
        if (powerBallInstance == null)
        {
            powerBallInstance = Instantiate(powerBall[Random.Range(0, powerBall.Length)]) ;
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
