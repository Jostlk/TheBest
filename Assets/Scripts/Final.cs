using TMPro;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject GameplayUI;
    public GameObject GameOverScreen;
    public TextMeshProUGUI Text;
    public PlayerController PlayerController;
    public EnemySpawner EnemySpawner;
    public Enemy2Spawner Enemy2Spawner;
    public Animator Animator;
    public AudioSource Background;
    public AudioSource GameOverSource;

    public void FinalMetod()
    {
        gameObject.SetActive(true);
        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        Background.Stop();
        GameOverSource.Stop();
        Text.SetText("YOU WON!");
        GameOverScreen.GetComponent<Animator>().SetTrigger("show");
        Animator.SetInteger("Run direction", 0);
        Destroy(PlayerController);
        Destroy(PlayerController.GetComponent<CameraRotation>());
        Destroy(PlayerController.GetComponent<FireballCaster>());
        EnemySpawner.DestroyAllEnemys();
        Enemy2Spawner.DestroyAllEnemys();
    }
}
