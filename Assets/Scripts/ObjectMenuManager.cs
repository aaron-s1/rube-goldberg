using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMenuManager : MonoBehaviour {

    //public GameObject objectMenu;
    //[Space(10)]

    public int level;

    public GameObject objectMenu;
    public List<GameObject> objectList;
	public List<GameObject> objectPrefabList;

	public int currentObject = 0;

    private bool metalPlankLimitReached = false;
    private bool trampolineLimitReached = false;
    private bool woodPlankLimitReached = false;
    private bool warpLimitReached = false;
    private int trampolinesLeft = 2;


    void Start () {
		foreach (Transform child in transform) {
			objectList.Add (child.gameObject);
		}

        level = SceneManager.GetActiveScene().buildIndex;
	}


	public void MenuLeft() {
		objectList [currentObject].SetActive (false);
		currentObject--;

		if (currentObject < 0) {
			currentObject = objectList.Count - 1;   // should wrap around
		}

		objectList [currentObject].SetActive (true);
	}

	public void MenuRight() {
		objectList [currentObject].SetActive (false);
		currentObject++;

		if (currentObject > objectList.Count - 1) {
			currentObject = 0;
		}

		objectList [currentObject].SetActive (true);        
	}


    public void SpawnCurrentObject() {

        // Current Objects array order [0 to 3]: metal plank, trampoline, wood plank, warp area
        // Shown text limits of each game object are set manually within each object of each scene
        switch (level) {
            case 0:
                break;

            // metal plank + wood plank
            case 1:
                if ((currentObject == 0) && (!metalPlankLimitReached) ) {
                    objectList[0].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    metalPlankLimitReached = true;
                    SpawnIt();
                }

                else if ( (currentObject == 2) && (!woodPlankLimitReached) ) {
                    objectList[2].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    woodPlankLimitReached = true;
                    SpawnIt();
                }

                break;

            // metal plank + wood plank + trampoline
            case 2:
                if ((currentObject == 0) && (!metalPlankLimitReached) ) {
                    objectList[0].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    metalPlankLimitReached = true;
                    SpawnIt();
                } 

                else if ((currentObject == 2) && (!woodPlankLimitReached)) {
                    objectList[2].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    woodPlankLimitReached = true;
                    SpawnIt();
                }

                else if ((currentObject == 1) && (!trampolineLimitReached)) {
                    objectList[1].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    trampolineLimitReached = true;
                    SpawnIt();
                }
                break;

            // metal plank + wood plank + warp area
            case 3:
                if ((currentObject == 0) && (!metalPlankLimitReached)) {
                    objectList[0].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    metalPlankLimitReached = true;
                    SpawnIt();
                } 

                else if ((currentObject == 2) && (!woodPlankLimitReached)) {
                    objectList[2].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    woodPlankLimitReached = true;
                    SpawnIt();
                }

                else if ((currentObject == 3) && (!warpLimitReached)) {
                    objectList[3].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    warpLimitReached = true;
                    SpawnIt();
                }
                break;


            // metal plank + trampoline(x2) + warp area
            case 4:

                if ((currentObject == 0) && (!metalPlankLimitReached) ) {
                    objectList[0].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    metalPlankLimitReached = true;
                    SpawnIt();
                }

                else if ((currentObject == 1) && (!trampolineLimitReached)) {
                    if (trampolinesLeft != 0) {
                        trampolinesLeft--;
                        objectList[1].GetComponentInChildren<TextMesh>().text = "Remaining: " + trampolinesLeft.ToString();
                    }

                    SpawnIt();
                }

                else if ((currentObject == 3) && (!warpLimitReached)) {
                    objectList[currentObject].GetComponentInChildren<TextMesh>().text = "Remaining: 0";
                    warpLimitReached = true;
                    SpawnIt();
                }

                break;


            default:
                break;
        }
    }

    public void SpawnIt() {
        Instantiate(
            objectPrefabList[currentObject],                // work? try (abs) on object array checks?
            objectList[currentObject].transform.position,            
            objectPrefabList[currentObject].transform.rotation);
      
        
        if (trampolinesLeft == 0) {
            trampolineLimitReached = true;
        }
    }

}
