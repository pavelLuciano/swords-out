using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour, IStopable
{
    private PlayerControl player;

    void Start()
    {
        player = GetComponent<PlayerControl>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.canMove())
        {
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
    }

    public void stop()
    {
        StopAllCoroutines();
    }
}
