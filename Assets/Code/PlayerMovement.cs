using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private GameObject player;
    public Vector3 mousePos;
    private Rigidbody2D rb;

    private void Awake() {
        // Asignamos a la variable rb el componente RigidBody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Asignamos a la variable player el propio GameObject player y hacemos el cursor invisible
        player = this.gameObject;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Vamos guardando la posicion del raton y se la asignamos a player mediante la variable rb
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        rb.MovePosition(mousePos);
    }
}
