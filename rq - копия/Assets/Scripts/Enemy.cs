//sq-kopy
using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour {

	private float speedcoef=1;
	public bool dead = false;
    private bool onTrigger = false;
    public int direction;//определяет в какую сторону будет двигаться враг
	void RunAn(){
		if (GameObject.Find ("Player") == null) {
			return;}
		if(GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ()!=null){
			if (GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ().anim != null && GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ().comboplay!=true ) 
				if (GameObject.Find ("Player").gameObject.GetComponent<PlayerHP> ().ch != false) {
			GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ().anim.Play ("Hited");
				} 
		}
		else{
			if (GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().anim != null && GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().comboplay!=true) 
			if (GameObject.Find ("Player").gameObject.GetComponent<PlayerHP> ().ch != false) {
				GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().anim.Play ("Hited");
			} 
		}
	}

	void BossDieFunc(){
		GameObject.Find ("Player").gameObject.GetComponent<PlayerHP>().BossDie = true;
		Debug.Log ("URA");
		if(GameObject.Find("Giu").gameObject.GetComponent<rer>().enabled==true) {
		GameObject.Find ("Ded").gameObject.GetComponent<SYKA> ().enabled = false;
		}
		if(GameObject.Find("Giu").gameObject.GetComponent<rer>().enabled==false) {
			GameObject.Find ("Ded").gameObject.GetComponent<SYKA> ().enabled = true;}

	}



	void Tarzan(){
		if (gameObject.GetComponent<MobHP> ().drive==false) {
			gameObject.GetComponent<Animator> ().Play ("Eat");	}
	}

	void Stop(){
		gameObject.GetComponent<Enemy> ().direction = 0;}

	void Run(){

		if (gameObject.GetComponent<Enemy> ().tag == "LeftEnemy" && gameObject.GetComponent<MobHP> ().drive==true) {
			  gameObject.GetComponent<Enemy> ().direction = 1;
				}
		else if( gameObject.GetComponent<MobHP> ().drive==true){gameObject.GetComponent<Enemy> ().direction = -1;
				}}

	void ScoreCal(){
		if(GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ()!=null){
			GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ().Score+=gameObject.GetComponent<MobHP>().ScoreMultiplyer;
		GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ().scort.text="Score " + GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ().Score.ToString();	
			GameObject.Find("GameController").gameObject.GetComponent<Lvl2GameController>().FragCount+=1;
		}
		else{
			GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().Score+=gameObject.GetComponent<MobHP>().ScoreMultiplyer;
			GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().scort.text="Score " + GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().Score.ToString();	
			GameObject.Find("GameController").gameObject.GetComponent<GameController>().FragCount+=1;
		}
		}

    void Update()
	{
		if(GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ()!=null){
			speedcoef=Mathf.Sqrt(GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ().FragCount)/6+1;
		}
		else{
			speedcoef=Mathf.Sqrt(GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().FragCount)/6+1;

		}
		//враг перемещается
		transform.position = new Vector3(transform.position.x + speedcoef*direction * Time.deltaTime, transform.position.y, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            onTrigger = true; //бот дошел до игрока
        else if (other.tag == "Surican" || other.tag == "FireBall" || other.tag == "Axe")
        {
            gameObject.GetComponent<Animator>().Play("Death");
			gameObject.GetComponent<MobHP>().curHP=0;
            //Destroy(gameObject, 0.45f);
        }
    }

    public bool OnTrigger()
    {
        return onTrigger;
    }

    public int GetDirection()
    {
        return direction;
    }
}
