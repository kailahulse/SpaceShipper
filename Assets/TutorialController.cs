using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner.SpawnBlueEnemies(1);
    }
}
