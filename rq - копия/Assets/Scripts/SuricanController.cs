using UnityEngine;
using System.Collections;

public class SuricanController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GameController")
            Debug.Log("GameController");
        if (other.tag == "LeftEnemy" || other.tag == "RightEnemy" || other.tag == "GameController")
            Destroy(gameObject);
    }
}
