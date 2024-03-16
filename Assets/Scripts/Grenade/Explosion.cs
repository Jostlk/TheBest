using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    public float Speed = 1;
    public float MaxSize = 5;
    public float Damage = 50;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x > MaxSize)
        {
            Destroy(gameObject);
        }
        transform.localScale += Vector3.one * Time.deltaTime * Speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.DealDamage(Damage);
        }
        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(Damage);
        }
    }
}
