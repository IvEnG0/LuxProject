using UnityEngine;
using System.Collections;

public class Surican : MonoBehaviour {


    public GameObject surican;
    private GameObject suricanObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        
            this.GetComponent<Animator>().Play("carr");

        if (suricanObject)
            suricanObject.transform.position = new Vector3(suricanObject.transform.position.x + 0.2f, suricanObject.transform.position.y, 0f);

	}

    void AnimationFunc()
    { 
     
         suricanObject =   (GameObject) Instantiate(surican, new Vector3(transform.position.x + 2, transform.position.y, 0f), new Quaternion(0f, 0f, 0f, 0f));
    }
}
