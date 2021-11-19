using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helper : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool HelpOut = true;
    public GameObject helpUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
            {
                if (HelpOut)
                {
                    close_Help ();
                }
                else
                {
                    open_Help  ();
                }
            }
    }
    public void close_Help ()
    {
        helpUI.SetActive(false);
        HelpOut = false;
    }

    public void open_Help()
    {
        helpUI.SetActive(true);
        HelpOut = true;
    }
}
