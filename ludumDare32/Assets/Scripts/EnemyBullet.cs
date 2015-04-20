using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
    public Vector3 direction;
    public float speed;
    public float LifeSpan;
    float lifeTime;
    GameObject level;
	// Use this for initialization
	void Start () {
        level = GameObject.FindGameObjectWithTag("level");
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime += Time.deltaTime;
        if(lifeTime>LifeSpan){
            Destroy(gameObject);
        }
        transform.Translate(new Vector3(speed * Time.deltaTime * direction.x, speed * Time.deltaTime * direction.y,0));
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().health -= 1;

        }

        if (col.tag == "Enemy")
        {
            Enemy e = col.gameObject.GetComponent<Enemy>();
            if (e != null)
            {
                if (!(e.GameplayState == 3))
                {
                    
                }
                else
                {
                    e.GameplayState = 0;
                    e.AnimState = 0;
                    e.curFrame = 0;
                    e.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                }
                Destroy(gameObject);
                return;
            }

            Enemy1 e1 = col.gameObject.GetComponent<Enemy1>();
            if (e1 != null)
            {
                if (!(e1.GameplayState == 3))
                {
                    
                }
                else
                {
                    e1.GameplayState = 0;
                    e1.AnimState = 0;
                    e1.curFrame = 0;
                    e1.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                }
                Destroy(gameObject);
                return;
            }
            Enemy2 e2 = col.gameObject.GetComponent<Enemy2>();
            if (e2 != null)
            {
                if (!(e2.GameplayState == 3))
                {
                   
                }
                else
                {
                    e2.GameplayState = 0;
                    e2.AnimState = 0;
                    e2.curFrame = 0;
                    e2.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                }
                Destroy(gameObject);
                return;
            }
            Enemy3 e3 = col.gameObject.GetComponent<Enemy3>();
            if (e3 != null)
            {
                if (!(e.GameplayState == 3))
                {
                    
                }
                else
                {
                    e3.GameplayState = 0;
                    e3.AnimState = 0;
                    e3.curFrame = 0;
                    e3.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                }
                Destroy(gameObject);
                return;
            }
            Enemy4 e4 = col.gameObject.GetComponent<Enemy4>();
            if (e4 != null)
            {
                if (!(e4.GameplayState == 3))
                {
                    
                }
                else
                {
                    e4.GameplayState = 0;
                    e4.AnimState = 0;
                    e4.curFrame = 0;
                    e4.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                }
                Destroy(gameObject);
                return;
            }
            Enemy5 e5 = col.gameObject.GetComponent<Enemy5>();
            if (e != null)
            {
                if (!(e5.GameplayState == 3))
                {
                    
                }
                else
                {
                    e5.GameplayState = 0;
                    e5.AnimState = 0;
                    e5.curFrame = 0;
                    e5.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                }
                Destroy(gameObject);
                return;
            }
            Enemy6 e6 = col.gameObject.GetComponent<Enemy6>();
            if (e6 != null)
            {
                if (!(e6.GameplayState == 3))
                {
                   
                }
                else
                {
                    e6.GameplayState = 0;
                    e6.AnimState = 0;
                    e6.curFrame = 0;
                    e6.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                }
                Destroy(gameObject);
                return;
            }

            BossEnemy e8 = col.gameObject.GetComponent<BossEnemy>();
            if (e8 != null)
            {
                if (!(e8.GameplayState == 3))
                {
                    
                }
                else
                {
                    e8.GameplayState = 0;
                    e8.AnimState = 0;
                    e8.curFrame = 0;
                    e8.patterncount = 0;
                    level.GetComponent<levelManager>().enemycount++;
                }
                Destroy(gameObject);
                return;
            }
        }
        //Destroy(gameObject);
    }
}
