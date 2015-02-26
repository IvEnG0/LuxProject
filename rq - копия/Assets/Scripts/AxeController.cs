using UnityEngine;
using System.Collections;

public class AxeController : MonoBehaviour {

    static int countKilledEnemies = 0;// топор может убить одновременно 2 врага
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GameController")
            Debug.Log("GameController");
        if (other.tag == "LeftEnemy" || other.tag == "RightEnemy" || other.tag == "GameController")
        {
            countKilledEnemies++;
        }
        if (countKilledEnemies >= 2)
        {       
          Destroy(gameObject);
          countKilledEnemies = 0;
        }
    }
}
