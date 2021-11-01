using UnityEngine;

public class MazeConstructor : MonoBehaviour {
    // Fields available in Inspector
    public bool showDebug;  // Toggles debug displays

    // Material for generated models, [SerializeField] attribute displays a field in the Inspector even if variable is private
    [SerializeField] private Material mazeMat;

    // Variable to store data generator for use
    private MazeDataGenerator dataGenerator;

    // 'public' keyword gives access outside this class
    // 'private set' makes read-only outside this class
    // Generated maze data is therefore read-only outside this class
    public int[,] data {
        get;
        private set;
    }

    void Awake() {
        // Default to walls surrounding empty cell
        data = new int[,] {
            {1, 1, 1},
            {1, 0, 1},
            {1, 1, 1}
        };

        dataGenerator = new MazeDataGenerator();
    }

    public void GenerateNewMaze(uint sizeRows, uint sizeCols) {
        // Odd numbers work better for size, as generated maze will be surrounded by walls
        if ((sizeRows % 2 == 0) && (sizeCols % 2 == 0)) {
            sizeRows += 1;
            sizeCols += 1;
        }

        data = dataGenerator.FromDimensions(ref sizeRows, ref sizeCols);
    }

    void OnGUI() {
        // Check if debug displays are enabled
        if (!showDebug) return;

        // Initialize local copy of stored maze, maze bounds, and debug msg string
        int[,] maze = data;
        int rowMax = maze.GetUpperBound(0);
        int colMax = maze.GetUpperBound(1);
        string msg = "";    // Provides ASCII visual preview of maze layout

        // Iterate over 2D matrix containing maze data, append visually simulated maze part to debug string
        for (int row = rowMax; row >= 0; row--) { 
            for (int col = 0; col <= colMax; col++) {
                if (maze[row, col] == 0)
                    msg += "....";
                else
                    msg += "==";
            }
            msg += "\n";
        }

        // Prints debug string to player GUI
        GUI.Label(new Rect(20, 20, 500, 500), msg);
    }
}