using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour {


	public void GoToScene() {
		Debug.Log("changed scene");
		SceneManager.LoadScene("Thing");
	}
}
