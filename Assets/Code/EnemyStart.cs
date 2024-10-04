using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStart : MonoBehaviour
{

    private Rigidbody2D rb;
    public float force;

    private void Awake() {
        // Asignamos a la variable rb el componente RigidBody2D
        rb = GetComponent<Rigidbody2D>();

        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Le añadimos al RigidBody una fuerza a una direccion aleatoria
        float random = Random.Range(0, 360);
        rb.AddForce(new Vector2(Mathf.Cos(random), Mathf.Sin(random)) * force);
    }
}
