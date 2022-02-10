using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {
    
    public Fading resetGame;

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Floor")) {
            resetGame.GoFade();
        }
    }

}