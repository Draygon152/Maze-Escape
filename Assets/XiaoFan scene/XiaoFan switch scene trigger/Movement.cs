using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movespeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;
        
        transform.Translate(xValue, 0, zValue);


    }

    void welcome()
    {
        Debug.Log("welcome");
    }
}
