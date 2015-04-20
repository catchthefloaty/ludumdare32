using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float deg;
    public float speed;
    public float speedexp;
    bool right;
    public float Freq;
    public float degOffset;
    Vector3 origPos;
    Vector3 OffsetPos;
    float MasterTimer;
    public float breakAngle;
    public float lifeSpan = 6;
    float lifeTime;
    GameObject level;
    public int dir = 1;
	// Use this for initialization
	void Start () {
        origPos = transform.position;
        level = GameObject.FindGameObjectWithTag("level");
	}
	
	// Update is called once per frame
    void Update()
    {

        OffsetPos += new Vector3(Time.deltaTime * speed * Mathf.Sin((deg + degOffset) * Mathf.Deg2Rad), Time.deltaTime * speed * Mathf.Cos((deg + degOffset) * Mathf.Deg2Rad), 0);
        transform.position = origPos + OffsetPos;
        speed += Mathf.Pow(speed, speedexp) * Time.deltaTime;
        if (dir == 1)
        {
            if (right == true)
            {
                degOffset += (Freq * Time.deltaTime);
                if (degOffset >= breakAngle)
                {
                    right = false;
                }
            }
            else if (right == false)
            {
                degOffset -= (Freq * Time.deltaTime);
                if (degOffset <= -breakAngle)
                {
                    right = true;
                }
            }
            lifeTime += Time.deltaTime;
            if (lifeTime > lifeSpan)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (right == true)
            {
                degOffset -= (Freq * Time.deltaTime);
                if (degOffset <= -breakAngle)
                {
                    right = false;
                }
            }
            else if (right == false)
            {
                degOffset += (Freq * Time.deltaTime);
                if (degOffset >= breakAngle)
                {
                    right = true;
                }
            }
            lifeTime += Time.deltaTime;
            if (lifeTime > lifeSpan)
            {
                Destroy(gameObject);
            }
        }


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy"){
            Enemy e = col.gameObject.GetComponent<Enemy>();
            if (e != null)
            {
                if (!(e.GameplayState == 3))
                {
                    e.GameplayState = 3;
                    e.AnimState = 3;
                    e.curFrame = 0;
                    level.GetComponent<levelManager>().enemycount--;
                }
                else
                {
                    e.GameplayState = 0;
                    e.AnimState = 0;
                    e.curFrame = 0;
                    e.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                    e.GetComponent<SpriteRenderer>().enabled = true;
                }
                Destroy(gameObject);
                return;
            }

            Enemy1 e1 = col.gameObject.GetComponent<Enemy1>();
            if (e1 != null)
            {
                if (!(e1.GameplayState == 3))
                {
                    e1.GameplayState = 3;
                    e1.AnimState = 3;
                    e1.curFrame = 0;
                    level.GetComponent<levelManager>().enemycount--;
                }
                else
                {
                    e1.GameplayState = 0;
                    e1.AnimState = 0;
                    e1.curFrame = 0;
                    e1.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                    e1.GetComponent<SpriteRenderer>().enabled = true;
                }
                Destroy(gameObject);
                return;
            }
            Enemy2 e2 = col.gameObject.GetComponent<Enemy2>();
            if (e2 != null)
            {
                if (!(e2.GameplayState == 3))
                {
                    e2.GameplayState = 3;
                    e2.AnimState = 3;
                    e2.curFrame = 0;
                    level.GetComponent<levelManager>().enemycount--;
                }
                else
                {
                    e2.GameplayState = 0;
                    e2.AnimState = 0;
                    e2.curFrame = 0;
                    e2.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                    e2.GetComponent<SpriteRenderer>().enabled = true;
                }
                Destroy(gameObject);
                return;
            }
            Enemy3 e3 = col.gameObject.GetComponent<Enemy3>();
            if (e3 != null)
            {
                if (!(e3.GameplayState == 3))
                {
                    e3.GameplayState = 3;
                    e3.AnimState = 3;
                    e3.curFrame = 0;
                    level.GetComponent<levelManager>().enemycount--;
                }
                else
                {
                    e3.GameplayState = 0;
                    e3.AnimState = 0;
                    e3.curFrame = 0;
                    e3.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                    e3.GetComponent<SpriteRenderer>().enabled = true;
                }
                Destroy(gameObject);
                return;
            }
            Enemy4 e4 = col.gameObject.GetComponent<Enemy4>();
            if (e4 != null)
            {
                if (!(e4.GameplayState == 3))
                {
                    e4.GameplayState = 3;
                    e4.AnimState = 3;
                    e4.curFrame = 0;
                    level.GetComponent<levelManager>().enemycount--;
                }
                else
                {
                    e4.GameplayState = 0;
                    e4.AnimState = 0;
                    e4.curFrame = 0;
                    e4.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                    e4.GetComponent<SpriteRenderer>().enabled = true;
                }
                Destroy(gameObject);
                return;
            }
            Enemy5 e5 = col.gameObject.GetComponent<Enemy5>();
            if (e5 != null)
            {
                if (!(e5.GameplayState == 3))
                {
                    e5.GameplayState = 3;
                    e5.AnimState = 3;
                    e5.curFrame = 0;
                    level.GetComponent<levelManager>().enemycount--;
                }
                else
                {
                    e5.GameplayState = 0;
                    e5.AnimState = 0;
                    e5.curFrame = 0;
                    e5.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                    e5.GetComponent<SpriteRenderer>().enabled = true;
                }
                Destroy(gameObject);
                return;
            }
            Enemy6 e6 = col.gameObject.GetComponent<Enemy6>();
            if (e6 != null)
            {
                if (!(e6.GameplayState == 3))
                {
                    e6.GameplayState = 3;
                    e6.AnimState = 3;
                    e6.curFrame = 0;
                    level.GetComponent<levelManager>().enemycount--;
                }
                else
                {
                    e6.GameplayState = 0;
                    e6.AnimState = 0;
                    e6.curFrame = 0;
                    e6.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                    e6.GetComponent<SpriteRenderer>().enabled = true;
                }
                Destroy(gameObject);
                return;
            }
            
             BossEnemy e8 = col.gameObject.GetComponent<BossEnemy>();
            if (e8 != null)
            {
                if (!(e8.GameplayState == 3))
                {
                    e8.GameplayState = 3;
                    e8.AnimState = 3;
                    e8.curFrame = 0;
                    level.GetComponent<levelManager>().enemycount--;
                }
                else
                {
                    e8.GameplayState = 0;
                    e8.AnimState = 0;
                    e8.curFrame = 0;
                    e8.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                    e8.GetComponent<SpriteRenderer>().enabled = true;
                }
                Destroy(gameObject);
                return;
            }
        }

        
    }

}
