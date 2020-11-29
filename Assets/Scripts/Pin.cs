using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isPinned = false;

    public float speed = 20f;
    public Rigidbody2D rigidBody;

    void Update ()
    {   
        if (!isPinned)
        rigidBody.MovePosition(rigidBody.position + Vector2.up * speed * Time.deltaTime);    
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Rotator")
        {
            transform.SetParent(collision.transform);
            Score.PinCount++;
            isPinned = true;
        } else if (collision.tag == "Pin")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
