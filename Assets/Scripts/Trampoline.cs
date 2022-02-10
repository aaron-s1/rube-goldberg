using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline: MonoBehaviour {

	public float trampolineForce = 0.7f;

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.CompareTag("Ball")) {			
			col.rigidbody.AddForce(transform.forward * trampolineForce, ForceMode.Impulse);
		}			
	}

}
