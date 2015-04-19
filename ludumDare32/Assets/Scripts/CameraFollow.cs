using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    GameObject p;
    public float distance;
    public int followStatex =1;
    public int followStatey = 1;

	// Use this for initialization
	void Start () {
        p = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if ( followStatex == 1 && followStatey == 1){
        transform.position = new Vector3(p.transform.position.x, p.transform.position.y, -50);
	}
        if (followStatex == 1)
        {
            transform.position = new Vector3(p.transform.position.x, transform.position.y, -50);
        }
        if (followStatey == 1)
        {
            transform.position = new Vector3(transform.position.x, p.transform.position.y, -50);
        }
    }

}
