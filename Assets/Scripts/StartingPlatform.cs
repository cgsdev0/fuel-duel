using UnityEngine;
using System.Collections;

public class StartingPlatform : MonoBehaviour {

    bool ticking = false;
    public float stayUp = 10f;
    private float timeStart;
    private Vector3 startPos;
    
    void Start()
    {
        startPos = transform.position;
        StartCounter();
    }
	// Use this for initialization
	void StartCounter () {
        timeStart = Time.time;
        ticking = true;
	}
	
    void Reset()
    {
        ticking = false;
        transform.position = startPos;
    }

	// Update is called once per frame
	void Update () {
        if (!ticking) return;
        if(Time.time > timeStart + stayUp)
        {
            transform.position += Vector3.down*3f*Time.deltaTime;
        }
	}
}
