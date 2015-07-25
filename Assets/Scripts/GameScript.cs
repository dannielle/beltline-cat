using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public enum State {
		Playing,
		Win,
		Lose
	}

	public static State state;
	GameObject replayButton;

	// Use this for initialization
	void Start () {
		state = State.Playing;
		replayButton = GameObject.Find ("replay-button");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void playingStateUI () {
		replayButton.GetComponent<ReplayButtonScript> ().hide ();
	}

	public void win () {
		state = State.Win;
		winStateUI ();
	}

	void winStateUI () {
		replayButton.GetComponent<ReplayButtonScript> ().show ();
	}

	public void restart () {
		state = State.Playing;
		Application.LoadLevel (Application.loadedLevelName);
	}
}
