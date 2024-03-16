using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;
    public Explosion ExplosionPrefab;
    public PlayerProgress progress;

    private void Start()
    {
        progress = FindObjectOfType<PlayerProgress>();
    }
    public bool IsAlive()
    {
        return value > 0;
    }
    public void DealDamage(float damage)
    {
        progress.AddExperience(damage);
        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke("MobExplosion",2);
        Destroy(gameObject, 5);
    }

    private void MobExplosion()
    {
        if (ExplosionPrefab == null) return;
        var explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.position;
    }
}
