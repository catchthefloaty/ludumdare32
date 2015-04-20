using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {
    //GameObject[] enemies;
    public string nextlevel;
    public int enemycount;
	// Use this for initialization
	void Start () {
        enemycount = GameObject.FindGameObjectsWithTag("Enemy").GetLength(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (enemycount == 0)
        {
            Application.LoadLevel(nextlevel);
        }
	
	}
}
