﻿using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	[SerializeField]
	float moveSpeed = 3.0f;
	[SerializeField]
	float gravity = 9.81f;

	private CharacterController myController;

	void Start () {
		myController = gameObject.GetComponent<CharacterController>();
	}
	
	void Update () {
		Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;
		Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;
		Vector3 movement = transform.TransformDirection(movementZ+movementX);
		movement.y -= gravity * Time.deltaTime;
		myController.Move(movement);
	}
}
