using UnityEngine;
using System.Collections;

public class CatCollideScript : MonoBehaviour {

	SpriteRenderer sr;

	public Sprite winSprite;

	bool playerIsAdjacent;
	
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		playerIsAdjacent = false;
	}
	
	void Update () {
		if ( ( Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.Space) ) && playerIsAdjacent) {
			sr.sprite = winSprite;
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
