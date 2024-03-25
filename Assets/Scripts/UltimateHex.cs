using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateHex : MonoBehaviour
{
    //Ссылка на иконку способности
    public Image SpellIcon;
    //Время перезарядки
    public float Cooldown = 10f;
    private int _count;
    private float _timer = 0f;

    void Update()
    {
        //Обновляем таймер и иконку
        _timer += Time.deltaTime;
        UpdateUltimateIcon();

        //Если нажата клавиша способности и таймер больше времени перезарядки
        if (Input.GetMouseButtonDown(1) && _timer >= Cooldown)
        {
            _count++;
        }
        if(_count == 3)
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
