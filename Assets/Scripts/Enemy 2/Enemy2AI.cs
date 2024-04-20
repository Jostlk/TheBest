using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2AI : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerController Player;
    private bool _isPlayerNoticed;
    public float ViewAngle;
    public float Damage = 30;
    private PlayerHealth _playerHealth;
    public Animator animator;
    private EnemyHealth _enemyHealth;
    private Enemy2Attack _enemyAttack;

    public bool IsAlive()
    {
        return _enemyHealth.IsAlive();
    }
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
        _playerHealth = Player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyAttack = GetComponent<Enemy2Attack>();
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
                animator.SetTrigger("attack");
            }
        }

    }
    public void Attack()
    {
        _enemyAttack.CreateFireball();
    }

    private void NoticePlayerUpdate()
    {
        RaycastHit hit;
        _isPlayerNoticed = false;
        if (_playerHealth._curentValue <= 0) return;
        var direction = Player.transform.position - transform.position;
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

}
