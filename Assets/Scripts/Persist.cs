using UnityEngine;
using System.Collections;
using InControl;

public class Persist : MonoBehaviour {

    public static Persist Instance;
    public int numPlayers;
    public InputDevice[] controllers;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            controllers = new InputDevice[4];
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
