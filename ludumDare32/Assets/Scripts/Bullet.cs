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
	// Use this for initialization
	void Start () {
        origPos = transform.position;

	}
	
	// Update is called once per frame
    void Update()
    {

        OffsetPos += new Vector3(speed * Mathf.Sin((deg + degOffset) * Mathf.Deg2Rad), speed * Mathf.Cos((deg + degOffset) * Mathf.Deg2Rad), 0);
        transform.position = origPos + OffsetPos;
        speed += Mathf.Pow(speed, speedexp) * Time.deltaTime * Time.deltaTime;

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
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
