using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    public Enemy2AI EnemyPrefab;
    public PlayerController Player;
    public List<Transform> PatrolPoints;
    public AudioSource GoblinSpawn;

    private List<Enemy2AI> _enemies;

    public int EnemiesMaxCount = 5;
    public float delay = 5;

    private float _timeLastSpawned;

    private void Start()
    {
        _enemies = new List<Enemy2AI>();
    }

    void Update()
    {
        CheckForDeadEnemies();
        if (_enemies.Count >= EnemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;

        CreateEnemy();
    }

    private void CheckForDeadEnemies()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }
    }

    public void CreateEnemy()
    {
        var enemy = Instantiate(EnemyPrefab);
        enemy.transform.position = transform.position;
        enemy.Player = Player;
        enemy.PatrolPoints = PatrolPoints;
        enemy.GetComponent<Enemy2Attack>().Player = Player.transform;
        _enemies.Add(enemy);
        var range = Random.Range(0, 2);
        if (range == 0)
        {
            GoblinSpawn.Play();
        }
        _timeLastSpawned = Time.time;
    }
    public void DestroyAllEnemys()
    {
        enabled = false;
        for (var i = 0; i < _enemies.Count; i++)
        {
            Destroy(_enemies[i].gameObject);
        }
    }
}
