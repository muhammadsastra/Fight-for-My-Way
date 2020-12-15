using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hiteffect;
    public int damage = 50;
    void Start()
    {
        Destroy(gameObject, 4f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }    
        GameObject effect = Instantiate(hiteffect, transform.position, transform.rotation);
        Destroy(effect, 0.3f);
        Destroy(gameObject);
    }
}
