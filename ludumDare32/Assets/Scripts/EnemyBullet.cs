using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
    public Vector3 direction;
    public float speed;
    public float LifeSpan;
    float lifeTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime += Time.deltaTime;
        if(lifeTime>LifeSpan){
            Destroy(gameObject);
        }
        transform.Translate(new Vector3(speed * Time.deltaTime * direction.x, speed * Time.deltaTime * direction.y,0));
	}
}
