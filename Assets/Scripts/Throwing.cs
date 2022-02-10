using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throwing : MonoBehaviour {
    
    public GameObject screens;
    public bool screensActive = true;

    public SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
   

    void Start () {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "Scene 0") {
            screensActive = false;
        }

		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}


	public void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {

            if (screensActive)
            {
                screens.SetActive(false);
                screensActive = false;
            }

            else if (!screensActive)
            {
                screens.SetActive(true);
                screensActive = true;
            }
        }

        

    }


	void OnTriggerStay(Collider col) {	
		if (  (col.gameObject.CompareTag ("Ball")) || (col.gameObject.CompareTag("Structure")) ) {
			if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
				GrabObject (col);
			}
			else if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)) {
				ThrowObject (col);
			}				
		}
	}


	void GrabObject (Collider coli) {
		coli.transform.SetParent (gameObject.transform);
		coli.GetComponent<Rigidbody> ().isKinematic = true;
		device.TriggerHapticPulse (2000);		
	}




	void ThrowObject(Collider coli) {

		Rigidbody rigidBody = coli.GetComponent<Rigidbody> ();

		// if grabbed object is Ball, add physics and momentum when thrown
		if (coli.gameObject.CompareTag ("Ball")) {
			rigidBody.isKinematic = false;
            rigidBody.velocity = new Vector3(0f, 0f, 0f);
            rigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
        } 

		coli.transform.SetParent (null);		
	}

}

