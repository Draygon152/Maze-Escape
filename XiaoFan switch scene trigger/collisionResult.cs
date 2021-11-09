
using UnityEngine;
using UnityEngine.SceneManagement;
public class collisionResult : MonoBehaviour
{   
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
        SceneManager.LoadScene(2); // scene display you win
    }
}
