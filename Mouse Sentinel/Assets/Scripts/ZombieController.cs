﻿using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	GameMaster gameMaster;
	GameObject ObjectLayer;

	GameObject CPU;

	private int moveSpeed;

	// Use this for initialization
	void Start () {

		gameMaster = GameObject.Find ("GameMaster").transform.GetComponent<GameMaster> ();

		ObjectLayer = GameObject.Find ("ObjectLayer").gameObject;

		CPU = ObjectLayer.transform.GetChild(0).gameObject;

		moveSpeed = gameMaster.ZOMBIE_SPEED;

	}
	
	// Update is called once per frame
	void Update () {

		this.gameObject.transform.position = Vector3.MoveTowards (transform.position, CPU.transform.position, (moveSpeed * Time.deltaTime));
	
	}

	public void changeSpeed(int newSpeed) {

		moveSpeed = newSpeed;

	}
}