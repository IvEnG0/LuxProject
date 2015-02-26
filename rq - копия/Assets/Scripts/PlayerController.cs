//sq-kopy

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "RightEnemy" || coll.gameObject.tag == "LeftEnemy")
		{coll.gameObject.GetComponent<MobHP>().drive = false;
			coll.gameObject.GetComponent<Enemy>().direction = 0;
			coll.gameObject.GetComponent<Animator>().Play ("Eat") ;
            //Destroy(coll.gameObject);
        }
    }

    public void ShotFireBall()
    {
		GameObject gamecon = GameObject.FindGameObjectWithTag("GameController");
		if (gamecon == null) {
			gamecon = GameObject.FindGameObjectWithTag ("Lvl2GameController");
			gamecon.GetComponent<Lvl2GameController> ().ShotFireBall ();
		} else {
			gamecon.GetComponent<GameController>().ShotFireBall();}
		
	}

}
