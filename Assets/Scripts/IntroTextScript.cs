using UnityEngine;
using System.Collections;

public class IntroTextScript : MonoBehaviour {

	Animator anim;

	bool hitRight;
	bool hitDown;
	bool hitSpace;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("isIntroOver", false);
		hitRight = false;
		hitDown = false;
		hitSpace = false;
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis ("Horizontal");
		if (inputX >= 0) {
			hitRight = true;
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			hitDown = true;
		}

		
		if (Input.GetKey (KeyCode.Space)) {
			hitSpace = true;
		}

		if (hitRight && hitDown && hitSpace) {
			anim.SetBool("isIntroOver", true);
		}
	}
}
