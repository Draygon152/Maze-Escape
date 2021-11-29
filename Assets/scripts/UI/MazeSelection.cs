using UnityEngine;
using UnityEngine.SceneManagement;
public class MazeSelection : MonoBehaviour {
    public void RandomGenerate() {
        SceneManager.LoadScene("ProceduralMaze");
    }


    public void prefab() {
        SceneManager.LoadScene("PrefabMaze");
    }


    public void QuitGame() {
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}