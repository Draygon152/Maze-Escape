using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MazeSelection : MonoBehaviour
{
    public void RandomGenerate()
    {
        SceneManager.LoadScene("TestScene");
        
    }

    public void EasyS()
    {
        SceneManager.LoadScene("EasyScene");
    }

    public void MediumS()
    {
        SceneManager.LoadScene("MLScene1");
    }

    public void HardS()
    {
        SceneManager.LoadScene("HardScene");
    }


    public void QuitGame ()
    {
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }

    public void testforlight()
    {
        SceneManager.LoadScene("testForLight");
    }
}
