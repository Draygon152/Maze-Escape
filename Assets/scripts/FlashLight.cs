using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private AudioSource flashlightSound;
    public bool on = true;

    void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            on = !on;
            flashlightSound.Play();
        }
            
        if(on)
            GetComponent<Light>().enabled = true;
        else if(!on)
            GetComponent<Light>().enabled = false;
    }
}
