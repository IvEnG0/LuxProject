using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class gameOverpause : MonoBehaviour
{
	private GUISkin skin1;
	public ScriptableObject sc;

	public bool addc=false;
	public ScriptableObject other;
	public int count=0;
	void Start(){
		skin1 = Resources.Load("newsk")as GUISkin;//n2 = Resources.Load ("n2") as GUISkin;
	}
	void Update()
	{
	
		if (Input.GetKeyDown (KeyCode.Escape))
			{
			if (!GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused || !GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController>().paused) 
				{
				Time.timeScale = 0.0f;
				AudioListener.pause = true;
				if(GameObject.Find ("GameController").gameObject.GetComponent<GameController>()!=null){
				GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused= true;
				}
				else{GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController>().paused= true;}
					transform.gameObject.AddComponent<giu1>();
		   		    
		     	} 
				else {
			    Time.timeScale=1.0f;
				AudioListener.pause=false;
			//	Destroy(gameObject.AddComponent<giu1> ());
		

				Component.Destroy(GameObject.Find ("Pause").gameObject.GetComponent<giu1>());

				if(GameObject.Find ("GameController").gameObject.GetComponent<GameController>()!=null){
					GameObject.Find ("GameController").gameObject.GetComponent<GameController>().paused = false;}
				else{GameObject.Find ("GameController").gameObject.GetComponent<Lvl2GameController>().paused = false;}
					}
			}
	}	
	}