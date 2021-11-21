using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndByScore : MonoBehaviour
{
    public static int desireScore = 16;
    public int Score = 0;
    public GameObject winScene;

    public void OnTriggerEnter(Collider other) {
        
        Score += 1;
        
    }

    void Update() {
        if (Score >= desireScore)
        {
            winScene.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        
        
    }

    
}
