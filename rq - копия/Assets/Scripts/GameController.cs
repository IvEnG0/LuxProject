//sq-kopy

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{	public AudioClip audPoval;
	public bool paused=false;
	public int Score=0;
	public GUIText scort;
	public GUIText combo;
	public GUIText record;
	public int count;
	public int MobCount=0;
	public int FragCount=0;
	public GameObject[] hurts;//изображение сердечек
	public GameObject LeftEnemyContr;
	public GameObject LeftEnemy2Contr;
	public GameObject RightEnemyContr;
	public GameObject RightEnemy2Contr;
	public GameObject LeftEnemy3Contr;
	public GameObject RightEnemy3Contr;
	public GameObject player;
	public Animator anim;
	/// <summary>
	/// /оружие////
	/// </summary>
	public GameObject surican;
	public GameObject axe;//топор
	public GameObject fireBall;
	private GameObject[] suricanObjects = new GameObject[3];
	private GameObject[] axeObjects = new GameObject[3];
	private GameObject fireBallObjects;
	/// <summary>
	/// //оружие///
	/// </summary>
	private float time = 2f, spawnTime = 1f;//время через которое должны появляться новые враги
	private int direct = 0;
	private Enemy enem;
	private BackgroundController[] backgr = new BackgroundController[1];
	private float step = 0.5f;
	private bool isFacingRight=true;
	private bool clik=false;
	private bool combostarted=false;
	public bool comboplay=false;
	public int beforeBossFrags=8;
	public int firstRab=6;
	private GameObject Boss;
	public int proba;
	private int rand=0;
	
	void Start()
	{record.text = "Record "+PlayerPrefs.GetInt ("Player Score").ToString ();
		anim = player.GetComponent<Animator> ();
		//Time.timeScale = 0; Пауза
		//Делаем настройки качества графона
		
		QualitySettings.SetQualityLevel (3);
		//Убираем панельки навигации и с часами в ведрах 4.4+
		if (Application.platform == RuntimePlatform.Android) {
			using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					obj_Activity.Call ("ActivateImmersiveMode");
				}}}
		
		//спауним сердечка
		// for (int i = 0; i < hurts.Length; i++)
		//     hurts[i] = (GameObject)Instantiate(hurts[0], new Vector3(6f - i * 1f, 2f, 0f), new Quaternion(0f, 0f, 0f, 0f));
		// PlayerContr = GameObject.FindGameObjectWithTag("Player");
		InvokeRepeating("Spawn", time, spawnTime);
		
		///фон////////////////////////////////////////////////////////////////
		GameObject[] back = GameObject.FindGameObjectsWithTag("Background");     
		///////////////////////////9
		for (int i = 0; i < back.Length; i++)
		{
			backgr[i] = back[i].GetComponent<BackgroundController>();
		}
		//////////////////////////////////////////////////////////////////////
	}	
	
	public void Update()
	{
		if (GameObject.Find ("Player") == null)
		{return;
		}
		
		
		if (Score > PlayerPrefs.GetInt ("Player Score")) {
			PlayerPrefs.SetInt("Player Score", Score);
			PlayerPrefs.Save ();
		}
		
		
		PlayerHP php = GameObject.Find("Player").gameObject.GetComponent<PlayerHP>();
		//выбираем управление в зависимости от платформы
		if (Application.platform == RuntimePlatform.Android) 
		{ float cor = 0;
			if (FragCount == beforeBossFrags && IsInvoking("Combo") == false) { InvokeRepeating("Combo", 4.3f, 0.5F); return; }	
			if(IsInvoking("Combo")==true){
				if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended ){
					
					cor = Input.GetTouch (0).position.x;//Input.acceleration.x;
					
					
					if ((cor < (Screen.width / 2)) && clik==false) {count++; if(count>10){count=10;} else if(count<0){count=0;};}
					else if((cor > (Screen.width / 2))&& clik==true){count++; if(count>10){count=10;} else if(count<0){count=0;};}
					else if((cor > (Screen.width / 2))&& clik==false){count--; if(count>10){count=10;} else if(count<0){count=0;};}
					else if((cor < (Screen.width / 2))&& clik==true){count--;} if(count>10){count=10;} else if(count<0){count=0;};}}
			
			if(comboplay==true)
			{return;};
			
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && GameObject.Find("Player").GetComponent<PlayerHP>().ch!=false){
				cor = Input.GetTouch (0).position.x;//Input.acceleration.x;
				if (cor < (Screen.width / 2)) {	
					if(isFacingRight == true)
					{
						Flip ();
					}
					if(MobCount == (beforeBossFrags+1))
						Flip ();
					anim.Rebind();
					GameObject.Find ("Main Camera").gameObject.GetComponent<AudioSource> ().PlayOneShot(audPoval);
					//int rand = proba;
					if(Score%10!=0 || Score == 0){
						rand=Random.Range(1,5);
						switch (rand)
						{
						case 1: anim.Play("Hit");
							break;
						case 2:
							anim.Play ("MKick2");
							break;
						case 3: anim.Play("MKick3");
							break;
						case 4: anim.Play("MKick4");
							break;
							
						}}
					else if (Score != 0){
						comboplay=true;
						rand=Random.Range(0,3);
						switch(rand){
						case 0: anim.Play("SuricanAxe");
							ShotSurican();
							break;
						case 1: anim.Play("FireBall");
							break;
						case 2: anim.Play("SuricanAxe");
							ShotAxe();
							break;
						}}
					GameObject[] left = GameObject.FindGameObjectsWithTag ("LeftEnemy");
					if(Boss == null)
					{
						KillEnemy (left);
					}
					else{
						KillBoss (Boss);						
					}
				} 
				else {
					if(isFacingRight == false)
					{
						Flip ();
					}
					if(MobCount == (beforeBossFrags+1))
						Flip ();
					anim.Rebind();
					GameObject.Find ("Main Camera").gameObject.GetComponent<AudioSource> ().PlayOneShot(audPoval);
					//int rand = proba;
					if(Score%10!=0 || Score == 0){
						rand=Random.Range(1,5);
						switch (rand)
						{
						case 1: anim.Play("Hit");
							break;
						case 2:
							anim.Play ("MKick2");
							break;
						case 3: anim.Play("MKick3");
							break;
						case 4: anim.Play("MKick4");
							break;
							
						}}
					else if (Score != 0){
						comboplay=true;
						rand=Random.Range(0,3);
						switch(rand){
						case 0: anim.Play("SuricanAxe");
							ShotSurican();
							break;
						case 1: anim.Play("FireBall");
							break;
						case 2: anim.Play("SuricanAxe");
							ShotAxe();
							break;
						}}
					GameObject[] right = GameObject.FindGameObjectsWithTag ("RightEnemy");
					if(Boss == null)
					{
						KillEnemy (right);
					}
					else{
						KillBoss (Boss);						
					}}}
		}
		else
		{
			if (FragCount == beforeBossFrags && IsInvoking("Combo") == false) { InvokeRepeating("Combo", 4.3f, 0.5F); return; }	
			if(IsInvoking("Combo")==true){
				
				if (Input.GetMouseButtonDown (0) && clik==false) {count++; if(count>10){count=10;} else if(count<0){count=0;};}
				else if(Input.GetMouseButtonDown (1)&& clik==true){count++; if(count>10){count=10;} else if(count<0){count=0;};}
				else if(Input.GetMouseButtonDown (1)&& clik==false){count--; if(count>10){count=10;} else if(count<0){count=0;};}
				else if(Input.GetMouseButtonDown (0)&& clik==true){count--; if(count>10){count=10;} else if(count<0){count=0;};}
			}
			if(comboplay==true)
			{return;};
			//если враг слева, - левую кнопку мыши
			if (Input.GetMouseButtonDown (0)&& GameObject.Find("Player").GetComponent<PlayerHP>().ch!=false) 
			{
				if(isFacingRight == true)
				{
					Flip ();
				}
				if(MobCount == (beforeBossFrags+1))
					Flip ();
				anim.Rebind();
				GameObject.Find ("Main Camera").gameObject.GetComponent<AudioSource> ().PlayOneShot(audPoval);
				//int rand = proba;
				if(Score%10!=0 || Score == 0){
					rand=Random.Range(1,5);
					switch (rand)
					{
					case 1: anim.Play("Hit");
						break;
					case 2:
						anim.Play ("MKick2");
						break;
					case 3: anim.Play("MKick3");
						break;
					case 4: anim.Play("MKick4");
						break;
						
					}}
				else if (Score != 0){
					comboplay=true;
					rand=Random.Range(0,3);
					switch(rand){
					case 0: anim.Play("SuricanAxe");
						ShotSurican();
						break;
					case 1: anim.Play("FireBall");
						break;
					case 2: anim.Play("SuricanAxe");
						ShotAxe();
						break;
					}}
				GameObject[] left = GameObject.FindGameObjectsWithTag ("LeftEnemy");
				if(Boss == null)
				{
					KillEnemy (left);
				}
				else{
					KillBoss (Boss);
				}
			}
			if (Input.GetMouseButtonDown (1) && GameObject.Find("Player").GetComponent<PlayerHP>().ch!=false) { //если враг справа, - правую кнопку мыши
				if(isFacingRight == false )
				{
					Flip ();
				}
				if(MobCount == (beforeBossFrags+1))
					Flip ();
				anim.Rebind();
				GameObject.Find ("Main Camera").gameObject.GetComponent<AudioSource> ().PlayOneShot(audPoval);
				//int rand = proba;
				if(Score%10!=0 || FragCount == 0){
					rand=Random.Range(1,5);
					switch (rand)
					{
					case 1: anim.Play("Hit");
						break;
					case 2:
						anim.Play ("MKick2");
						break;
					case 3: anim.Play("MKick3");
						break;
					case 4: anim.Play("MKick4");
						break;
						
					}}
				else if (Score != 0){
					comboplay=true;
					rand=Random.Range(0,3);
					switch(rand){
					case 0: anim.Play("SuricanAxe");
						ShotSurican();
						break;
					case 1: anim.Play("FireBall");
						break;
					case 2: anim.Play("SuricanAxe");
						ShotAxe();
						break;
					}}
				GameObject[] right = GameObject.FindGameObjectsWithTag ("RightEnemy");
				if(Boss == null)
				{
					KillEnemy (right);
				}
				else{
					KillBoss (Boss);
				}}}
		MoveSurican();
		MoveAxe();
		MoveFireball();
	}
	
	private void MoveSurican()
	{
		if (suricanObjects == null) return;
		//Debug.Log("!!MoveSurican!!");
		float delta = 0.25f;
		for (int i = 0; i < suricanObjects.Length; i++)
			if (suricanObjects[i] != null)
		{
			MoveWeapon(suricanObjects[i], delta);
		}
	}
	
	private void MoveAxe()
	{
		if (suricanObjects == null) return;
		//Debug.Log("!!MoveAxe!!");
		float delta = 0.25f;
		for (int i = 0; i < axeObjects.Length; i++)
			if (axeObjects[i] != null)
		{
			MoveWeapon(axeObjects[i], delta);
		}
	}
	
	void MoveFireball()
	{
		if (suricanObjects == null) return;
		// Debug.Log("!!MoveFireball!!");
		float delta = 0.25f;
		if (fireBallObjects != null)
			MoveWeapon(fireBallObjects, delta);
	}
	
	void MoveWeapon(GameObject weaponObject, float delta)
	{
		if (weaponObject.transform.position.x == 0)
		{
			if (isFacingRight)
				weaponObject.transform.position = new Vector3(weaponObject.transform.position.x + delta, weaponObject.transform.position.y, 0f);
			else if (!isFacingRight)
				weaponObject.transform.position = new Vector3(weaponObject.transform.position.x - delta, weaponObject.transform.position.y, 0f);
		}
		else if (weaponObject.transform.position.x > 0)
			weaponObject.transform.position = new Vector3(weaponObject.transform.position.x + delta, weaponObject.transform.position.y, 0f);
		else if (weaponObject.transform.position.x < 0)
			weaponObject.transform.position = new Vector3(weaponObject.transform.position.x - delta, weaponObject.transform.position.y, 0f);
		
	}
	
	private void ShotSurican()
	{
		for (int i = 0; i < suricanObjects.Length; i++)
			if (suricanObjects[i] == null)
		{
			suricanObjects[i] = (GameObject)Instantiate(surican, new Vector3(transform.position.x, transform.position.y, 0f), new Quaternion(0f, 0f, 0f, 0f));
			break;
		}
	}
	
	public void ShotFireBall()
	{
		float xpos = transform.position.x;
		if (isFacingRight)
			xpos = transform.position.x + 1;
		else if (!isFacingRight)
			xpos = transform.position.x - 1;
		fireBallObjects = (GameObject)Instantiate(fireBall, new Vector3(xpos, transform.position.y, 0f), new Quaternion(0f, 0f, 0f, 0f));
	}
	
	private void ShotAxe()
	{
		Debug.Log("axe" + axe);
		for (int i = 0; i < axeObjects.Length; i++)
			if (axeObjects[i] == null)
		{
			axeObjects[i] = (GameObject)Instantiate(axe, new Vector3(transform.position.x, transform.position.y, 0f), new Quaternion(0f, 0f, 0f, 0f));
			break;
		}
	}
	
	
	private void Flip()
	{
		if (Score < beforeBossFrags) {
			isFacingRight = !isFacingRight;
			//получаем размеры персонажа
			Vector3 theScale = player.transform.localScale;
			//зеркально отражаем персонажа по оси Х
			theScale.x *= -1;
			//задаем новый размер персонажа, равный старому, но зеркально отраженный
			player.transform.localScale = theScale;
		}
		else {
			Boss = GameObject.FindGameObjectWithTag("LeftEnemy");
			if(Boss == null && isFacingRight == false)
			{
				isFacingRight = !isFacingRight;
				//получаем размеры персонажа
				Vector3 theScale = player.transform.localScale;
				//зеркально отражаем персонажа по оси Х
				theScale.x *= -1;
				//задаем новый размер персонажа, равный старому, но зеркально отраженный
				player.transform.localScale = theScale;
				Boss = GameObject.FindGameObjectWithTag("RightEnemy");
			}
			else if(Boss == null && isFacingRight == true)
			{
				Boss = GameObject.FindGameObjectWithTag("RightEnemy");
			}
			else if(Boss != null && isFacingRight == true)
			{
				isFacingRight = !isFacingRight;
				//получаем размеры персонажа
				Vector3 theScale = player.transform.localScale;
				//зеркально отражаем персонажа по оси Х
				theScale.x *= -1;
				//задаем новый размер персонажа, равный старому, но зеркально отраженный
				player.transform.localScale = theScale;
			}
		}
	}
	
	void Spawn() //спауним врагов
	{
		if (GameObject.Find ("Player") == null) {
			return;
		}
		PlayerHP php = GameObject.Find ("Player").gameObject.GetComponent<PlayerHP> ();
		if (php == null)
			return;
		if (php.curHP <= 0) {
			CancelInvoke ();
		}				
		if (MobCount < firstRab && FragCount < firstRab) {
			switch (Random.Range (1, 3)) {
			case 1:
				Instantiate (LeftEnemyContr, LeftEnemyContr.transform.position, LeftEnemyContr.transform.rotation);
				break;
			case 2:
				Instantiate (RightEnemyContr, RightEnemyContr.transform.position, RightEnemyContr.transform.rotation);
				break;			
			}
		}
		if (MobCount < beforeBossFrags && FragCount < beforeBossFrags && FragCount >= firstRab) {
			switch (Random.Range (1, 5)) {
			case 1:
				Instantiate (LeftEnemy2Contr, LeftEnemy2Contr.transform.position, LeftEnemy2Contr.transform.rotation);
				break;
			case 2:
				Instantiate (RightEnemy2Contr, RightEnemy2Contr.transform.position, RightEnemy2Contr.transform.rotation);
				break;
			case 3:
				Instantiate (RightEnemyContr, RightEnemyContr.transform.position, RightEnemyContr.transform.rotation);
				break;
			case 4:
				Instantiate (LeftEnemyContr, LeftEnemyContr.transform.position, LeftEnemyContr.transform.rotation);
				break;
			}
		}
		if (FragCount >= beforeBossFrags && MobCount != (beforeBossFrags+1)) {
			switch (Random.Range (1, 3)) {
			case 1:
				Instantiate (LeftEnemy3Contr, LeftEnemy3Contr.transform.position, LeftEnemy3Contr.transform.rotation);
				break;
			case 2:
				Instantiate (RightEnemy3Contr, RightEnemy3Contr.transform.position, RightEnemy3Contr.transform.rotation);
				break;			
			}
		}
	}
	
	GameObject Nearest(GameObject[] enemies)//нахождение ближайшего врага, х=-1 или 1 , -1 - враг слева, 1- враг справа
	{
		if (enemies.Length == 0) return null;
		else if (enemies.Length == 1)
		{
			enem = enemies[0].GetComponent<Enemy>();
			if (enem.OnTrigger())
				return enemies[0];
			else return null;
		}
		enem = enemies[0].GetComponent<Enemy>();
		direct = enem.GetDirection();
		GameObject min_pos = null;
		for (int i = 0; i < enemies.Length; i++)
		{        
			enem = enemies[i].GetComponent<Enemy>();
			if (enem.OnTrigger() && min_pos == null)
				min_pos = enemies[i];
			if (min_pos != null && min_pos.transform.position.x * direct < enemies[i].transform.position.x * direct &&
			    enem.OnTrigger())
			{
				min_pos = enemies[i];
			}
		}
		return min_pos; // ближайший враг
	}
	
	public void KillEnemy(GameObject[] gameO)
	{
		GameObject enemiToKill = Nearest(gameO);	
		if (enemiToKill == null) return;
		MobHP mhp = enemiToKill.GetComponent<MobHP>();
		if (mhp.ch2 == true) {
			if(enemiToKill.gameObject.layer!=9){mhp.curHP -= 100;};
			enemiToKill.GetComponent<Animator> (). Play ("Hited");
		}       	
		GameObject.Find ("Main Camera").gameObject.GetComponent<CameraController> ().shake = 0.05f;
	}
	
	
	public void KillBoss(GameObject enemiToKill)
	{		
		if (enemiToKill == null) return;
		enem = Boss.GetComponent<Enemy>();
		if (enem.OnTrigger () == false) {
			return;}
		MobHP mhp = enemiToKill.GetComponent<MobHP>();
		if (mhp.ch2 == true) {
			enemiToKill.GetComponent<Animator> (). Rebind();
			if(enemiToKill.gameObject.layer!=9){mhp.curHP -= 100;};
			enemiToKill.GetComponent<Animator> (). Play ("Hited");
		}
		GameObject.Find ("Main Camera").gameObject.GetComponent<CameraController> ().shake = 0.05f;
	}
	
	public void ScrollEnemies(int direction)
	{
		if(direction == 1)
		{direction=-1;
			GameObject[] right = GameObject.FindGameObjectsWithTag("LeftEnemy");
			MoveEnemies(right,  direction);
		}
		else if (direction == -1)
		{
			direction=1;
			GameObject[] left = GameObject.FindGameObjectsWithTag("RightEnemy");
			MoveEnemies(left, direction);
		}        
	}
	
	void Combo(){
		if (Random.Range (0, 10)%2 == 0) {
			combo.text="Left " + count.ToString();
			clik=false;				
		} 
		else {
			combo.text="Right " + count.ToString();
			clik=true;				
		}
		if (count >= 10) {
			GameObject zay=GameObject.FindGameObjectWithTag ("LeftEnemy");
			if(zay==null){zay=GameObject.FindGameObjectWithTag ("RightEnemy");}
			GameObject.Find ("Player").gameObject.GetComponent<Animator>().Play("Combo");
			comboplay=true;
			zay.GetComponent<Animator>().Play ("Hited 0");
			zay.GetComponent<MobHP>().curHP-=340;
			count=0;
			return;
		}
	}
	
	void MoveEnemies(GameObject[] objenem, int direction)
	{
		if (objenem == null) return;
		for (int i = 0; i < objenem.Length; i++)
		{
			enem = objenem[i].GetComponent<Enemy>();
			enem.transform.position = new Vector3(enem.transform.position.x + direction * step, enem.transform.position.y, enem.transform.position.z);
		}
	}
}
