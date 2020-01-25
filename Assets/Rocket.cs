using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	[SerializeField] float rcsThrust = 100f;
	[SerializeField] float mainThrust = 100f;
	Rigidbody rigidBody;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		thrust();
		rotate();
	}

	void OnCollisionEnter(Collision collision) {
		switch(collision.gameObject.tag) {
			case "Friendly":
				print("Friendly");
				break;
			case "Deadly":
				print("Deadly");
				break;
		}
	}

	void thrust() {
		// Thrust while rotating
		if(Input.GetKey(KeyCode.Space)) {
			rigidBody.AddRelativeForce(Vector3.up * mainThrust);
			// So it doesn't layer
			if(!audioSource.isPlaying) {
				audioSource.Play();
			}
		} else {
			audioSource.Stop();
		}
	}

	void rotate() {

		rigidBody.freezeRotation = true; //Physics are enabled while we are actively rotating
		float rotationThisFrame = rcsThrust * Time.deltaTime;

		if(Input.GetKey(KeyCode.A)) {
			transform.Rotate(Vector3.forward * rotationThisFrame);
		} else if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(-Vector3.forward * rotationThisFrame);
		} 

		rigidBody.freezeRotation = false; //Physics are disabled once we stop actively rotating
	}
}
