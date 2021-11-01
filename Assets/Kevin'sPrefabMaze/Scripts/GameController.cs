using System;
using UnityEngine;


// Ensures MazeConstructor component will also be added when this script is added to a GameObject
[RequireComponent (typeof(MazeConstructor))]

public class GameController : MonoBehaviour {
    private MazeConstructor generator;

    void Start() {
        // Variable storing reference returned by GetComponent()
        generator = GetComponent<MazeConstructor>();
        generator.GenerateNewMaze(13, 15);
    }
}