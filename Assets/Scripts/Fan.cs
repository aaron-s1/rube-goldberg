using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {


	public Rigidbody ballRigid;
	public float power = 30f;

	void Awake() {
		ballRigid = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>();
	}


	void OnTriggerStay(Collider col) {
		
		if (col.gameObject.tag == "Ball") {

			ballRigid.AddForce(transform.forward * power, ForceMode.Acceleration);
			
		}
	}
}
