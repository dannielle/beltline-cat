using UnityEngine;
using System.Collections;

public class CatWinCollideScript : MonoBehaviour {
	
	bool playerIsAdjacent;

	GameObject player;
	PlayerScript ps;
	
	void Start () {
		playerIsAdjacent = false;
		player = GameObject.Find ("player");
		ps = (PlayerScript)player.GetComponent (typeof(PlayerScript));
	}
	
	void Update () {
		if ( ps.isPlayerCrouching() && playerIsAdjacent) {
			((GameScript) GameObject.Find("GameManager").GetComponent(typeof(GameScript))).win();
		}
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		string other = otherCollider.gameObject.name;
		if (other.Equals("player")) {
			playerIsAdjacent = true;
		}
	}
}
