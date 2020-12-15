using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeftJoystick : MonoBehaviour
{
    public Rigidbody2D rb;
    public Joystickku joystick;
    public float speed = 10f;
    Vector2 move;

    // Update is called once per frame
    void Update()
    {
        move = joystick.InputDir;
    }
    void FixedUpdate()
    {
        rb.position += move * speed * Time.fixedDeltaTime;
    }
}
