using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private GameObject[] powerBall;
    private GameObject powerBallInstance;
    
    //*******************************************************************
    // Creamos un sigleton

    // NOTA: NO SE NECESITA USAR UN SINGLETON EN ESTE MOMENTO (CREO) PERO LO DEJO ASI YA QUE NO AFECTA EN NADA Y ASI ME ACUERDO DE COMO SE HACE

    //*******************************************************************
    private static PowerUpController _Instance;
    public static PowerUpController GetInstance => _Instance;
    private Vector3 position;

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
        // Mira si hay algun poder en el array powerBall[] y si lo hay invoca continuamente a la funcion de Spawn
        if (powerBall.Length > 0)
        {
            if (powerBall[0])
            {
                InvokeRepeating(nameof(Spawn), 5, 20);
            }
        }
    }

    // Controla que no exista otra instancia de powerBall y que la escena sea la de GamePlay
    // Selecciona una zona aleatoria dentro del campo de juego y instancia un PowerBall
    void Spawn()
    {
        if (powerBallInstance == null && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            position = new Vector3(Random.Range(-8, 8), Random.Range(3, -4), 1);
            powerBallInstance = Instantiate(powerBall[0], position, Quaternion.identity) ;
        }
    }
}
