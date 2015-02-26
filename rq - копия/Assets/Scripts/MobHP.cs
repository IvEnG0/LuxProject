//qr-kopy
using UnityEngine;

public class MobHP : MonoBehaviour
{public bool ch2=true;
	public int ScoreMultiplyer = 1;
	public float maxHP = 100; //Максимум ХП
	public float curHP = 100; //Текущее ХП
	public int damage = 25;
	public bool drive=true;
    private GameObject HpPicEnem;
    private float maxHPpic;
	//public Color MaxDamageColor = Color.red; //цвета полностью побитого
	//public Color MinDamageColor = Color.blue; //и целого моба

	private void Awake()
	{
		if(GameObject.Find("GameController").gameObject.GetComponent<Lvl2GameController>()!=null)
		{
		GameObject.Find("GameController").gameObject.GetComponent<Lvl2GameController>().MobCount+=1;}
		else{
			GameObject.Find("GameController").gameObject.GetComponent<GameController>().MobCount+=1;
		}
		if (maxHP < 1) maxHP = 1; //если максимальное хп задано менее единицы - ставим единицу
        
        foreach (var ob in this.GetComponentsInChildren<Transform>())
            HpPicEnem = ob.gameObject;
        maxHPpic = HpPicEnem.transform.localScale.x;
	}

	void KickHP(){
		if (GameObject.Find ("Player") == null) {
			return;}
		PlayerHP php = GameObject.Find("Player").gameObject.GetComponent<PlayerHP>();
        if (php != null)
            php.curHP -= damage;
           
	}



	public void ChangeHP(float adjust) //метод корректировки ХП моба
	{
		if ((curHP + adjust) > maxHP) curHP = maxHP;//если сумма текущего ХП и adjust в результате более, чем максимальное хп - текущее ХП становится равным максимальному
		else curHP += adjust; //иначе просто добавляем adjust
	}
	
	private void Update()
	{
        HpPicEnem.transform.localScale = new Vector3(maxHPpic * curHP / maxHP, HpPicEnem.transform.localScale.y, 0);
		//gameObject.renderer.material.color = Color.Lerp(MaxDamageColor, MinDamageColor, curHP / maxHP); //Лерпим цвет моба по заданным в начале цветам. В примере: красный - моб почти полностью убит, синий - целый.
		if (curHP <= 0 && ch2!=false) { //если ХП упало в ноль или ниже
			ch2=false;
						gameObject.GetComponent<Enemy> ().direction = 0;
						gameObject.GetComponent<Animator> ().Play ("Death");		
						Destroy (gameObject, 0.45f); //удаляем себя
				}	}	

}