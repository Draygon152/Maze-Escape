using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.B)) {
            SceneManager.LoadScene("WinScene");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
