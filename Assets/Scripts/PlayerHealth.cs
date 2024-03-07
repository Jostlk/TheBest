using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 100;
    public Slider Healthbar;
    public float _curentValue;

    public GameObject GameplayUI;
    public GameObject GameOverScreen;

    public Animator animator;

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
    }
    private void PlayerIsDead()
    {
        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GameOverScreen.GetComponent<Animator>().SetTrigger("show");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("Death");
    }
    public void AddHealth(float amount)
    {
        _curentValue += amount;
        _curentValue = Mathf.Clamp(_curentValue, 0, MaxValue);
        UpdateHealthbar();
    }
}
