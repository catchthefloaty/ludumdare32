using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    SpriteRenderer texture;
    public Sprite[] IdleAnimations;
    public float[] IdleTimings;
    public float[] IdleTimingOffsets;
    public Sprite[] WalkAnimations;
    public float[] WalkTimings;
    float AnimTime;
    int GameplayState = 1;
    Rigidbody2D rb;
    public float moveSpeed = 3;
    
    int AnimState;
    int curFrame;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        texture = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
    //Gameplay stuff
        if (GameplayState == 0)
        {
            
        }
        else if (GameplayState == 1)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed,0);
            //rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*Time.deltaTime * moveSpeed,Input.GetAxis("Vertical")* Time.deltaTime*moveSpeed));
        }


	//animation stuffwd
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
        else if (AnimState == 1)
        {
            AnimTime += Time.deltaTime;
            if (AnimTime > WalkTimings[curFrame])
            {
                AnimTime = 0;
                curFrame++;
                if (curFrame >= WalkAnimations.GetLength(0))
                {
                    curFrame = 0;
                }
                texture.sprite = WalkAnimations[curFrame];
            }
        }
	}
}
