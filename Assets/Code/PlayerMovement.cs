using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public GameObject player;
    private Vector3 mousePos;
    public float movSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.Lerp(transform.position, mousePos, movSpeed);
    }
}
