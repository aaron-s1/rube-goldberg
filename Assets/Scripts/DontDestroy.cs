using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    
    // Prevent destroying background music or CameraRig when changing scenes    

    public void Awake() {
        GameObject[] music = GameObject.FindGameObjectsWithTag("music");
                
        if (music.Length > 1) {
            if (gameObject.name != "[CameraRig]") {
                Destroy(this.gameObject);
            }
        }
        
        DontDestroyOnLoad(this.gameObject);
    }
}
