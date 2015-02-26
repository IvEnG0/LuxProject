//sq=kopy
using UnityEngine;

public class PlayerHP : MonoBehaviour
{public bool ch=true;
	public bool BossDie=false;
	public bool ov = false;
	public GUIText HPPLayer;
	public AudioClip loose;
	public float maxHP = 100; //Максимум ХП
	public float curHP = 100; //Текущее ХП
	private GameController gc;

	
	private void Awake()
	{		
		if (maxHP < 1) maxHP = 1; //если максимальное хп задано менее единицы - ставим единицу
   
	}

	public void Comboplay(){
		if (GameObject.Find ("GameController").gameObject.GetComponent<GameController> () != null) {
			GameObject.Find ("GameController").gameObject.GetComponent<GameController> ().comboplay = false;
		} else {GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController> ().comboplay = false;
		}
	}

	public void ChangeHP(float adjust) //метод корректировки ХП моба
	{
		if ((curHP + adjust) > maxHP) curHP = maxHP;//если сумма текущего ХП и adjust в результате более, чем максимальное хп - текущее ХП становится равным максимальному
		else curHP += adjust; //иначе просто добавляем adjust
	}
	
	private void Update()

	{ 	//gameObject.renderer.material.color = Color.Lerp(MaxDamageColor, MinDamageColor, curHP / maxHP); //Лерпим цвет моба по заданным в начале цветам. В примере: красный - моб почти полностью убит, синий - целый.
		if (GameObject.Find ("Player") == null) {
			return;}
		HPPLayer.text = "HP: " + curHP.ToString ();
      
		if (curHP <= 0) //если ХП упало в ноль или ниже
		{			
			GameObject[] right = GameObject.FindGameObjectsWithTag ("RightEnemy");
			for (int i = 0; i < right.Length; i++)
			{        
				Enemy enem = right[i].GetComponent<Enemy>();
				enem.direction=0;
			}
			right = GameObject.FindGameObjectsWithTag ("LeftEnemy");
			for (int i = 0; i < right.Length; i++)
			{        
				Enemy enem = right[i].GetComponent<Enemy>();
				enem.direction=0;
			}

			if(ch!=false){
			GameObject.Find ("Player").gameObject.GetComponent<Animator> ().Play ("GameOver");
			ch=false;
			//GameObject.Find ("Player").gameObject.GetComponent<BoxCollider2D> ().enabled=false;
			//GameObject.Find ("Player").gameObject.GetComponent<Rigidbody2D> ().isKinematic=true;
			GameObject.Find ("Main Camera").gameObject.GetComponent<AudioSource> ().Pause ();
				GameObject.Find ("Main Camera").gameObject.GetComponent<AudioSource> ().PlayOneShot(loose);			
				GameObject.Find ("Die").gameObject.GetComponent<SpriteRenderer>().enabled = true;
				Destroy(gameObject, 0.8f);
				ov=true;
				//Time.timeScale = 0; 
				}
			//Die ();
			//Application.LoadLevel("Scene01");
			//Destroy(gameObject, 0.45f); //удаляем себя
		}
	}


}