using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class storeScore : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Gem: {theScore} / 16";

        
    
    }
}
