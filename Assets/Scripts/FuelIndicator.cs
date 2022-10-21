using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.SceneManagement;

public class FuelIndicator : MonoBehaviour {

    public GameObject MyPlane;
    private AeroplaneController ac;
    private UnityEngine.UI.Text t;
    private static int place = 4;
    private int myPlace = -1;
    private bool didIwin = false;

    void Awake()
    {
        place = GameObject.Find("GamePersistent").GetComponent<Persist>().numPlayers;
    }
	// Use this for initialization
	void Start () {
        ac = MyPlane.GetComponent<AeroplaneController>();
        t = GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (didIwin) {
            if(InputManager.ActiveDevice.Action2.WasPressed)
            {
                SceneManager.LoadScene("scene_menu");
            }
            return;
        }
        t.color = Color.white;
        if (ac.IsDead())
        {
            if (myPlace == -1) myPlace = place--;
            t.text = "GAME OVER. Place: " + myPlace.ToString();
        }
        else if (!didIwin && place == 1)
        {
            didIwin = true;
            t.color = Color.yellow;
            t.text = "WINNER! Press B to continue";
        }
        else if (ac.FuelLevel > 1) t.text = "Refueled!";
        else {
            t.text = "Fuel Level: " + Mathf.Round(ac.FuelLevel * 100).ToString() + "%";
            if (ac.FuelLevel <= 0.35f) t.color = Color.red;
        }
	}
}
