using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabAttack : Attack
{
    public StabAttack() : base()
    {
        Vector2Int direction = Vector2Int.zero;
        Vector2Int[] attackedBlocks = { new Vector2Int(1, 1) };
        hits = new Hit[1]
        {
            new Hit(direction, attackedBlocks)
        };
    }
    public override IEnumerator attackEjecution()
    {
        currentHit = hits[0];
        Debug.Log("STAB!!!!");
        //vamos a probar una caosas aca para ver si esto funciona pero deberi ser asi
        yield return new WaitForSeconds(MainGameController.TIME_UNIT * 7f);
        currentHit = Hit.noHit;
    }

}
