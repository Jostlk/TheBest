using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI EnemyPrefab;
    public PlayerController Player;
    public List<Transform> PatrolPoints;
    public AudioSource GoblinSound;

    private List<Transform> _spawmer;
    private List<EnemyAI> _enemies;

    public int EnemiesMaxCount = 5;
    public float delay = 5;

    private float _timeLastSpawned;

    private void Start()
    {
        _spawmer = new List<Transform>(GetComponentsInChildren<Transform>());
        _spawmer.Remove(_spawmer[0]);
        _enemies = new List<EnemyAI>();
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
        enemy.transform.position = _spawmer[Random.Range(0, _spawmer.Count)].position;
        enemy.Player = Player;
        enemy.PatrolPoints = PatrolPoints;
        _enemies.Add(enemy);
        var range = Random.Range(0, 2);
        if (range == 0)
        {
            GoblinSound.Play();
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
