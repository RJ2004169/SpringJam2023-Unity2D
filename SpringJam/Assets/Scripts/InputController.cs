using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            PlayerController.PlayerUp();
        }
        else if(Input.GetButtonDown("Right"))
        {
            PlayerController.PlayerRight();
        }
        else if (Input.GetButtonDown("Left"))
        {
            PlayerController.PlayerLeft();
        }
    }
}
