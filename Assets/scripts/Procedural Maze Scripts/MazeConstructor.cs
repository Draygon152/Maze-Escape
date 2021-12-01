using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
    // Fields available in Inspector
    public bool showDebug;  // Toggles debug displays

    // Materials for generated meshes, [SerializeField] attribute displays a field in the Inspector even if variable is private
    [SerializeField] private Material floorMat;
    [SerializeField] private Material wallMat;
    [SerializeField] private Material goalMat;
    [SerializeField] private GameObject goalTrigger;

    // Variables to store data and mesh generators
    private MazeDataGenerator dataGenerator;
    private MazeMeshGenerator meshGenerator;

    // 'public' keyword gives access outside this class
    // 'private set' makes read-only outside this class
    // Generated maze data is therefore read-only outside this class
    public int[,] data      { get; private set; }
    public float hallWidth  { get; private set; }
    public float hallHeight { get; private set; }
    public int startRow     { get; private set; }
    public int startCol     { get; private set; }
    public int goalRow      { get; private set; }
    public int goalCol      { get; private set; }


    // Runs on start
    void Awake() {
        // Default to walls surrounding empty cell
        data = new int[,] {
            {1, 1, 1},
            {1, 0, 1},
            {1, 1, 1}
        };

        // Instantiate generators
        dataGenerator = new MazeDataGenerator();
        meshGenerator = new MazeMeshGenerator();
    }


    public void GenerateNewMaze(ref uint sizeRows, ref uint sizeCols,
                                TriggerEventHandler goalCallback = null) {
        // Generate maze data
        data = dataGenerator.FromDimensions(ref sizeRows, ref sizeCols);

        // Find where to place start and end points, stored in startRow, startCol, goalRow, goalCol
        FindStartPosition();
        FindGoalPosition();

        // Store values used to generate mesh
        hallWidth = meshGenerator.width;
        hallHeight = meshGenerator.height;

        DisplayMaze();

        PlaceGoalTrigger(goalCallback);
    }


    // Not used in code, specifically for Unity debug
    void OnGUI() {
        // Only display if debug displays are enabled
        if (!showDebug) return;

        // Initialize local copy of stored maze, maze bounds, and debug msg string
        int[,] maze = data;
        int rowMax = maze.GetUpperBound(0);
        int colMax = maze.GetUpperBound(1);
        string msg = "";    // Will be used to store ASCII preview of maze layout

        // Iterate over 2D matrix containing maze data, append parts to debug string
        for (int row = rowMax; row >= 0; row--) {
            for (int col = 0; col <= colMax; col++) {
                // If coordinate contains empty space
                if (maze[row, col] == 0)
                    msg += "....";
                // Otherwise, if coordinate contains a wall placement
                else
                    msg += "==";
            }
            // Move to next row
            msg += "\n";
        }

        // Prints debug string to player GUI
        GUI.Label(new Rect(20, 20, 500, 500), msg);
    }


    private void DisplayMaze() {
        GameObject go = new GameObject();
        go.transform.position = Vector3.zero;
        go.name = "Procedural Maze";
        go.tag = "Generated";

        // Meshes are only data, and are not visible until assigned to an object's MeshFilter in a scene
        // As a result, DisplayMaze doesn't only call FromData, it inserts that call in the middle of
        // instantiating a new GameObject, setting the "Generated" tag, adding a MeshFilter and the
        // generated mesh, adding a MeshCollider for colliding with the maze, and finally adding a
        // MeshRenderer and the materials used.
        MeshFilter mf = go.AddComponent<MeshFilter>();
        mf.mesh = meshGenerator.FromData(data);

        MeshCollider mc = go.AddComponent<MeshCollider>();
        mc.sharedMesh = mf.mesh;

        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        mr.materials = new Material[2] { floorMat, wallMat };
    }


    public void DisposeOldMaze() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Generated");
        foreach (GameObject go in objects)
            Destroy(go);
    }


    private void FindStartPosition() {
        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        // Loop from bottom to top, left to right
        for (int i = 0; i <= rMax; i++) {
            for (int j = 0; j <= cMax; j++) {
                if (maze[i, j] == 0) {
                    startRow = i;
                    startCol = j;
                    return;
                }
            }
        }
    }


    private void FindGoalPosition() {
        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        // Loop from top to bottom, right to left
        for (int i = rMax; i >= 0; i--) { 
            for (int j = cMax; j >= 0; j--) { 
                if (maze[i, j] == 0) {
                    goalRow = i;
                    goalCol = j;
                    return;
                }
            }
        }
    }


    // Callback argument takes a function to call when something enters trigger volume
    private void PlaceGoalTrigger(TriggerEventHandler callback) {
        GameObject go = Instantiate(goalTrigger);
        go.transform.position = new Vector3(goalCol * hallWidth, 1, goalRow * hallWidth);
        go.name = "Goal Trigger";
        go.tag = "Generated";

        go.GetComponent<BoxCollider>().isTrigger = true;
        //go.GetComponent<MeshRenderer>().sharedMaterial = goalMat;

        TriggerEventRouter tc = go.AddComponent<TriggerEventRouter>();
        tc.callback = callback;
    }
}