using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {
    //GameObject[] enemies;
    public string nextlevel;
    public int enemycount;
    SpriteRenderer black;

    bool done = false;
	// Use this for initialization
	void Start () {
        black = GameObject.FindGameObjectWithTag("black").GetComponent<SpriteRenderer>();
        enemycount = GameObject.FindGameObjectsWithTag("Enemy").GetLength(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (enemycount == 0)
        {
            done = true;

            //Application.LoadLevel(nextlevel);
        }
        if (done)
        {
            black.color = new Color(1,1,1,black.color.a+.01f);
        }
        if (black.color.a >= 1)
        {
            Application.LoadLevel(nextlevel);
        }
	}
}
