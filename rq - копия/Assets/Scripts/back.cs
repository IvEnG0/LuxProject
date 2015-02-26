using UnityEngine;
using System.Collections;

public class back : MonoBehaviour {
	private GUISkin skin1;
	public string levl;
	// Use this for initialization
	void Start () {
		skin1 = Resources.Load("newsk")as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.LoadLevel(levl);
		}
	}
}