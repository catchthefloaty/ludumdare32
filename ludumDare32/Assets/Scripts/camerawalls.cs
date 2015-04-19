using UnityEngine;
using System.Collections;

public class camerawalls : MonoBehaviour {
    public bool vertical;
    public GameObject[] bounds;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "MainCamera")
        {
            if (vertical)
            {
                Camera.main.GetComponent<CameraFollow>().followStatex2 = 0;
                foreach (GameObject g in bounds)
                {
                    if (g.GetComponent<camerabounds>().vertical)
                    {
                        //g.SetActive(false);
                    }
                }
            }
            else
            {
                Camera.main.GetComponent<CameraFollow>().followStatey2 = 0;
                foreach (GameObject g in bounds)
                {
                    if (!g.GetComponent<camerabounds>().vertical)
                    {
                        //g.SetActive(false);
                    }
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == "MainCamera")
        {
            if (vertical)
            {
                Camera.main.GetComponent<CameraFollow>().followStatex2 = 1;
                foreach (GameObject g in bounds)
                {
                    if (g.GetComponent<camerabounds>().vertical)
                    {
                        //g.SetActive(true);
                    }
                }
            }
            else
            {
                Camera.main.GetComponent<CameraFollow>().followStatey2 = 1;
                foreach (GameObject g in bounds)
                {
                    if (!g.GetComponent<camerabounds>().vertical)
                    {
                        //g.SetActive(true);
                    }
                }
            }
        }
    }
    /*void OnTriggerStay2D(Collider2D col)
    {

        if (col.tag == "MainCamera")
        {
            if (vertical)
            {
                Camera.main.GetComponent<CameraFollow>().followStatex2 = 0;
                foreach (GameObject g in bounds)
                {
                    if (g.GetComponent<camerabounds>().vertical)
                    {
                        //g.SetActive(false);
                    }
                }
            }
            else
            {
                Camera.main.GetComponent<CameraFollow>().followStatey2 = 0;
                foreach (GameObject g in bounds)
                {
                    if (!g.GetComponent<camerabounds>().vertical)
                    {
                        //g.SetActive(false);
                    }
                }
            }
        }
    }*/
    
}
