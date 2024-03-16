using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;
    private int _levelValue = 1;

    public List<PlayerProgressLevel> Levels;
    public Slider ExperienceScale;
    public TextMeshProUGUI LevelValueTMP;

    private void Start()
    {
        DrawUI();
        SetLevel(_levelValue);
    }
    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;
        var currentLevel = Levels[_levelValue - 1];
        _experienceTargetValue = currentLevel.ExperienceForTheNextLevel;
        GetComponent<FireballCaster>().Damage = currentLevel.FireballDamage;
        var grenadeCaster = GetComponent<GrenadeCaster>();
        GetComponent<GrenadeCaster>().Damage = currentLevel.GrenadeDamage;
        if (currentLevel.GrenadeDamage < 0)
            grenadeCaster.enabled = false;
        else
            grenadeCaster.enabled = true;
    }

    private void DrawUI()
    {
        ExperienceScale.value = Mathf.Lerp(0, 1, _experienceCurrentValue / _experienceTargetValue);
        LevelValueTMP.text = _levelValue.ToString();
    }
}
