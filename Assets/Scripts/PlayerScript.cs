using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Vector2 movement;

	public Sprite walkingSprite;
	public Sprite creepingSprite;
	public Sprite crouchingSprite;

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	public enum State {
		Walk,
		Creep,
		Crouch
	}

	public State state;
	
	void Update () {
		if ((GameScript.state == GameScript.State.Win) || (GameScript.state == GameScript.State.Lose)) {
			movement = new Vector2(0,0);
			return;
		}

		float inputX = Input.GetAxis ("Horizontal");
		if (inputX >= 0) {
			movement = new Vector2 (inputX, 0);
		}

		if ( Input.GetKey (KeyCode.DownArrow)) {
			state = State.Crouch;
			anim.SetBool("isCrouching", true);
			movement = new Vector2(0,0);
		}

		else {
			state = State.Creep;
			anim.SetBool("isCrouching", false);
		}

	}

	void FixedUpdate () {
		rigidbody2D.velocity = movement;
		anim.SetFloat ("speed", Mathf.Abs(movement.x));
	}

	public bool isPlayerVisible () {
		return ((state == State.Walk) || (state == State.Creep));
	}

	public bool isPlayerMoving () {
		return (state == State.Walk);
	}

	public bool isPlayerCrouching () {
		return state == State.Crouch;
	}

}
