using UnityEngine;
using System.Collections;

public class DeleteMe : MonoBehaviour {

    public int playerNum;

	void Awake () {
        if (playerNum >= GameObject.Find("GamePersistent").GetComponent<Persist>().numPlayers) Destroy(gameObject);
	}

}
