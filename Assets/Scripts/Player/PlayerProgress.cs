using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class PlayerProgress : MonoBehaviour
{
    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;
    private int _levelValue = 1;

    public List<PlayerProgressLevel> Levels;
    public Slider ExperienceScale;
    public TextMeshProUGUI LevelValueTMP;
    public GameObject BananaIcon;
    public GameObject Text;

    public Transform SpawnPoint;
    public GameObject BossPreafab;
    public PlayerController Player;
    public List<Transform> PatrolPoints;
    public GameObject Vulcan;
    public GameObject Enemy2Spawner;
    public Final Final;

    private void Start()
    {
        DrawUI();
        Destroy(Text,7);
        SetLevel(_levelValue);
    }
    public void AddExperience(float value)
    {
        if (_levelValue == 10) return;
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
        CheckLevel(3);
        CheckLevel(4);
        CheckLevel(6);
        CheckLevel(7);
        CheckLevel(8);
        CheckLevel(10);
        var currentLevel = Levels[_levelValue - 1];
        _experienceTargetValue = currentLevel.ExperienceForTheNextLevel;
        GetComponent<FireballCaster>().Damage = currentLevel.FireballDamage;
        var grenadeCaster = GetComponent<BananaBombLauncher>();
        GetComponent<BananaBombLauncher>().Damage = currentLevel.GrenadeDamage;
        if (currentLevel.GrenadeDamage < 0)
            grenadeCaster.enabled = false;
        else
            grenadeCaster.enabled = true;
    }

    private void CheckLevel(int value)
    {
        if(value == 3 && _levelValue == value)
        {
            BananaIcon.SetActive(true);
        }
        else if (value == 4 && _levelValue == value)
        {
            var boss = Instantiate(BossPreafab, SpawnPoint);
            boss.GetComponent<EnemyAI>().Player = Player;
            boss.GetComponent<EnemyAI>().PatrolPoints = PatrolPoints;
        }
        else if (value == 6 && _levelValue == value)
        {
            var boss = Instantiate(BossPreafab, SpawnPoint);
            boss.transform.localScale += Vector3.one;
            boss.GetComponent<EnemyHealth>().value = 800;
            boss.GetComponent<EnemyAI>().Player = Player;
            boss.GetComponent<EnemyAI>().PatrolPoints = PatrolPoints;
        }
        else if (value == 7 && _levelValue == value)
        {
            Enemy2Spawner.SetActive(true);
        }
        else if (value == 8 && _levelValue == value)
        {
            Vulcan.SetActive(true);
        }
        else if (value == 10 && _levelValue == value)
        {
            SpawnPoint.position = new Vector3(-13.62f, 3.25f, -12.81f);
            var boss = Instantiate(BossPreafab, SpawnPoint);
            boss.transform.localScale += Vector3.one * 2;
            boss.GetComponent<NavMeshAgent>().stoppingDistance = 6;
            var bossHealth = boss.GetComponent<EnemyHealth>();
            bossHealth.value = 10000;
            bossHealth.Final = Final;
            boss.GetComponent<EnemyAI>().Player = Player;
            boss.GetComponent<EnemyAI>().PatrolPoints = PatrolPoints;
            enabled = false;
        }
    }

    private void DrawUI()
    {
        ExperienceScale.value = Mathf.Lerp(0, 1, _experienceCurrentValue / _experienceTargetValue);
        LevelValueTMP.text = _levelValue.ToString();
    }
}
