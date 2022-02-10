// REWORK TO CREATE RIGHT MENU

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handInteractionRight : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;

	public float throwForce = 1.5f;

	


	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}


	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}


	void onTriggerStay(Collider col) {

		// touching throwable object
		if (col.gameObject.CompareTag ("Throwable")) {

			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)) {
				ThrowObject (col);

			}
			else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
				GrabObject (col);

			}
		}

		if (col.gameObject.CompareTag ("Structure")) {
			if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
				GrabObject(col);
			}
		}
	}


	void GrabObject (Collider coli) {
		coli.transform.SetParent (gameObject.transform);
		coli.GetComponent<Rigidbody> ().isKinematic = true;
		device.TriggerHapticPulse (2000);

		Debug.Log ("Touching down trigger on an object.");
	}


	void ThrowObject(Collider coli) {

		coli.transform.SetParent (null);
		Rigidbody rigidBody = coli.GetComponent<Rigidbody> ();
		rigidBody.isKinematic = false;
		rigidBody.velocity = device.velocity * throwForce;
		rigidBody.angularVelocity = device.angularVelocity;

		Debug.Log ("You have released the trigger.");
	}

}
*/







using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handInteractionRight : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;

	public float throwForce = 1.5f;




	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}


	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}





	void OnTriggerStay (Collider col) {

        

        
		if (col.gameObject.CompareTag ("Ball")) {
            /*
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
				ThrowObject (col);
			}
				
			else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)) {
				GrabObject (col);
			}*/
		}

		if (col.gameObject.CompareTag ("Structure")) {
            		Debug.Log("touching structure");

			if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
                		Debug.Log("grabbed structure");
                		GrabObject(col);
			}
		}
	}


	void GrabObject (Collider coli) {
		coli.transform.SetParent (gameObject.transform);
		coli.GetComponent<Rigidbody> ().isKinematic = true;
		device.TriggerHapticPulse (2000);

		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {        
        	    ThrowObject(coli);
	        }

		Debug.Log ("Touching down trigger on an object.");

	}


	void ThrowObject(Collider coli) {

		coli.transform.SetParent (null);
		Rigidbody rigidBody = coli.GetComponent<Rigidbody> ();
		rigidBody.isKinematic = false;

		rigidBody.velocity = device.velocity * throwForce;
		rigidBody.angularVelocity = device.angularVelocity;

		Debug.Log ("You have released the trigger.");
	}

}
