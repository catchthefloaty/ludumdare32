using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossEnemy : MonoBehaviour
{

    SpriteRenderer texture;
    public Sprite[] IdleAnimations;
    public float[] IdleTimings;
    public float[] IdleTimingOffsets;
    public Sprite[] WalkAnimations;
    public float[] WalkTimings;
    public Sprite[] AttackAnimations;
    public float[] AttackTimings;
    public Sprite[] SleepAnimations;
    public float[] SleepTimes;
    float sleepTimer;
    public float SleepLimit;
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
    public int patterncount;
    public float moveSpeed = 3;

    public int AnimState;
    public int curFrame;
    Vector3 direction;
    
    
    public GameObject bullet1;


    float fireTime;
    public float fireRate;
    // Use this for initialization
    void Start()
    {
        //right
        pattern.Add(new Vector3(3, 0, 0));
        pattern.Add(new Vector3(1,0,0));
        pattern.Add(new Vector3(2, 0, 0));
        pattern.Add(new Vector3(1, 0, 0));
        pattern.Add(new Vector3(2, 0, 0));
        pattern.Add(new Vector3(-1, 0, 0));
        //attack
        pattern.Add(new Vector3(2, 0, 0));
        pattern.Add(new Vector3(-1, 0, 0));
        
        texture = GetComponent<SpriteRenderer>();
        fireTime = fireRate + 1;
        IdleTime = IdleTurnLimit;
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
               if (select > 12)
               {
                   GameplayState = 2;
                   AnimState = 2;
                   curFrame = 0;
                   texture.sprite = AttackAnimations[curFrame];
                   AnimTime = 0;
                   fireTime = fireRate + 1;
               }
               else if (select > 13)
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
                       fireTime = fireRate + 1;
                   }
                   if (direction.x == 3)
                   {
                       GameplayState = 0;
                       AnimState = 0;
                       texture.sprite = IdleAnimations[curFrame];
                   }
                   if (patterncount >= pattern.Count)
                   {
                       patterncount = 0;
                   }
               }
               else {
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
                       fireTime = fireRate + 1;
                   }
                   if (direction.x == 3)
                   {
                       GameplayState = 0;
                       AnimState = 0;
                       texture.sprite = IdleAnimations[curFrame];
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
                if (select > 14)
                {
                    GameplayState = 2;
                    AnimState = 2;
                    curFrame = 0;
                    texture.sprite = AttackAnimations[curFrame];
                    AnimTime = 0;
                    fireTime = fireRate + 1;
                }
                else if (select > 11)
                {
                    GameplayState = 0;
                    AnimState = 0;
                    curFrame = 0;
                    texture.sprite = IdleAnimations[curFrame];
                    AnimTime = 0;
                }
                else {
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
                        fireTime = fireRate + 1;
                    }
                    if (direction.x == 3)
                    {
                        GameplayState = 0;
                        AnimState = 0;
                        texture.sprite = IdleAnimations[curFrame];
                    }
                    if (patterncount >= pattern.Count)
                    {
                        patterncount = 0;
                    }
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
                if (select > 15)
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
                        fireTime = fireRate + 1;
                    }
                    if (patterncount >= pattern.Count)
                    {
                        patterncount = 0;
                    }
                }
                else if (select > 13)
                {
                    GameplayState = 0;
                    AnimState = 0;
                    curFrame = 0;
                    texture.sprite = IdleAnimations[curFrame];
                    AnimTime = 0;
                }
                else
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
                        fireTime = fireRate + 1;
                    }
                    if (direction.x == 3)
                    {
                        GameplayState = 0;
                        AnimState = 0;
                        texture.sprite = IdleAnimations[curFrame];
                    }
                    if (patterncount >= pattern.Count)
                    {
                        patterncount = 0;
                    }
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
        else if (AnimState == 3){
            AnimTime += Time.deltaTime;
            if (AnimTime > SleepTimes[curFrame])
            {
                AnimTime = 0;
                curFrame++;
                if (curFrame >= SleepAnimations.GetLength(0))
                {
                    curFrame = 0;

                }
                texture.sprite = SleepAnimations[curFrame];
            }
            sleepTimer += Time.deltaTime;
            if (sleepTimer>SleepLimit){
                sleepTimer = 0;
                texture.enabled = !texture.enabled;

            }
        }
    }

    void Attack()
    {
        GameObject Bullet = (GameObject)GameObject.Instantiate(bullet1, transform.GetChild(0).transform.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().direction = new Vector3(0, -1f,0);
        Bullet.GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0,bullets.GetLength(0))];
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(),Bullet.GetComponent<BoxCollider2D>(),true);
        Bullet = (GameObject)GameObject.Instantiate(bullet1, transform.GetChild(0).transform.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().direction = new Vector3(-1f, 0, 0);
        Bullet.GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.GetLength(0))];
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), Bullet.GetComponent<BoxCollider2D>(), true);
        Bullet = (GameObject)GameObject.Instantiate(bullet1, transform.GetChild(0).transform.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().direction = new Vector3(0, 1f, 0);
        Bullet.GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.GetLength(0))];
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), Bullet.GetComponent<BoxCollider2D>(), true);
        Bullet = (GameObject)GameObject.Instantiate(bullet1, transform.GetChild(0).transform.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().direction = new Vector3(1f, 0, 0);
        Bullet.GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.GetLength(0))];
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), Bullet.GetComponent<BoxCollider2D>(), true);
    }
}
