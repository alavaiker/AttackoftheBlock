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
        // Cuando entre en colision con el player se llamara a la funcion de ActivatePowerUp, lo envia a una zona fuera del mapa y llama a la funcion de DestroyPowerUp
        if (other.gameObject.tag == "Player")
        {
            ActivatePowerUp();
            rb.transform.position = new Vector3(20, 20, 1);
            Invoke(nameof(DestroyPoweUp), 5);
        }
    }
    
    // Devuelve el tiempo a la normalidad
    void ReturnTime()
    {
        Time.timeScale = 1;
    }

    // Activa el poder de realentizar el tiempo
    public void ActivatePowerUp()
    {
        Time.timeScale = .5f;
        Invoke(nameof(ReturnTime), 3*Time.timeScale);
    }

    // Destruye el objeto
    public void DestroyPoweUp()
    {
        Destroy(gameObject);
    }
}
