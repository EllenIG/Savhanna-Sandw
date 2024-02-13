using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSawnTime;

    private float _timeUntilSpawn;
    public float spawnEveryXSeconds;
    // Start is called before the first frame update   

    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, spawnEveryXSeconds);
    }
    void Awake()
    {
        SetTimeUntilSpawn();
    }
    

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSawnTime);
    }
}
