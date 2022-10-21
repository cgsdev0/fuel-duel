using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.SceneManagement;

public class ReadyManagerScript : MonoBehaviour {

    Persist p;
    public GameObject[] texts;
	// Use this for initialization
	void Start () {
        p = GameObject.Find("GamePersistent").GetComponent<Persist>();
        p.numPlayers = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(InputManager.ActiveDevice.MenuWasPressed)
        {
            if (p.numPlayers < 2) return;

            SceneManager.LoadScene("scene_0");
        }
	    if(InputManager.ActiveDevice.Action1.WasPressed) {
            for(int i =0; i < p.numPlayers; ++i)
            {
                if (p.controllers[i] == InputManager.ActiveDevice) return;
            }
            p.controllers[p.numPlayers] = InputManager.ActiveDevice;
            texts[p.numPlayers].GetComponent<UnityEngine.UI.Text>().color = Color.green;
            p.numPlayers++;
        }
	}
}
