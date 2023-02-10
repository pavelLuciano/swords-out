using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    private HitBoxControl hitbox;
    private int life;
    private bool mobility;
    private InputManager iMan;

    
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
    //Modificadores de HitBox
    public void duck()
    {
        hitbox.setDucking(true);
    }
    public void getUp()
    {
        hitbox.setDucking(false);
    }
    public void shieldTowards(int i, int j)
    {
        hitbox.shieldDirection.x = i;
        hitbox.shieldDirection.y = j;
    }
    public void shield()
    {
        hitbox.activeShield = true;
        hitbox.timeShielding += Time.deltaTime;
    }
    public void unShield()
    {
        hitbox.activeShield = false;
        hitbox.timeShielding = 0f;
    }

    //accesos
    public bool isPlayerShielding()
    {
        return hitbox.activeShield;
    }
    public bool isPlayerAtCoords(int i, int j)
    {
        if (i < 0 || j < 0) return false;
        return hitbox.playerPos[i,j];
    }
    public HitBoxControl getHitbox() 
    { 
        return hitbox;
    }
    public Vector2Int getShieldDirection()
    {
        return hitbox.shieldDirection;
    }
    public bool canMove()
    { 
        return mobility;
    }
    public float getTimeShielding()
    {
        return hitbox.timeShielding;
    }


    //acciones (corrutinas)
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
    public void doParry()
    {
        
    }
}
    
