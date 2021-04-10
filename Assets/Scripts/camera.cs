using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class camera : MonoBehaviour {

    public Camera mainCamera;
    public GameObject player;
    void Update() {
        if (player) {
            mainCamera.GetComponent<Transform>().position = player.GetComponent<Transform>().position - new Vector3(0,0,10);
        }
        
    }
}