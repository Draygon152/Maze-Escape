using System.Collections.Generic;
using UnityEngine;

// Does not inherit from MonoBehavior, since it is not directly used as a component,
// just a supporting object from within MazeConstructor

// Holds logic for generating maze data, wall placement
public class MazeDataGenerator {
    // Chance that an empty space is generated
    public float placementThreshold;

    public MazeDataGenerator() {
        // Used by data generation algorithm to determine whether space is empty
        // Initialized to default value in constructor, public so other code can change
        placementThreshold = .1f;
    }

    public int[,] FromDimensions(ref uint sizeRows, ref uint sizeCols) {
        int[,] maze = new int[sizeRows, sizeCols];
        int rowMax = maze.GetUpperBound(0);
        int colMax = maze.GetUpperBound(1);

        for (uint row = 0; row <= rowMax; row++) { 
            for (uint col = 0; col <= colMax; col++) {
                // For every "tile" of the maze, check if it's on the outside. If so, assign wall
                if (row == 0 || col == 0 || row == rowMax || col == colMax)
                    maze[row, col] = 1;

                // Checks if "tile" coordinates are even, to assign to every other "tile"
                // Also checks against placement threshold to see if this "tile" should be randomly skipped
                else if ((row % 2 == 0) && (col % 2 == 0)) { 
                    if (Random.value > placementThreshold) {
                        // Assigns wall to current cell and randomly chosen adjacent cell if not skipped
                        maze[row, col] = 1;

                        // Ternary operators used to randomly add 0, 1, or -1 to array index, allowing
                        // for random navigation to adjacent cells
                        int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                        int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);

                        maze[row + a, col + b] = 1;
                    }
                }
            }
        }

        return maze;
    }
}