using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class levelManager : MonoBehaviour {
    //GameObject[] enemies;
    public string nextlevel;
    public int enemycount;
    SpriteRenderer black;
    List<string> bonuslevels = new List<string>();
    bool done = false;
    static int bonuscount = -1;
    public bool notbonus = false;
	// Use this for initialization
	void Start () {
        black = GameObject.FindGameObjectWithTag("black").GetComponent<SpriteRenderer>();
        enemycount = GameObject.FindGameObjectsWithTag("Enemy").GetLength(0);
        bonuslevels.Add("Ncliff2");
        bonuslevels.Add("Nmoutain2");
        bonuslevels.Add("Nmoutain3");
        bonuslevels.Add("Nforest3");
        
	}
	
	// Update is called once per frame
	void Update () {
        if (enemycount == 0)
        {
            done = true;
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("bullet")){
                Destroy(g);
            }
            //Application.LoadLevel(nextlevel);
        }
        if (done)
        {
            black.color = new Color(1,1,1,black.color.a+.01f);
        }
        if (black.color.a >= 1)
        {
            if (!notbonus)
            {
                bonuscount++;
            }
            if (nextlevel != "")
            {
                Application.LoadLevel(nextlevel);
            }
            else if(bonuscount < bonuslevels.Count)
            {
                Application.LoadLevel(bonuslevels[bonuscount]);
            }
            else
            {
                Application.LoadLevel("credits");
            }
            
        }
	}
}
