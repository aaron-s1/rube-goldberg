using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerInputManager : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    /*public LayerMask laserMask;
    public LineRenderer laser;                         // laser pointer
    public GameObject teleportAimerObject;              // where you teleport to
    public Vector3 teleportLocation;                    // position at which you teleport to
    public GameObject player;                           // what to teleport
    public LayerMask lasermask;                         // what the raycast can collide with

    public float yNudgeAmount = 1f;                     // alters teleportAimerObject height 
    public float dashSpeed = 0.1f;
    public float moveSpeed = 4f;
    */

    public bool isActive;

    public ObjectMenuManager objectMenuManager;
    public GameObject objectMenu;

    private bool isDashing;
    private float lerpTime;
    private Vector3 dashStartPosition;
    public Transform playerCam;

    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasSwipedLeft;
    public bool hasSwipedRight;

    private Vector3 movementDirection;

    //[SerializeField]
    public bool leftHand;



    void Start() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        touchLast = 0f;                
    }


    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    
            

            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {                
                objectMenuManager.enabled = true;
                touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            }



            if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {

                OpenObjectMenu();

                touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
                distance = touchCurrent - touchLast;
                touchLast = touchCurrent;

                swipeSum += distance;


                if (!hasSwipedRight)
                {
                    if (swipeSum > 0.5f)
                    {
                        hasSwipedRight = true;
                        hasSwipedLeft = false;
                        swipeSum = 0;
                        SwipeRight();

                        
                        
                    }
                }


                if (!hasSwipedLeft)
                {
                    if (swipeSum < 0.5f)
                    {
                        hasSwipedLeft = true;
                        hasSwipedRight = false;
                        swipeSum = 0;
                        SwipeLeft();


                    }
                }
                /*
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    SpawnObject();
                }*/
            }

            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                swipeSum = 0;
                touchCurrent = 0;
                touchLast = 0;
                hasSwipedLeft = false;
                hasSwipedRight = false;

                CloseObjectMenu();
            }


            // Does it work? Try nested if statements otherwise? Try moving out of update? Try public Update?
            if (  (objectMenuManager.enabled == true) && (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))  ) { 
                SpawnObject();
            }

            //objectMenuManager.transform.GetChild(0).gameObject.SetActive(true);
        }    
    

	void SpawnObject() {
		objectMenuManager.SpawnCurrentObject ();       
	}

	void OpenObjectMenu() {
        objectMenu.SetActive(true);
        objectMenuManager.enabled = true;
	}

	void CloseObjectMenu() {
        objectMenu.SetActive(false);
        objectMenuManager.enabled = false;
	}

    void SwipeRight() {
        objectMenuManager.MenuRight();
    }

    void SwipeLeft() {
		objectMenuManager.MenuLeft();
	}


}