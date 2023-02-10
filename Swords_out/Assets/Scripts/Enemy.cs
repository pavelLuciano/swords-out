using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IStopable
{
    private string enemyName;

    //esto deberia ser privado
    public Attack[] attacks;
    public Attack currentAttack;

    public Vector2Int[] getHittedBlocks()
    {
        return currentAttack.currentHit.attackedBlocks;
    }

    public Vector2Int getCurrentHitDirection()
    {
        return currentAttack.currentHit.direction;
    }

    public void getParried()
    {
        stop();
        //mas cosas
    }
    abstract public void SetEnemyAttacks();
    abstract public void stop();
}
