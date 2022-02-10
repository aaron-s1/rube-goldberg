using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    // Zoom zoom ball mechanics


    // set publically    
    public GameObject warpExit;
    public GameObject warpShootBallTo;

    private GameObject ball;
    private Rigidbody ballRigid;
    private bool insideWarpZone = false;
    private bool exitingWarp = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball") {
            ball = other.gameObject;
            ballRigid = ball.GetComponent<Rigidbody>();
            
            other.transform.SetParent(transform);            
            insideWarpZone = true;                        
        }
    }

    public void FixedUpdate()
    {        
        if (insideWarpZone)
        {

            if (ball.transform.parent != null) {
                ball.transform.SetParent(null);
                ballRigid.useGravity = true;
            }
                
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, warpExit.transform.position, 0.1f);

            if (Vector3.Distance(ball.transform.position, warpExit.transform.position) <= 0.2f) {
                 insideWarpZone = false;
                 exitingWarp = true;
             }            
        }

        if (exitingWarp)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, warpShootBallTo.transform.position, 0.2f);            
            Invoke("ResetPhysics", 0.2f);
        }
        
    }

    public void ResetPhysics()
    {
        exitingWarp = false;
        ballRigid.useGravity = true;
        ballRigid.isKinematic = false;        
    }
}
