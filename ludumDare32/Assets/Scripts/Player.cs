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
    int h;
    int v;
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
            if (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) > 0)
            {
                GameplayState = 1;
                AnimState = 1;
                curFrame = 0;
                texture.sprite = WalkAnimations[curFrame];
                AnimTime = 0;
            }
        }
        else if (GameplayState == 1)
        {
            h = 0;
            v = 0;
            if (Input.GetAxisRaw("Horizontal") > 0) {
                h = 1;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                h = -1;
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                v = 1;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                v = -1;
            }
            transform.Translate(h * Time.deltaTime * moveSpeed, v * Time.deltaTime * moveSpeed,0);
            //rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*Time.deltaTime * moveSpeed,Input.GetAxis("Vertical")* Time.deltaTime*moveSpeed));


            if (v == 0 && h == 0)
            {
                GameplayState = 0;
                AnimState = 0;
                curFrame = 0;
                texture.sprite = IdleAnimations[curFrame];
                AnimTime = 0;
            }
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
