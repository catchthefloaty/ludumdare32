using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    SpriteRenderer texture;
    public Sprite[] IdleAnimations;
    public float[] IdleTimings;
    public float[] IdleTimingOffsets;
    public Sprite[] WalkAnimations;
    public float[] WalkTimings;
    public Sprite[] AttackAnimations;
    public float[] AttackTimings;
    public Sprite[] bullets;
    float IdleTime;
    public float IdleTurnLimit;
    float WalkTime;
    public float WalkTurnLimit;
    float AttackTime;
    public float AttackTurnLimit;
    float AnimTime;
    public int GameplayState = 0;
    List<Vector3> pattern = new List<Vector3>();
    int patterncount;
    public float moveSpeed = 3;

    public int AnimState;
    int curFrame;
    Vector3 direction;
    
    
    public GameObject bullet1;


    float fireTime;
    public float fireRate;
    // Use this for initialization
    void Start()
    {
        //right
        pattern.Add(new Vector3(1,0,0));
        //up
        pattern.Add(new Vector3(0, 1, 0));
        //attack
        pattern.Add(new Vector3(2, 0, 0));
        texture = GetComponent<SpriteRenderer>();
        fireTime = fireRate + 1;
        
    }

    // Update is called once per frame
    void Update()
    {


        //Gameplay stuff
        fireTime += Time.deltaTime;
        if (GameplayState == 0)
        {
            IdleTime += Time.deltaTime;
           if(IdleTime > IdleTurnLimit){
               //can change state/attack
               int select = Random.Range(0,10);
               if (select > 6)
               {
                   GameplayState = 2;
                   AnimState = 2;
                   curFrame = 0;
                   texture.sprite = AttackAnimations[curFrame];
                   AnimTime = 0;
               }
               else if (select > 3)
               {
                   GameplayState = 1;
                   AnimState = 1;
                   curFrame = 0;
                   texture.sprite = WalkAnimations[curFrame];
                   AnimTime = 0;
                   direction = pattern[patterncount];
                   patterncount++;
                   if (direction.x == 2)
                   {
                       GameplayState = 2;
                       AnimState = 2;
                       texture.sprite = AttackAnimations[curFrame];
                   }
                   if (patterncount >= pattern.Count)
                   {
                       patterncount = 0;
                   }
               }
               
               IdleTime = 0;
           }

        }
            //walk in direction vector
        else if (GameplayState == 1)
        {
            WalkTime += Time.deltaTime;
            if (WalkTime > WalkTurnLimit){
                //can stop walking
                int select = Random.Range(0, 10);
                if (select > 4)
                {
                    GameplayState = 2;
                    AnimState = 2;
                    curFrame = 0;
                    texture.sprite = AttackAnimations[curFrame];
                    AnimTime = 0;
                }
                else if (select > 1)
                {
                    GameplayState = 0;
                    AnimState = 0;
                    curFrame = 0;
                    texture.sprite = IdleAnimations[curFrame];
                    AnimTime = 0;
                }
                else {
                    direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                }
                
                WalkTime = 0;
            }
            transform.Translate(direction.x * Time.deltaTime * moveSpeed, direction.y * Time.deltaTime * moveSpeed, 0);
            //rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*Time.deltaTime * moveSpeed,Input.GetAxis("Vertical")* Time.deltaTime*moveSpeed));


            
                
            
        }
        else if (GameplayState == 2)
        {
            fireTime += Time.deltaTime;
            if (fireTime > fireRate)
            {
                Attack();
                fireTime = 0;
            }
            AttackTime += Time.deltaTime;
            if (AttackTime > AttackTurnLimit)
            {
                //can stop walking
                int select = Random.Range(0, 10);
                if (select > 5)
                {
                    GameplayState = 1;
                    AnimState = 1;
                    curFrame = 0;
                    texture.sprite = WalkAnimations[curFrame];
                    AnimTime = 0;
                    direction = pattern[patterncount];
                    patterncount++;
                    if (direction.x == 2)
                    {
                        GameplayState = 2;
                        AnimState = 2;
                        texture.sprite = AttackAnimations[curFrame];
                    }
                    if (patterncount >= pattern.Count)
                    {
                        patterncount = 0;
                    }
                }
                else if (select > 3)
                {
                    GameplayState = 0;
                    AnimState = 0;
                    curFrame = 0;
                    texture.sprite = IdleAnimations[curFrame];
                    AnimTime = 0;
                }
                
                AttackTime = 0;
            }
        }


        //animation stuffwd
        if (AnimState == 0)
        {
            AnimTime += Time.deltaTime;
            if (AnimTime > IdleTimings[curFrame] + Random.Range(0f, IdleTimings[curFrame]))
            {
                AnimTime = 0;
                curFrame++;
                if (curFrame >= IdleAnimations.GetLength(0))
                {
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
        else if (AnimState == 2)
        {
            AnimTime += Time.deltaTime;
            if (AnimTime > AttackTimings[curFrame])
            {
                AnimTime = 0;
                curFrame++;
                if (curFrame >= AttackAnimations.GetLength(0))
                {
                    curFrame = 0;
                    
                }
                texture.sprite = AttackAnimations[curFrame];
            }
        }
    }

    void Attack()
    {
        GameObject Bullet = (GameObject)GameObject.Instantiate(bullet1, transform.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().direction = new Vector3(0, -1f,0);
        Bullet.GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0,bullets.GetLength(0))];
        Bullet = (GameObject)GameObject.Instantiate(bullet1, transform.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().direction = new Vector3(-1f, 0, 0);
        Bullet.GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.GetLength(0))];
        Bullet = (GameObject)GameObject.Instantiate(bullet1, transform.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().direction = new Vector3(0, 1f, 0);
        Bullet.GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.GetLength(0))];
        Bullet = (GameObject)GameObject.Instantiate(bullet1, transform.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().direction = new Vector3(1f, 0, 0);
        Bullet.GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.GetLength(0))];
    }
}
