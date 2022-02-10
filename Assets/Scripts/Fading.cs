using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

    // manually set on each scene
    public string scene;
    public Color loadToColor = Color.black;

    public void GoFade() {
        Initiate.Fade(scene, loadToColor, 0.25f);
    }
}
