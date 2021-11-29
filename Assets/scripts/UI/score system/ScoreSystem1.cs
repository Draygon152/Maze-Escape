using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem1 : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject scoreText;
    public GameObject winScene;
    [SerializeField] int Desire_gems = 0;
    public AudioSource collectSound;

    public void OnTriggerEnter(Collider other) {
        collectSound.Play();
        storeScore.theScore += 1;
        Destroy(gameObject);
    }

    public void Complete_gem() {
        winScene.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
