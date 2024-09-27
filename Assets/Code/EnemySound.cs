using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySound : MonoBehaviour
{

    private AudioSource audioController;
    [SerializeField] private AudioClip bounce;
    [SerializeField] private AudioClip hitPlayer;
    // Start is called before the first frame update
    void Start()
    {
        // Asignamos a audioController el componente de AudioSource
        audioController = this.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag != "Player")
        {
            audioController.clip = bounce;
            audioController.Play();
        } else
        {
            audioController.clip = hitPlayer;
            audioController.Play();
        }
    }
}
