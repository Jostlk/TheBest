using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerController Player;
    private bool _isPlayerNoticed;
    public float ViewAngle;
    public float Damage = 30;
    private PlayerHealth _playerHealth;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
        _playerHealth = Player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
        NoticePlayerUpdate();
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                AttackUpdate();
            }
        }

    }

    private void NoticePlayerUpdate()
    {
        var direction = Player.transform.position - transform.position;
        RaycastHit hit;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }
    private void AttackUpdate()
    {
        _playerHealth.DealDamage(Damage * Time.deltaTime);
    }
}
