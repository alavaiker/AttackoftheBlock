using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBall : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float force;
    private 
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Start()
    {
        // Le añadimos al RigidBody una fuerza a una direccion aleatoria
        float random = Random.Range(0, 360);
        rb.AddForce(new Vector2(Mathf.Cos(random), Mathf.Sin(random)) * force);
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        // Cuando entre en colision con el player se llamara a la funcion de ActivatePowerUp de la clase PowerUpController y se destrulle el objeto
        if (other.gameObject.tag == "Player")
        {
            PowerUpController.GetInstance.ActivatePowerUp();
            Destroy(gameObject);
        }
    }
    
}
