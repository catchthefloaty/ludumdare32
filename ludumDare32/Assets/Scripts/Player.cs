using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    SpriteRenderer texture;
    public Sprite[] IdleAnimations;
    public float[] IdleTimings;
    public float[] IdleTimingOffsets;
    float AnimTime;
    //public float AnimRate = 3;
    int AnimState;
    int curFrame;
	// Use this for initialization
	void Start () {
        texture = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
    //Gameplay stuff



	//animation stuff
        if (AnimState == 0)
        {
            AnimTime += Time.deltaTime;
            if (AnimTime > IdleTimings[curFrame] + Random.Range(0f,IdleTimings[curFrame]) )
            {
                AnimTime = 0;
                curFrame++;
                if (curFrame >= IdleAnimations.GetLength(0)){
                    curFrame = 0;
                }
                texture.sprite = IdleAnimations[curFrame];
            }
        }
	}
}
