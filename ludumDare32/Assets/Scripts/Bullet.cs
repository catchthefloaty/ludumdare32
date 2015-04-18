using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float deg;
    public float speed;
    public float speedexp;
    bool right;
    public float Freq;
    public float degOffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	transform.position = new Vector3(speed * Time.deltaTime * Mathf.Sin(deg+degOffset),speed * Time.deltaTime * Mathf.Sin(deg+degOffset),0);
    
    speed = Mathf.Pow(speed,speedexp);
    
    if (right == true){
        degOffset += Freq;
        if (degOffset >= 60){
            right = false;
        }
    }
    else if (right == false){
        degOffset -= 3;
        if(degOffset <= -60){
            right = true;
        }
    }
    
	}
}
