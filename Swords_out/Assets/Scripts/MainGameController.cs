using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public const float TIME_UNIT = 1 / 60f; //Unidad de tiempo minima (pensando un juego base de 60 fps) ¿Se puede aplicar a todos los scipts?¿Cómo?

    [SerializeField] private PlayerControl player;
    [SerializeField] private GameObject[] enemyPrefabs;
    public Enemy enemy;

    private bool checkCombat;
    

    private void Awake()
    {
        enemy = Instantiate(enemyPrefabs[0]).GetComponent<Enemy>();
        checkCombat = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (checkCombat) checkEnemyHit();
    }

    private void checkEnemyHit()
    {
        foreach (Vector2Int block in enemy.getHittedBlocks())
        {
            if (player.isPlayerAtCoords(block.x, block.y))
            {
                if (!checkPlayerDefense())
                {
                    StartCoroutine(player.getHit());
                    StartCoroutine(waitForCheckCombat(60f)); //hay que cambiar esto si o si
                    break;
                }
                else
                {
                    //chequea y ejecuta el parry
                    StartCoroutine(checkForParry());
                    StartCoroutine(waitForCheckCombat(60f));
                    break;
                }
                
            }
        }
    }

    private IEnumerator waitForCheckCombat(float frames)
    {
        checkCombat = false;
        yield return new WaitForSeconds(TIME_UNIT * frames);
        checkCombat = true;
    }
    private IEnumerator checkForParry()
    {
        if (player.getTimeShielding() < (TIME_UNIT * 60f))
        {
            //sabemos que en este frame se esta escudando puesto que si no no se ejecutaria esta funcion
            float i = 0f;
            yield return null;
            while (player.isPlayerShielding() && i < TIME_UNIT * 60f)
            {
                i += Time.deltaTime;
                yield return null;
            }

            if (i < TIME_UNIT * 120f) doParry();
            
        }
        else yield return null;
    } 

    private bool checkPlayerDefense()
    {
        if (!player.isPlayerShielding()) return false;
        if ((player.getShieldDirection() + enemy.getCurrentHitDirection()) == Vector2Int.zero) return true;
        return false;
    }
    private void doParry()
    {
        Debug.Log("Parry");
        enemy.getParried();
    }
}
