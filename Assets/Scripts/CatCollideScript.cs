using UnityEngine;
using System.Collections;

public class CatCollideScript : MonoBehaviour {

	SpriteRenderer sr;

	public Sprite winSprite;

	bool playerIsAdjacent;

	GameObject player;
	PlayerScript ps;
	
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		playerIsAdjacent = false;
		player = GameObject.Find ("player");
		ps = (PlayerScript)player.GetComponent (typeof(PlayerScript));
	}
	
	void Update () {
		if ( ps.isPlayerCrouching() && playerIsAdjacent) {
			sr.sprite = winSprite;
			GameScript.state = GameScript.State.Win;
		}
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		//is this a cat?
		string cat = otherCollider.gameObject.name;
		if (cat.Equals("player")) {
			playerIsAdjacent = true;
		}
	}
}
