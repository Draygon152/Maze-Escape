using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedReturnToMenu());
    }

    // Update is called once per frame
    IEnumerator DelayedReturnToMenu()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("WinScene");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

}
