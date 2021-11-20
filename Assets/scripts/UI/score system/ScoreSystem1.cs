using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreSystem1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scoreText;
    
    public AudioSource collectSound;

        
        


    public void OnTriggerEnter(Collider other) {
        
    
        collectSound.Play();
        storeScore.theScore += 1;
        Destroy(gameObject);
        

        
    }
}
