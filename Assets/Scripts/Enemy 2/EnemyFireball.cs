using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    public float LifeTime;
    public float Speed;
    public float Damage = 10;
    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamagePlayer(collision);
        Destroy(gameObject);
    }
    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
    private void DamagePlayer(Collision collision)
    {
        var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(Damage);
        }
    }
}
