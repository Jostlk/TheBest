using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{
    public EnemyAI enemyAI;
    public Enemy2AI enemy2AI;
    public void AttackDamage()
    {
        if (enemyAI != null)
        {
            enemyAI.Attack();
        }
        else
        {
            enemy2AI.Attack();
        }
    }
}
