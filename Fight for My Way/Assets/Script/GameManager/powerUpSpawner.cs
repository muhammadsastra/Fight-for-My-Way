using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    public GameObject powerUp;
    public float spawnDelay = 20f;
    private void Start()
    {
        StartCoroutine(spawnPowerUp());
    }
   IEnumerator spawnPowerUp()
    {
        yield return new WaitForSeconds(spawnDelay);
        
        Vector2 spawnPos = new Vector2(Random.Range(-20f,20f), Random.Range(-20f,20f));
           
        Instantiate(powerUp, spawnPos, Quaternion.identity);
        StartCoroutine(spawnPowerUp());
    }
}
