using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    GameObject p;
    public float distance;
    public int followStatex1 =0;
    public int followStatey1 = 0;
    public int followStatex2 = 1;
    public int followStatey2 = 1;
    private float f = .015f;
	// Use this for initialization
	void Start () {
        p = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ( followStatex1 == 1 && followStatey1 == 1 && followStatey2 == 1 && followStatex2 == 1){
            //transform.position = new Vector3(Input.GetAxisRaw("Horizontal") * p.GetComponent<Player>().moveSpeed , Input.GetAxisRaw("Vertical") * p.GetComponent<Player>().moveSpeed , distance);
            transform.position = Vector3.Lerp(transform.position,new Vector3(p.transform.position.x, p.transform.position.y,distance),f);
	}
        if (followStatex1 == 1 && followStatex2 == 1)
        {
            //transform.position = new Vector3(Input.GetAxisRaw("Horizontal") * p.GetComponent<Player>().moveSpeed , transform.position.y, distance);
            transform.position = Vector3.Lerp(transform.position, new Vector3(p.transform.position.x,transform.position.y,distance), f);
        }
        if (followStatey1 == 1 && followStatey2 == 1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, p.transform.position.y, distance), f);
            //transform.position = new Vector3(transform.position.x, Input.GetAxisRaw("Vertical") * p.GetComponent<Player>().moveSpeed, distance);
        }
    }



}
