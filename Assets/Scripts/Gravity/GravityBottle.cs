using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GravityBottle : MonoBehaviour
{
    public float HealAmount = 50;
    public GameObject AidkitModel;
    public GameObject Particle;
    public AudioSource Healing;

    public GameObject BossPreafab;
    public Transform SpawnPoint;
    public Final Final;
    public PlayerController Player;
    public List<Transform> PatrolPoints;

    public FireballCaster FireballCasterActive;
    public BananaBombLauncher BananaBombLauncherActive;
    public GameObject BananaBomb;
    public GameObject FireballSource;
    public GameObject GravitySource;
    public TextMeshProUGUI Text;
    public GameObject Clue;

    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 80 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            DestroyAidkit(playerHealth);
            CreateBoss();
            Text.SetText("          Победить босса");
            Clue.SetActive(true);
            Destroy(Clue, 15);
            Destroy(FireballCasterActive);
            Destroy(FireballSource);
            Destroy(BananaBombLauncherActive);
            Destroy(BananaBomb);
            GravitySource.SetActive(true);
        }
    }

    private void DestroyAidkit(PlayerHealth playerHealth)
    {
        playerHealth.AddHealth(HealAmount);
        Healing.Play();
        AidkitModel.SetActive(false);
        Particle.SetActive(false);
        GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject, 2);
    }

    private void CreateBoss()
    {
        var boss = Instantiate(BossPreafab, SpawnPoint);
        boss.transform.localScale += Vector3.one * 2;
        boss.GetComponent<NavMeshAgent>().stoppingDistance = 6;
        var bossHealth = boss.GetComponent<EnemyHealth>();
        bossHealth.value = 10000;
        bossHealth.Final = Final;
        boss.GetComponent<EnemyAI>().Player = Player;
        boss.GetComponent<EnemyAI>().PatrolPoints = PatrolPoints;
    }
}
