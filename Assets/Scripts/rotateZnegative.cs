using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateZnegative : MonoBehaviour {

	
	void Update () {
		gameObject.transform.Rotate(Vector3.back * Time.deltaTime * 100);
	}
}
