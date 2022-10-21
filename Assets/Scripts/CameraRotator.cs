using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {

    public Transform pointAt;
    public float turnRate = 5f;
    float angle;
    float dist;

	// Use this for initialization
	void Start () {
        Vector3 temp = new Vector3(transform.position.x, pointAt.position.y, transform.position.z);
        dist = Vector3.Distance(temp, pointAt.position);
	}
	
	// Update is called once per frame
	void Update () {
        angle += turnRate * Time.deltaTime;
        transform.position = new Vector3(pointAt.position.x + Mathf.Cos(angle)*dist, transform.position.y, pointAt.position.z + Mathf.Sin(angle)*dist);
        transform.LookAt(pointAt.position);
	}
}
