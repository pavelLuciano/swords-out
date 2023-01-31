using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    private HitBoxControl hitbox;
    private int life;
    private bool mobility;

    private InputManager iMan;


    public HitBoxControl getHitbox() { return hitbox; }
    public bool canMove() { return mobility; }
    private void Awake()
    {
        hitbox = new HitBoxControl();
        mobility = true;
        life = 12;
    }

    private void Start()
    {
        iMan = GetComponent<InputManager>();
    }


    //hay que arreglar los esquives estos son provisionales

    public IEnumerator sideDodge(int side) // side = 0: left // side = 2: right  
    {
        mobility = false;
        float delay1 = 12f;
        float delay2 = 5f;
        if (hitbox.isDucking())
        {
            delay1 = 7f;
            delay2 = 21f;
        }
        yield return new WaitForSeconds(delay1 * MainGameController.TIME_UNIT);
        hitbox.moveTo(side);
        delay1 = 30f;
        yield return new WaitForSeconds(delay1 * MainGameController.TIME_UNIT);
        hitbox.backToCenter();
        yield return new WaitForSeconds(delay2 * MainGameController.TIME_UNIT);
        mobility = true;
    }

    public void duck()
    {
        hitbox.setDucking(true);
    }

    public void getUp()
    {
        hitbox.setDucking(false);
    }

    public bool isPlayerAtCoords(int i, int j)
    {
        if (i < 0 || j < 0) return false;
        return hitbox.isPlayerAtCoords(i,j);
    }

    public IEnumerator getHit()
    {
        iMan.stop();
        Debug.Log("Manso Wate Xuxetumare!!");
        mobility = false;
        hitbox.backToCenter();
        yield return new WaitForSeconds(MainGameController.TIME_UNIT * 60f);
        life--;
        mobility = true;
    }


}
    
