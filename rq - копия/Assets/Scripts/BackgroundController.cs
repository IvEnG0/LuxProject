using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

   // private Vector3 transf;
    public float sizeToMove;
    private Vector3 transf;
    public float halfWidth = 5f;

    void Start()
    {
        transf = transform.position;
    }

    public void ScrollBackground(int direction)
    {
     transform.position = Vector3.right * direction * sizeToMove + transform.position;   
    }
    
    void Update()
    {
        if (transform.position.x < -12f)//лево
            transform.position = new Vector3(12, transform.position.y, transform.position.z);
        else if (transform.position.x > 12 )//право
            transform.position = new Vector3(-12f, transform.position.y, transform.position.z);
    }
}