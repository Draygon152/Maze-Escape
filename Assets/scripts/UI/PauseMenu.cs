using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    
    
    
    public GameObject PauseMenuUI;
    //public GameObject helpUI;
    // Update is called once per frame
    void Update()
    { 
        

        if(Input.GetKeyDown(KeyCode.Tab))
            {
                cursor();
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();

                }
            }
        
    }
    

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }

    public void Pause ()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;

        }
    
    public void menu(){
        SceneManager.LoadScene("MainMenu");
    }
    
    void cursor(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
