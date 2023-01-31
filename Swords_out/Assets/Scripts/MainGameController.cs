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
                StartCoroutine(player.getHit());
                checkCombat = false;
                StartCoroutine(waitForCheckCombat(60f)); //hay que cambiar esto si o si
                break;
            }
        }
    }

    private IEnumerator waitForCheckCombat(float frames)
    {
        yield return new WaitForSeconds(TIME_UNIT * frames);
        checkCombat = true;
    }
}
