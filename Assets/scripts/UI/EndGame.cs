using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject Endtrigger;
    
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other) {
        Endtrigger.SetActive(true);
        Destroy(gameObject);

        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}