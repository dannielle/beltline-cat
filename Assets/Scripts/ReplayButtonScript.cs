using UnityEngine;
using System.Collections;

public class ReplayButtonScript : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponent< Animator >();
		anim.SetBool ("isShowing", false);
	}
	
	void Update () {
		if (anim.GetBool("isShowing") && (Input.GetKeyDown (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter))) {
			((GameScript) GameObject.Find("GameController").GetComponent(typeof(GameScript))).restart();
		}
	}

	public void hide () {
		anim.SetBool ("isShowing", false);
	}

	public void show () {
		anim.SetBool ("isShowing", true);
	}
}
