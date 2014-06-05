﻿using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	private NetworkManagerScript networkManager;
	public string type;

	// Use this for initialization
	void Awake () {
		networkManager = GameObject.Find ("Game Controller").transform.Find ("Network Manager").gameObject.GetComponent<NetworkManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		string playerTag = (Network.isClient) ? "Player2" : "Player1";
		if (other.gameObject.CompareTag(playerTag)) {
			PlayerStats stats = other.GetComponent<PlayerStats>();

			switch(type) {
				case "health": 
					stats.currentHP += 10;
					if(stats.currentHP > stats.MaxHP) stats.currentHP = stats.MaxHP;
					break;
				case "magic": break;
				case "food": 
					stats.currentHunger += 10;
					if(stats.currentHunger > stats.MaxHunger) stats.currentHunger = stats.MaxHunger;
				break;
			}
//			Debug.Log(networkManager.isOnline);
//			if (networkManager.isOnline)
//				Network.Destroy (this.gameObject);
//			else
				Destroy (this.gameObject);
		}
	}
}
