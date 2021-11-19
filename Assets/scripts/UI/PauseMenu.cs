using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    
    public GameObject PauseMenuUI;

    //public GameObject helpUI;
    // Update is called once per frame
    void Update() { 
        if(Input.GetKeyDown(KeyCode.Tab)) {
            if (GameIsPaused)
                Resume();
                
            else {
                Pause();
                enableCursor();
            } 
        }
    }
    

    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        disableCursor();
    }


    public void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    

    public void menu() {
        SceneManager.LoadScene("MainMenu");
        enableCursor();
    }
    

    public void enableCursor() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }


    public void disableCursor() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
