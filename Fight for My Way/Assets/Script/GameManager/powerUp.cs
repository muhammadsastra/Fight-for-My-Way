using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public AudioSource audio;
    private void Start()
    {
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        RightJoystick rb = collision.GetComponent<RightJoystick>();
        if (collision.gameObject.CompareTag("Player"))
        {
            audio.Play();
            rb.kecepatanTembak(0.1f);
            Destroy(gameObject, 0.1f);
        }
    }
}
