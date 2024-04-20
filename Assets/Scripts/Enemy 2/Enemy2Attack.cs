using UnityEngine;

public class Enemy2Attack : MonoBehaviour
{
    public EnemyFireball EnemyFireball;
    public Transform EnemySource;
    public Transform Player;

    public void CreateFireball()
    {
        transform.LookAt(Player.position + Vector3.up);
        EnemySource.LookAt(Player.position + Vector3.up);
        var fireball = Instantiate(EnemyFireball, EnemySource.position, EnemySource.rotation);
    }
}
