using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;
    public Explosion ExplosionPrefab;
    public PlayerProgress progress;
    public Final Final;
    public AudioSource DeathSound;

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
        var AI = GetComponent<EnemyAI>();
        if (AI != null)
        {
            AI.enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            Invoke("MobExplosion", 2);
            DeathSound.Play();
            Destroy(gameObject, 5);
        }
        else if (AI == null)
        {
            Destroy(gameObject);
        }
        if (transform.localScale == new Vector3(3,3,3))
        {
            GetComponent<AudioSource>().Stop();
            Destroy(gameObject, 5);
            Final.FinalMetod();
        }
    }

    private void MobExplosion()
    {
        if (ExplosionPrefab == null) return;
        var explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.localPosition;
    }
}
