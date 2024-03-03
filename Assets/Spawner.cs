using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public List<Transform> spawnPoints;
    public List<int> enemiesPerWave;


    [Range(0f, 10f)]public float spawnSpeed;
    [Range(0f, 10f)]public float timeBetweenWaves;

    int enemiesLeft;

    public UnityEvent onSpawn;
    public UnityEvent<int> onWaveStart;

    public void Spawn()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(enemy, point.position, point.rotation);
        onSpawn.Invoke();
    }

    async void Start()
    {
        foreach (var count in enemiesPerWave)
        {
            onWaveStart.Invoke(count);
            enemiesLeft = count;

            enemiesLeft = enemiesPerWave[0];
            while (enemiesLeft > 0)
            {
                await new WaitForSeconds(spawnSpeed);
                Spawn();
                enemiesLeft--;
            }


            await new WaitForSeconds(timeBetweenWaves);
        }
    }
}
