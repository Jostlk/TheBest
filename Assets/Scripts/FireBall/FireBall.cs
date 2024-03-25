using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
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
        DamageEnemy(collision);
        Destroy(gameObject);
    }
    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(Damage);
        }
    }
}
