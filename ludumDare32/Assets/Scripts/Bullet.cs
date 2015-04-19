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
	// Use this for initialization
	void Start () {
        origPos = transform.position;

	}
	
	// Update is called once per frame
    void Update()
    {

        OffsetPos += new Vector3(Time.deltaTime * speed * Mathf.Sin((deg + degOffset) * Mathf.Deg2Rad), Time.deltaTime * speed * Mathf.Cos((deg + degOffset) * Mathf.Deg2Rad), 0);
        transform.position = origPos + OffsetPos;
        speed += Mathf.Pow(speed, speedexp) * Time.deltaTime;

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
                }
                else
                {
                    e.GameplayState = 0;
                    e.AnimState = 0;
                    e.curFrame = 0;
                    e.patterncount = 0;
                }
            }

            Enemy1 e1 = col.gameObject.GetComponent<Enemy1>();
            if (e != null)
            {
                if (!(e.GameplayState == 3))
                {
                    e1.GameplayState = 3;
                    e1.AnimState = 3;
                    e1.curFrame = 0;
                }
                else
                {
                    e1.GameplayState = 0;
                    e1.AnimState = 0;
                    e1.curFrame = 0;
                    e1.patterncount = 0;
                }
            }
            Enemy2 e2 = col.gameObject.GetComponent<Enemy2>();
            if (e != null)
            {
                if (!(e.GameplayState == 3))
                {
                    e2.GameplayState = 3;
                    e2.AnimState = 3;
                    e2.curFrame = 0;
                }
                else
                {
                    e2.GameplayState = 0;
                    e2.AnimState = 0;
                    e2.curFrame = 0;
                    e2.patterncount = 0;
                    
                }
            }
        }
        Destroy(gameObject);
    }

}
