using UnityEngine;
using System.Collections;
using InControl;

public class CameraFollower : MonoBehaviour {

    public GameObject MyPlane;
    public float followDistance;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 camGoal = MyPlane.transform.position - followDistance*MyPlane.transform.forward + Vector3.up*10f;
        camGoal.y = Mathf.Max(camGoal.y, 5f);
        transform.position = camGoal;
        transform.LookAt(MyPlane.transform.position + MyPlane.transform.forward * 10f);
        /*float rightIn = InputManager.ActiveDevice.RightStickX;
        if (Mathf.Abs(rightIn) > 0f && (Mathf.Abs(sideAngle) < 45f || (Mathf.Sign(sideAngle) == Mathf.Sign(rightIn)))) {
            sideAngle += Mathf.Clamp((240-Mathf.Abs(sideAngle))/180f, 0.1f, 1f) * rightIn * turnRadius;
            while (sideAngle > 180) sideAngle -= 360;
            while (sideAngle < -180) sideAngle += 360;
        }
        else
            sideAngle = Mathf.MoveTowards(sideAngle, 0f, Mathf.Max(15f*Time.deltaTime, 5*Mathf.Abs((sideAngle)) * Time.deltaTime));

        rightIn = InputManager.ActiveDevice.RightStickY;
        if (Mathf.Abs(rightIn) > 0.2f)
        {
            if (Mathf.Abs(upAngle) < Mathf.Abs(rightIn*height))
                upAngle += rightIn * turnRadius/2f;
        }
        else upAngle = Mathf.MoveTowards(upAngle, 0f, Mathf.Max(15f * Time.deltaTime, 5*Mathf.Abs((upAngle)) * Time.deltaTime));
        transform.position = MyPlane.transform.position + Quaternion.Euler(new Vector3(upAngle, -sideAngle - (InputManager.ActiveDevice.RightStickButton.IsPressed ? 180 : 0), 0)) * followDistance;
        transform.LookAt(MyPlane.transform);*/
    }
}
