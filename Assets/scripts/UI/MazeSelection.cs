using UnityEngine;
using UnityEngine.SceneManagement;
public class MazeSelection : MonoBehaviour
{
    public void RandomGenerate()
    {
        SceneManager.LoadScene("ProceduralMaze");
        Time.timeScale = 1f;
    }


    public void prefab()
    {
        SceneManager.LoadScene("PrefabMaze");
        Time.timeScale = 1f;
    }


    public void QuitGame()
    {
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}