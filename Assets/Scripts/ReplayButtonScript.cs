using UnityEngine;
using System.Collections;

public class ReplayButtonScript : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponent< Animator >();
		hide ();
	}
	
	void Update () {
		if (anim.GetBool("isShowing") && (Input.GetKeyDown (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) ) {
			((GameScript) GameObject.Find("GameManager").GetComponent(typeof(GameScript))).restart();
		}
		print (anim.GetBool ("isShowing"));
	}

	public void hide () {
		anim.SetBool ("isShowing", false);
	}

	public void show () {
		anim.SetBool ("isShowing", true);
	}
}
