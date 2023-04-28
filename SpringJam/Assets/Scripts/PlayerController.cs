using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private static bool Jump = false;
    private static bool Right = false;
    private static bool Left = false;

    public GameObject player;
    public Vector2 jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Jump==true)
        {
            Jump = false;
            player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        if(Right == true)
        {
            Right = false;
            player.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 5, ForceMode2D.Impulse);
        }
        if(Left == true)
        {
            Left = false;
            player.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 5, ForceMode2D.Impulse);
        }
    }

    public static void PlayerUp()
    {
        Jump = true;
    }
    public static void PlayerRight()
    {
        Right = true;
    }
    public static void PlayerLeft()
    {
        Left = true;
    }

}
