using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    private Transform target;
    public Transform enemy;
    public GameObject deathEffect;
    public int enemyHealth = 100;
    public int hitDamage = 10;
    public float speed = 20f;
    private bool searchForPlayer = false;
    void Start()
    {
        if (target == null)
        {
            if (!searchForPlayer)
            {
                searchForPlayer = true;
                StartCoroutine(SearchingForPlayer());
            }
        }
    }
    public IEnumerator SearchingForPlayer()
    {
        GameObject result = GameObject.FindGameObjectWithTag("Player");
        if (result == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchingForPlayer());
        }
        else
        {
            target = result.transform;
            searchForPlayer = false;
            yield return false;
        }
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        transform.Rotate(0f, 0f, 100f * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player plyr = collision.collider.GetComponent<Player>();
        if (collision.gameObject.CompareTag("Player"))
        {
            plyr.TakeDamage(hitDamage);
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}
