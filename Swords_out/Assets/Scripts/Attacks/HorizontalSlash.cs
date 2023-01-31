using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class HorizontalSlash: Attack
{
    public HorizontalSlash():base()
    {
        Vector2Int direction = Vector2Int.right;
        Vector2Int[] attackedBlocks = { new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(0, 2) };
        hits = new Hit[1]
        { 
            new Hit(direction, attackedBlocks)
        };
    }


    public override IEnumerator attackEjecution()
    {
        currentHit = hits[0];
        Debug.Log("HORIZONTAL SLASH!!!!");
        //vamos a probar una caosas aca para ver si esto funciona pero deberi ser asi
        yield return new WaitForSeconds(MainGameController.TIME_UNIT * 17f);
        currentHit = Hit.noHit;
    }
}
