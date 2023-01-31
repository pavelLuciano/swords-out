using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Attack
{
    [System.Serializable]
    public class Hit
    {
        public static Hit noHit = new Hit(
            Vector2Int.zero , 
            new Vector2Int[] { new Vector2Int(-1,-1)}
            );

        public Vector2Int direction;
        public Vector2Int[] attackedBlocks;


        public Hit(Vector2Int dir, Vector2Int[] atBlck)
        {
            direction = dir;
            attackedBlocks = atBlck;
        }
    } 

    public Hit currentHit;
    public Hit[] hits;

    public Attack()
    {
        this.currentHit = Hit.noHit;
    }
    public abstract IEnumerator attackEjecution();

}