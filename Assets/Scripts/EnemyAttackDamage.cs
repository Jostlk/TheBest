﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{
    public EnemyAI enemyAI;
    public void AttackDamage()
    {
        enemyAI.Attack();
    }
}
