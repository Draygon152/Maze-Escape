using System.Collections.Generic;
using UnityEngine;

// Contains logic for maze mesh generation
public class MazeMeshGenerator {
    public float width;     // Width of hallways
    public float height;    // Height of hallways


    public MazeMeshGenerator() {
        width = 3.75f;
        height = 3.5f;
    }


    // Generates maze's mesh from provided data in 2D array
    public Mesh FromData(int[,] data) {
        Mesh maze = new Mesh();

        // Lists to hold data that will be set within the maze mesh
        List<Vector3> newVertices = new List<Vector3>();
        List<Vector2> newUVs = new List<Vector2>();

        // Each list of triangles is a different sub-mesh, so that
        // different materials can be assigned to the floor and walls
        maze.subMeshCount = 2;
        List<int> floorTriangles = new List<int>();
        List<int> wallTriangles = new List<int>();

        int rMax = data.GetUpperBound(0);
        int cMax = data.GetUpperBound(1);
        float halfH = height * .5f;

        // Iterate through 2D array, build quads for floor, ceiling, and
        // walls at every grid cell. AddQuad() is called repeatedly with
        // different transform matrices each time, and different triangle
        // lists are used for floors and walls. Width and height are used
        // to determine where quads are positioned and how big they are.
        for (int i = 0; i <= rMax; i++) {
            for (int j = 0; j <= cMax; j++) {
                if (data[i, j] != 1) {
                    // Generate floor quad
                    AddQuad(Matrix4x4.TRS(new Vector3(j * width, 0, i * width),
                                          Quaternion.LookRotation(Vector3.up),
                                          new Vector3(width, width, 1)),
                            ref newVertices, ref newUVs, ref floorTriangles);

                    // Generate ceiling quad
                    AddQuad(Matrix4x4.TRS(new Vector3(j * width, height, i * width),
                                          Quaternion.LookRotation(Vector3.down),
                                          new Vector3(width, width, 1)),
                            ref newVertices, ref newUVs, ref floorTriangles);


                    // Generate side walls
                    if (i - 1 < 0 || data[i - 1, j] == 1) {
                        AddQuad(Matrix4x4.TRS(new Vector3(j * width, halfH, (i - .5f) * width),
                                              Quaternion.LookRotation(Vector3.forward),
                                              new Vector3(width, height, 1)),
                                ref newVertices, ref newUVs, ref wallTriangles);
                    }

                    if (j + 1 > cMax || data[i, j + 1] == 1) {
                        AddQuad(Matrix4x4.TRS(new Vector3((j + .5f) * width, halfH, i * width),
                                              Quaternion.LookRotation(Vector3.left),
                                              new Vector3(width, height, 1)),
                                ref newVertices, ref newUVs, ref wallTriangles);
                    }

                    if (j - 1 < 0 || data[i, j - 1] == 1) {
                        AddQuad(Matrix4x4.TRS(new Vector3((j - .5f) * width, halfH, i * width),
                                              Quaternion.LookRotation(Vector3.right),
                                              new Vector3(width, height, 1)),
                                ref newVertices, ref newUVs, ref wallTriangles);
                    }

                    if (i + 1 > rMax || data[i + 1, j] == 1) {
                        AddQuad(Matrix4x4.TRS(new Vector3(j * width, halfH, (i + .5f) * width),
                                              Quaternion.LookRotation(Vector3.back),
                                              new Vector3(width, height, 1)),
                                ref newVertices, ref newUVs, ref wallTriangles);
                    }
                }
            }
        }

        maze.vertices = newVertices.ToArray();
        maze.uv = newUVs.ToArray();

        maze.SetTriangles(floorTriangles.ToArray(), 0);
        maze.SetTriangles(wallTriangles.ToArray(), 1);

        // Prepares mesh for lighting
        maze.RecalculateNormals();

        return maze;
    }


    // newVertices, newUVs, and newTriangles are the list of vertices, UVs, and triangles
    // that will be appended to before being set in the Mesh.
    // matrix is a transformation matrix, storing a position/rotation/scale to be applied
    // to the vertices. This is to make it possible to re-use the quad generation code for
    // floors, walls, and other surfaces.
    private void AddQuad(Matrix4x4 matrix, ref List<Vector3> newVertices,
    ref List<Vector2> newUVs, ref List<int> newTriangles) {
        // Gets start index
        int index = newVertices.Count;

        // Vertex corners before transform
        Vector3 vert1 = new Vector3(-.5f, -.5f, 0);
        Vector3 vert2 = new Vector3(-.5f, .5f, 0);
        Vector3 vert3 = new Vector3(.5f, .5f, 0);
        Vector3 vert4 = new Vector3(.5f, -.5f, 0);

        newVertices.Add(matrix.MultiplyPoint3x4(vert1));
        newVertices.Add(matrix.MultiplyPoint3x4(vert2));
        newVertices.Add(matrix.MultiplyPoint3x4(vert3));
        newVertices.Add(matrix.MultiplyPoint3x4(vert4));

        newUVs.Add(new Vector2(1, 0));
        newUVs.Add(new Vector2(1, 1));
        newUVs.Add(new Vector2(0, 1));
        newUVs.Add(new Vector2(0, 0));

        newTriangles.Add(index + 2);
        newTriangles.Add(index + 1);
        newTriangles.Add(index);

        newTriangles.Add(index + 3);
        newTriangles.Add(index + 2);
        newTriangles.Add(index);
    }
}
