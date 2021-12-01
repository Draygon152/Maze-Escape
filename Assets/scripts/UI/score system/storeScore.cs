using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class storeScore : MonoBehaviour {
    public GameObject scoreText;
    public static int theScore;

    void Update() {
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Gems: {theScore} / 16";
    }
}
