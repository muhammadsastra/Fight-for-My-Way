using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING };

    public Timer timer;
    public Wave wave;
    public GameObject[] enemy;
    List<Transform> spawnpoint = new List<Transform>();

    public int jumlahMusuh;
    public int penambahanMusuh = 4;
    public float spawnDelay =  0.5f;
    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.SPAWNING;
    public SpawnState State
    {
        get { return state; }
    }
    void Start()
    {
        foreach (Transform child in transform)
        {
            spawnpoint.Add(child);
        }
    }
    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!FindEnemy())
            {
                timer.Waveselanjutnya();
            }
            else
            {
                return;
            }
        }
    }
    bool FindEnemy()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    public void mulai()
    {
        StartCoroutine(StartSpawn());
    }

    public IEnumerator StartSpawn()
    {
        wave.UpdateWave();

        for (int i = 0; i < jumlahMusuh; i++)
        {
            int randomEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomEnemy], RandomSpawnPoint(), Quaternion.identity);
            
            yield return new WaitForSeconds(spawnDelay);
        }
        jumlahMusuh += penambahanMusuh;
        state = SpawnState.WAITING;

        yield break;
    }
    public Vector3 RandomSpawnPoint() 
    { return spawnpoint[Random.Range(0, spawnpoint.Count)].position; }
}
