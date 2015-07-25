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

	void Start () {
		state = State.Playing;
		replayButton = GameObject.Find ("replay-button");
	}
	
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

	public void lose() {
		state = State.Lose;
		loseStateUI ();
	}

	void loseStateUI() {
		replayButton.GetComponent<ReplayButtonScript> ().show ();
	}

	public void restart () {
		state = State.Playing;
		Application.LoadLevel (Application.loadedLevelName);
	}
}
