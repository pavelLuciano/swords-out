using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour, IStopable
{
    private PlayerControl player;
    private int defUp, defDown, defRight, defLeft;

    private void Awake()
    {
        defUp = defDown = defRight = defLeft = 0;
    }
    void Start()
    {
        player = GetComponent<PlayerControl>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.canMove())
        {
            // el persoaje se levanta y se agacha cuando se presiona o se suelta una tecla
            if (Input.GetKeyDown(KeyCode.DownArrow)) { player.duck(); }
            if (Input.GetKeyUp(KeyCode.DownArrow)) { player.getUp(); }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(player.sideDodge(0));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(player.sideDodge(2));
            }

            
        }

        if (Input.GetKeyUp("w")) defUp = 0;
        if (Input.GetKeyUp("a")) defLeft = 0;
        if (Input.GetKeyUp("s")) defDown = 0;
        if (Input.GetKeyUp("d")) defRight = 0;

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            player.shield(); //esto hay que cambiarlo
            if (Input.GetKeyDown("w")) defUp = 1;
            if (Input.GetKeyDown("a")) defLeft = 1;
            if (Input.GetKeyDown("s")) defDown = 1;
            if (Input.GetKeyDown("d")) defRight = 1;
            player.shieldTowards(defRight - defLeft, defUp - defDown);
        }
        else player.unShield();

    }

    public void stop()
    {
        StopAllCoroutines();
    }
}
