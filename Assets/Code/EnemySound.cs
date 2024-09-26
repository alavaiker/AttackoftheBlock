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

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.tag != "Player")
        {
            Debug.Log("Hit");
            audioController.clip = bounce;
            audioController.Play();
        } else
        {
            Debug.Log("Hit player");
            audioController.clip = hitPlayer;
            audioController.Play();
        }
    }
}
