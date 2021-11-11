using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RG_Maze : MonoBehaviour
{
    //public bool ingame = true;
    public void RandomGenerate()
    {
        SceneManager.LoadScene("TestScene");
        Cursor.visible = false;
    }

    public void EasyS()
    {
        SceneManager.LoadScene("EasyScene");
        Cursor.visible = false;
    }   

    public void MediumS()
    {
        SceneManager.LoadScene("MLScene1");
        Cursor.visible = false;
    }

    public void HardS()
    {
        SceneManager.LoadScene("HardScene");
        Cursor.visible = false;
    }


    public void QuitGame ()
    {
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
    
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.B))
            Cursor.visible = true;
        switchscene();
        
    }
    void switchscene()
    {
        if(Input.GetKeyDown(KeyCode.B))
            SceneManager.LoadScene("MainMenu");
    }


}
