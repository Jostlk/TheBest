using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaBombLauncher : MonoBehaviour
{
    public float Damage = 50;
    public Rigidbody BananaBombPrefab;
    public Transform GrenadeSourceTransform;

    //Ссылка на иконку способности
    public Image SpellIcon;
    //Время перезарядки
    public float Cooldown = 10f;
    private int _count = 0;
    private float _timer = 0f;

    public float Force = 10;
    void Update()
    {
        _timer += Time.deltaTime;
        UpdateUltimateIcon();
        if (Input.GetMouseButtonDown(1) && _timer >= Cooldown)
        {
            var grenade = Instantiate(BananaBombPrefab);
            grenade.transform.position = GrenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourceTransform.forward * Force);
            grenade.GetComponent<BananaBomb>().Damage = Damage;
            _count++;
        }
        if (_count == 3)
        {
            _timer = 0f;
            _count = 0;
        }
    }

    void UpdateUltimateIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = _timer / Cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}
