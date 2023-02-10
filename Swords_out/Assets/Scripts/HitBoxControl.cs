using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxControl
{

    public bool[,] playerPos;
    public bool duck;

    //Shield Fields
    public Vector2Int shieldDirection;
    public bool activeShield;
    public float timeShielding;




    public HitBoxControl()
    {
        playerPos = new bool[2, 3];
        this.backToCenter();
        shieldDirection = new Vector2Int(0, 0);
    }

    public bool isDucking() { return duck; }
    public void setDucking(bool ducking) 
    { 
        this.duck = ducking;
        playerPos[0, 1] = !ducking;
    }

    public void moveTo(int n) //0: left / 1: center / 2: right
    {
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 3; j++)
            {
                if (j == n) playerPos[i, j] = true;
                else playerPos[i, j] = false;
            }

        if (duck) playerPos[0, n] = false;
    }

    public void backToCenter()
    {
        duck = false;
        moveTo(1);
    }

}
