using UnityEngine;
using System.Collections;
using InControl;

public class TipScript : MonoBehaviour {

    public GameObject MyPlane;
    AeroplaneController ap;
    public int playerNum;
    InputDevice myDevice;
    public static string[] tips = new string[] {
        "Press RT to accelerate forward",
        "Pull back on the left stick",
        "Steer with bumpers and left stick",
        "Refuel in the middle of the arena!",
        "Avoid crashing into the trails to win!"
    };
    bool tipsOn = false;
    int currentTip = 0;
	// Use this for initialization
	void Start () {
        myDevice = GameObject.Find("GamePersistent").GetComponent<Persist>().controllers[playerNum];
        ap = MyPlane.GetComponent<AeroplaneController>();
	}
	
	// Update is called once per frame
	void Update () {
        ToggleTips();
        TipLogic();
        DisplayTip();
	}
    void ToggleTips()
    {
        if(myDevice.Action4.WasPressed)
        {
            tipsOn = !tipsOn;
            GetComponent<UnityEngine.UI.Text>().enabled = tipsOn;
        }
    }
    void TipLogic()
    {
        if (currentTip == 0 && ap.Throttle > 0.5f) currentTip = 1;
        else if (currentTip == 1 && MyPlane.transform.position.y > 13f) currentTip = 2;
        else if (currentTip == 2 && ap.FuelLevel <= 0.45f) currentTip = 3;
        else if (currentTip == 3 && ap.FuelLevel > 1f) currentTip = 4;
    }
    void DisplayTip()
    {
        if (!tipsOn) return;
        GetComponent<UnityEngine.UI.Text>().text = tips[currentTip];
    }
}
