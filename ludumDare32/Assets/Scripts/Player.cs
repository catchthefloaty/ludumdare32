using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    SpriteRenderer texture;
    public Sprite[] IdleAnimations;
    public float[] IdleTimings;
    public float[] IdleTimingOffsets;
    public Sprite[] WalkAnimations;
    public float[] WalkTimings;
    public Sprite[] AttackAnimations;
    public float[] AttackTimings;
    float AnimTime;
    int GameplayState = 1;
    public float moveSpeed = 3;
    public GameObject[] Hearts;
    int AnimState;
    int curFrame;
    int h;
    int v;
    public Sprite[] notes;
    public int health = 4;
    public GameObject gameover;
    GameObject target;
    Vector3 mouseclick;
    public GameObject bullet1;
    float fireTime;
    public float fireRate;
    int dir = 0;
    public AudioClip hit;
    public AudioClip[] fire;
    // Use this for initialization
    void Start()
    {
        texture = GetComponent<SpriteRenderer>();
        target = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            health = 0;
        }
        if (health < 4)
        {
            for (int i = health; i < 4; i++)
            {
                if (i > -1)
                {
                    Hearts[i].SetActive(false);
                }
            }
            if (health < 1)
            {
                gameover.SetActive(true);
                transform.GetChild(1).SetParent(null);
                Destroy(gameObject);
            }
        }
        //Gameplay stuff
        fireTime += Time.deltaTime;
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
            if (Input.GetMouseButtonDown(0) == true)
            {
                GameplayState = 2;
                AnimState = 2;
                curFrame = 0;
                mouseclick = Input.mousePosition;
                dir = 1;

            }
            if (Input.GetMouseButtonDown(1) == true)
            {
                GameplayState = 2;
                AnimState = 2;
                curFrame = 0;
                mouseclick = Input.mousePosition;
                dir = -1;
            }

        }
        else if (GameplayState == 1)
        {
            h = 0;
            v = 0;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
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
            transform.Translate(h * Time.deltaTime * moveSpeed, v * Time.deltaTime * moveSpeed, 0);



            if (v == 0 && h == 0)
            {
                GameplayState = 0;
                AnimState = 0;
                curFrame = 0;
                texture.sprite = IdleAnimations[curFrame];
                AnimTime = 0;
            }
            if (Input.GetMouseButtonDown(0) == true)
            {
                GameplayState = 2;
                AnimState = 2;
                curFrame = 0;
                mouseclick = Input.mousePosition;
                dir = 1;

            }
            if (Input.GetMouseButtonDown(1) == true)
            {
                GameplayState = 2;
                AnimState = 2;
                curFrame = 0;
                mouseclick = Input.mousePosition;
                dir = -1;
            }

        }
        else if (GameplayState == 2)
        {
            if (fireTime >= fireRate)
            {
                if (dir == 1)
                {
                    FireBullet1(mouseclick);
                    dir = 0;
                }
                else if (dir == -1)
                {
                    FireBullet2(mouseclick);
                    dir = 0;
                }
                fireTime = 0;
                AudioSource.PlayClipAtPoint(fire[Random.Range(0,fire.GetLength(0))], new Vector3(0, 0, 0), .1f);
            }
            GameplayState = 0;
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
    void FireBullet1(Vector3 targetvector)
    {
        GameObject tempBullet = (GameObject)GameObject.Instantiate(bullet1, transform.GetChild(0).transform.position, Quaternion.identity);
        Bullet b = tempBullet.GetComponent<Bullet>();
        Ray ray = Camera.main.ScreenPointToRay(targetvector);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        float distance;
        xy.Raycast(ray, out distance);
        Vector3 cPoint = ray.GetPoint(distance);

        cPoint.z = 0;
        target.transform.position = cPoint;
        Vector3 tempuntilbulletismade = Vector3.Normalize(target.transform.position - this.transform.position);
        tempBullet.GetComponent<SpriteRenderer>().sprite = notes[Random.Range(0, notes.GetLength(0))];
        float rot_z = Mathf.Atan2(tempuntilbulletismade.y, tempuntilbulletismade.x) * Mathf.Rad2Deg;
        tempBullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        b.deg = Mathf.Abs(Quaternion.Euler(0f, 0f, rot_z - 90).eulerAngles.z-360);
        
        
    }

    void FireBullet2(Vector3 targetvector)
    {
        GameObject tempBullet = (GameObject)GameObject.Instantiate(bullet1, transform.GetChild(0).transform.position, Quaternion.identity);
        Bullet b = tempBullet.GetComponent<Bullet>();
        Ray ray = Camera.main.ScreenPointToRay(targetvector);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        float distance;
        xy.Raycast(ray, out distance);
        Vector3 cPoint = ray.GetPoint(distance);
        tempBullet.GetComponent<SpriteRenderer>().sprite = notes[Random.Range(0, notes.GetLength(0))];
        cPoint.z = 0;
        target.transform.position = cPoint;
        Vector3 tempuntilbulletismade = Vector3.Normalize(target.transform.position - this.transform.position);

        float rot_z = Mathf.Atan2(tempuntilbulletismade.y, tempuntilbulletismade.x) * Mathf.Rad2Deg;
        tempBullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        b.deg = Mathf.Abs(Quaternion.Euler(0f, 0f, rot_z - 90).eulerAngles.z - 360);
        b.dir = -1;

    }

    
}


