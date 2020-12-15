using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightJoystick : MonoBehaviour
{
    public Joystickku joystick;
    public Rigidbody2D rb;
    public GameObject bulletprefab;
    public Transform firePoint;

    private bool canShot = true;
    public float bulletforce = 20f;
    public float delayBullet = 0.3f;
    Vector2 rotate;

    void Update()
    {
        rotate = joystick.InputDir;

        if (rotate.x != 0 || rotate.y != 0)
        {
           if (canShot == true)
            {
                StartCoroutine(Tembak());
                canShot = false;
           }
        }
    }
    void FixedUpdate()
    {   
        float angel = (Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg) - 90f;
        rb.rotation = angel;
    }

    public IEnumerator Tembak()
    {
        GameObject peluru = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = peluru.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletforce;
        yield return new WaitForSeconds(delayBullet);
        canShot = true;
    }
    public void kecepatanTembak(float speedAtt)
    {
        delayBullet = speedAtt;
        StartCoroutine(defaultAttSpeed());  
    }
    IEnumerator defaultAttSpeed()
    {
        yield return new WaitForSeconds(5f);
        delayBullet = 0.3f;
    }
}
