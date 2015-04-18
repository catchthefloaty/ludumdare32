﻿using UnityEngine;
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

	transform.position += new Vector3(speed * Mathf.Sin((deg+degOffset)*Mathf.Deg2Rad)* Time.deltaTime,speed  * Mathf.Cos((deg+degOffset)*Mathf.Deg2Rad)*Time.deltaTime,0);

    speed = speed + (Time.deltaTime * (Mathf.Pow(speed, speedexp) - speed));
    
    if (right == true){
        degOffset += Freq * Time.deltaTime;
        if (degOffset >= 60){
            right = false;
        }
    }
    else if (right == false){
        degOffset -= Freq*Time.deltaTime;
        if(degOffset <= -60){
            right = true;
        }
    }
    
	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
