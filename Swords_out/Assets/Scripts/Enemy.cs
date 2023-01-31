using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IStopable
{
    private string enemyName;

    public Attack[] attacks;
    public Attack currentAttack;

    public Vector2Int[] getHittedBlocks()
    {
        return currentAttack.currentHit.attackedBlocks;
    } 
    abstract public void SetEnemyAttacks();
    abstract public void stop();
}
