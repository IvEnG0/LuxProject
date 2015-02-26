using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered.");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Triggered.");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Triggered.");
    }

	void ScoreRank()
	{
		Debug.Log("Score");
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collision entered");
    }
}
