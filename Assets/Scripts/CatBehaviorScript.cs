using UnityEngine;
using System.Collections;

public class CatBehaviorScript : MonoBehaviour {

	private Vector2 movement;

	int alertnessLevel;
	GameObject player;

	Animator anim;

	void Start () {
		alertnessLevel=0;
		player = GameObject.Find ("player");
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		if (GameScript.state != GameScript.State.Playing) {
			return;
		}

		PlayerScript ps = (PlayerScript)player.GetComponent (typeof(PlayerScript));

		sense (player);

		if (alertnessLevel > 300) {
			runAway();
		}
		else if (alertnessLevel > 175) {
			walkAway();
		}
		else if (alertnessLevel > 50 || ps.isPlayerCrouching()) {
			standUp();
		}
		if (alertnessLevel < 50) {
			layDown();
		}

	}

	void FixedUpdate () {
		rigidbody2D.velocity = movement;
	}

	void sense (GameObject player) {
		PlayerScript ps = (PlayerScript)player.GetComponent (typeof(PlayerScript));

		if (ps.isPlayerVisible()) {
			alertnessLevel++;
		} else if (alertnessLevel > 0) {
			alertnessLevel--;
		}

	}

	void standUp(){
		movement = new Vector2 (0, 0);
		anim.SetInteger ("state", 1);
	}

	void walkAway(){
		movement = new Vector2 (1, 0);
		anim.SetInteger ("state", 2);
	}

	void runAway () {
		movement = new Vector2 (4, 0);
		anim.SetInteger ("state", 3);
		((GameScript) GameObject.Find("GameManager").GetComponent(typeof(GameScript))).lose();
	}

	void layDown () {
		movement = new Vector2 (0, 0);
		anim.SetInteger ("state", 0);
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		string other = otherCollider.gameObject.name;
		if (other.Equals("boundary")) {
			runAway();
		}
	}
}
