using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompleteL : MonoBehaviour {
	//public GUIText compl="Level Complete";
	// Use this for initialization
	void Start () {
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Player").gameObject.GetComponent<PlayerHP> ().BossDie == true) {
			OnGUI();
		}
	}
	/*	if (GameObject.Find ("Player").gameObject.GetComponent<PlayerHP> ().dieBoss == false) {
			enabled = false;
		}*/

	//}
		void OnGUI()
		{
		GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (Screen.width * 0.2f,
		         Screen.height * 0.125f,
		         Screen.width * 0.65f,
		         Screen.height * 0.2f),
			"Resume"
		);
		}
}
