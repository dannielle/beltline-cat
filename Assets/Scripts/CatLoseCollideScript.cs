﻿using UnityEngine;
using System.Collections;

public class CatLoseCollideScript : MonoBehaviour {
	
	void Start () {
	}
	
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider) {
		string other = otherCollider.gameObject.name;
		if (other.Equals("player")) {
			transform.parent.GetComponent<CatBehaviorScript>().runAway();
			((GameScript) GameObject.Find("GameManager").GetComponent(typeof(GameScript))).lose();
		}
	}
}
