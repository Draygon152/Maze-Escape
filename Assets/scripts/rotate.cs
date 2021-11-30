using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Xangle = 0;
    [SerializeField] float Yangle = 0;
    [SerializeField] float Zangle = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Xangle,Yangle,Zangle);
    }
}
