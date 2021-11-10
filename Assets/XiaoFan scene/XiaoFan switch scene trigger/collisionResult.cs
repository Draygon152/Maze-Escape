
using UnityEngine;
using UnityEngine.SceneManagement;
public class collisionResult : MonoBehaviour
{   
    [SerializeField] AudioClip success;  //play auidoclip
    AudioSource audioSource;
    
    void OnCollisionEnter(Collision other) 
        
    
    {
        
        switch(other.gameObject.tag)
        {

            case "e":
                Debug.Log("Congradulation");
                LoadSceneWin();
                break;

            
        }

    }
    void LoadSceneWin()
    {
        //you can edit the scene
        SceneManager.LoadScene("WinScene"); //go to main menu, I don't change the name for WinScene
        //WinScene is stand for main menu
    }
}
