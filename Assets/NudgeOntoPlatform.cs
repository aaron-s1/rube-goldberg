using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NudgeOntoPlatform : MonoBehaviour {

	// If Rig gets near platform but 
	
	void Update () {		
        if (
            ( (gameObject.transform.position.z >= -4.1f) && (gameObject.transform.position.z <= 0.25f) ) ||
                (gameObject.transform.position.x >= -2.5f && gameObject.transform.position.x <= 2.5f)
           )
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.47f, gameObject.transform.position.z);
        }

    }
}
