using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            Retry();
        }
	}

    public void Retry()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
