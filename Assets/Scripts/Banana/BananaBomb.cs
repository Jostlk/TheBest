using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBomb : MonoBehaviour
{
    public AudioSource CollisionSound;
    public GameObject ExplosionEffect;
    //Задай параметры радиуса, урона, таймера и скорости запуска
    public float Radius = 5;
    public float Damage = 50;
    public float Timer = 3;

    void Start()
    {
        Invoke("Explode", Timer);
    }

    void Explode()
    {
        //Находим все коллайдеры в радиусе взрыва
        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            //Предполагаем, что коллайдер - это враг
            EnemyHealth enemyHealth = colliders[i].GetComponent <EnemyHealth> ();
            if (enemyHealth != null)
            {
                //Если это так, то наносим урон
                enemyHealth.DealDamage(Damage);
            }
        }
        //Уничтожаем бомбу
        Destroy(gameObject);
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionSound.pitch = Random.Range(0.7f, 1.3f);
        CollisionSound.Play();
    }
}
