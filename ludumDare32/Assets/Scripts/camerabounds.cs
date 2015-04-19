using UnityEngine;
using System.Collections;

public class camerabounds : MonoBehaviour {
    public bool vertical;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            if (vertical)
            {
                Camera.main.GetComponent<CameraFollow>().followStatex1 = 1;
            }
            else
            {
                Camera.main.GetComponent<CameraFollow>().followStatey1 = 1;
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            if (vertical)
            {
                Camera.main.GetComponent<CameraFollow>().followStatex1 = 0;
            }
            else
            {
                Camera.main.GetComponent<CameraFollow>().followStatey1 = 0;
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            if (vertical)
            {
                Camera.main.GetComponent<CameraFollow>().followStatex1 = 1;
            }
            else
            {
                Camera.main.GetComponent<CameraFollow>().followStatey1 = 1;
            }
        }
    }
}
