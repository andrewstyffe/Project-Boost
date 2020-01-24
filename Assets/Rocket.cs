using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	Rigidbody rigidBody;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		processInput();
	}

	void processInput() {

		// Thrust while rotating
		if(Input.GetKey(KeyCode.Space)) {
			rigidBody.AddRelativeForce(Vector3.up);
			// So it doesn't layer
			if(!audioSource.isPlaying) {
				audioSource.Play();
			}
		} else {
			audioSource.Stop();
		}

		if(Input.GetKey(KeyCode.A)) {
			transform.Rotate(Vector3.forward);
		} else if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(-Vector3.forward);
		} 
	}
}
