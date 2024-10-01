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
        if (other.gameObject.tag == "Player")
        {
            PowerUpController.Instance.ActivatePowerUp();
            Destroy(gameObject);
        }
    }
    
}
