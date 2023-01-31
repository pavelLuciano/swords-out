using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private GameObject xPrefab;
    [SerializeField] private PlayerControl player;

    private Enemy enemyFoe;
    private GameObject[,] visualGrid;
    private GameObject[,] xGrid;

    int x, y;

    private void Awake()
    {
        visualGrid = new GameObject[2, 3];
        xGrid = new GameObject[2, 3];
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyFoe = GetComponent<MainGameController>().enemy;
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        dyeGrid();
    }




    //las coordenadas estan ajustadas para que se entienda como una matriz
    //al colocar los cuadros en pantalla las coordenadas pueden ser algo distintas para que sea logico a la vista
    void CreateGrid()
    {

        for (int i = 0; i < 2; i++)
            for(int j = 0; j < 3; j++)
            {
                GameObject cross = Instantiate(xPrefab);
                xGrid[i, j] = cross;
                xGrid[i, j].transform.position = new Vector3(-5, -5, 0);
            }

        for(int i = 0; i < 2; i++)
            for(int j = 0; j < 3; j++)
            {
                GameObject block = Instantiate(blockPrefab);
                visualGrid[i, j] = block;
                if (player.getHitbox().isPlayerAtCoords(i, j))
                    visualGrid[i, j].GetComponent<SpriteRenderer>().color = Color.green;
                visualGrid[i, j].transform.position = new Vector3(j,-i,0);
            }
    }

    void dyeGrid()
    {
        for(int i = 0; i < 2; i++)
            for (int j = 0; j < 3; j++)
            {
                if (player.getHitbox().isPlayerAtCoords(i, j))
                {
                    if (!player.canMove()) visualGrid[i, j].GetComponent<SpriteRenderer>().color = Color.yellow;
                    else visualGrid[i, j].GetComponent<SpriteRenderer>().color = Color.green;
                }
                else visualGrid[i, j].GetComponent<SpriteRenderer>().color = Color.white;

                
            }

        if (enemyFoe.currentAttack.currentHit == Attack.Hit.noHit)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 3; j++)
                {
                    xGrid[i, j].transform.position = new Vector3(-5, -5, 0);
                }
        }
        else
        for (int i = 0; 
            i < enemyFoe.getHittedBlocks().Length;
            i++)
        {
            x = enemyFoe.getHittedBlocks()[i].x;
            y = enemyFoe.getHittedBlocks()[i].y;
            //Debug.Log(x);
            //Debug.Log(y);

            xGrid[x, y].transform.position = new Vector3(y, -x, 0);
        }
    }
}
