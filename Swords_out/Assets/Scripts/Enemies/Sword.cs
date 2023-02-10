using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Enemy
{
    private float timer;
    private int counter;
  
    private void Awake()
    {
        SetEnemyAttacks();
        currentAttack = attacks[2];
        timer = 0f;
        counter = 0;   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0 && counter == 0)
        {   
            Debug.Log("3");
            counter++;
        }
        if (timer > 1 && counter == 1)
        {
            Debug.Log("2");
            counter++;
        }
        if (timer > 2 && counter == 2)
        {
            Debug.Log("1");
            counter++;
        }

        if (timer > 3 && counter == 3)
        {
            int i = Random.Range(0, 3);
            currentAttack = attacks[0];
            //Debug.Log("0");
            counter = 0;
            timer = 0f;
            StartCoroutine(currentAttack.attackEjecution());
        }
    }

    // -----------------------------------------
    //Funciones
    //------------------------------------------
    public override void SetEnemyAttacks()
    {
        attacks = new Attack[]
        {
            new HorizontalSlash(),
            new VerticalSlash(),
            new StabAttack()
        };
    }

    public override void stop()
    {
        StopAllCoroutines();
    }
}
