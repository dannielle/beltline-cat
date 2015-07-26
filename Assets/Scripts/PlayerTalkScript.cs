using UnityEngine;
using System.Collections;

public class PlayerTalkScript : MonoBehaviour {

	Animator anim;
	const int NUM_OF_SAYINGS = 4;

	SpriteRenderer sr;

	Sprite[] sprites;
	public Sprite hey1;
	public Sprite hey2;
	public Sprite hey3;
	public Sprite hey4;

	void Start () {
//		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
		sprites = new Sprite[NUM_OF_SAYINGS] {hey1, hey2, hey3, hey4};
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			int state = Random.Range(0, NUM_OF_SAYINGS);
			sr.sprite = sprites[state];
			sr.enabled = true;
//			anim.SetInteger("state", state);
//			anim.SetBool("isVisible", true);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			sr.enabled = false;
//			anim.SetBool("isVisible", false);
		}
	}
}
