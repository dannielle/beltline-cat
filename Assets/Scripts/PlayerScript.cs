using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Vector2 movement;

	public Sprite walkingSprite;
	public Sprite creepingSprite;
	public Sprite crouchingSprite;

	SpriteRenderer sr;
	
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}

	public enum State {
		Walk,
		Creep,
		Crouch
	}

	public State state;
	
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		movement = new Vector2 (inputX, 0);


		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow )) {
			state = State.Walk;
		}

		else if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.DownArrow)) {
			state = State.Crouch;
		}

		else {
			state = State.Creep;
		}

		switch (state) {
		case State.Walk:
			sr.sprite = walkingSprite;
			break;
		case State.Creep:
			sr.sprite = creepingSprite;
			break;
		case State.Crouch:
			sr.sprite = crouchingSprite;
			break;
		default:
			sr.sprite = creepingSprite;
			break;
		}
	}

	void FixedUpdate () {
		rigidbody2D.velocity = movement;
	}
}
