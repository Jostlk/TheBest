using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 100;
    public Slider Healthbar;
    public Image Image;
    public Material Material1;
    public Material Material2;
    public float _curentValue;

    public GameObject GameplayUI;
    public GameObject GameOverScreen;

    public Animator animator;
    public AudioSource Background;

    public ParticleSystem HealEffect;

    public EnemySpawner EnemySpawner;
    public Enemy2Spawner Enemy2Spawner;
    public GameObject VulcanActive;

    private void Start()
    {
        _curentValue = MaxValue;
        UpdateHealthbar();
    }
    public void DealDamage(float damage)
    {
        _curentValue -= damage;
        if (_curentValue <= 0)
        {
            PlayerIsDead();
        }
        UpdateHealthbar();
    }
    void UpdateHealthbar()
    {
        Healthbar.value = Mathf.Lerp(0,1,_curentValue/MaxValue);
        Image.color = Color.Lerp(Material1.color, Material2.color, _curentValue / MaxValue);
    }
    private void PlayerIsDead()
    {
        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GameOverScreen.GetComponent<Animator>().SetTrigger("show");
        Background.Stop();
        Destroy(VulcanActive);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("Death");
        EnemySpawner.DestroyAllEnemys();
        Enemy2Spawner.DestroyAllEnemys();
    }
    public void AddHealth(float amount)
    {
        _curentValue += amount;
        _curentValue = Mathf.Clamp(_curentValue, 0, MaxValue);
        HealEffect.Play();
        UpdateHealthbar();
    }
}
