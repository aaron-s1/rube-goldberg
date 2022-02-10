using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballCollision : MonoBehaviour {

    
    public Camera cameraRig;
    public Fading fadeToNextLevel;

    [Space(5)]

    public GameObject[] stars;
    public int starsLeft;

    [Space(10)]
    public GameObject antiCheatArea;
    private Material antiCheatColor;


    // ball	
    private Rigidbody ballRigid;
	private Material ballMat;
	private float bounceTimes = 4f;
	private bool ballActive = true;

	

	void Start () {        
		cameraRig = Camera.main;        

		ballRigid = gameObject.GetComponent<Rigidbody>();
        ballMat = GetComponent<Renderer>().material;
        antiCheatColor = antiCheatArea.GetComponent<Renderer>().material;
        
    stars = GameObject.FindGameObjectsWithTag("Collectible");
		starsLeft = stars.Length;  
	}
	
	
	// ANTI-CHEAT
	void FixedUpdate() {

		// camera is outside of location of platform
		// does not check back -- no need
		if ( (Mathf.Abs(cameraRig.transform.position.x) > 1f) || (cameraRig.transform.position.z > -1f) ) {

			if (ballActive) {
				ballActive = false;
				ballMat.color = Color.red;
                antiCheatColor.SetColor("_TintColor", Color.red);
                

				Physics.IgnoreLayerCollision(9, 10);
				Physics.IgnoreLayerCollision(9, 11);				
			}
		}

		else {
			
			if (!ballActive) {
				ballActive = true;
				ballMat.color = Color.white;
                antiCheatColor.SetColor("_TintColor", Color.green);


                Physics.IgnoreLayerCollision(9, 10, false);
				Physics.IgnoreLayerCollision(9, 11, false);				
			}
		}
	}



	void OnCollisionEnter(Collision col) {

		if (col.gameObject.CompareTag("Pedestal")) {

			ballRigid.velocity = new Vector3 (0, bounceTimes, 0);
			bounceTimes -= 1.2f;

			if (bounceTimes < -1.5) {
				bounceTimes = 0;
			}
		}
	}


	void OnTriggerEnter(Collider col) {
			
		if (col.gameObject.CompareTag("Collectible")) {
			col.gameObject.SetActive(false);

			starsLeft -= 1;
		}

		if (col.gameObject.CompareTag("Goal")) {
			if (starsLeft == 0) {
                Invoke("LoadNextLevel", 0.25f);
			}
		}

		if (col.gameObject.CompareTag("Floor")) {
			BallDropped();
		}

	}


	public void BallDropped() {
        transform.parent = null;
		starsLeft = stars.Length;		

		foreach (GameObject stars in stars) {
			stars.SetActive(true);
		}

		transform.position = new Vector3 (-0.005f, 3f, -1.18f);
		ballRigid.velocity = Vector3.zero;		
	}

    void LoadNextLevel()
    {
        fadeToNextLevel.GoFade();
    }


}