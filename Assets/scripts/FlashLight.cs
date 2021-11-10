using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update
    public bool on = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
            on = !on;
        if(on)
            GetComponent<Light>().enabled = true;
        else if(!on)
            GetComponent<Light>().enabled = false;
    }
}
