using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitsManager : MonoBehaviour {
	public PlayerHealth playerHealth;
	public static int hits;
	Text text;

	void Awake(){
		text = GetComponent<Text>();
		hits = 5;
	}

	// Update is called once per frame
	void Update () {
		text.text = "Health\n" + playerHealth.currentHealth;
	}
}
