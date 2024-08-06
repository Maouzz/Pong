using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squarescript : MonoBehaviour
{
    public ballscript ballscript; 
    public Rigidbody2D SquareBody;

    public Transform Transform;

    int SquareY;
    int SquareX;
    // Start is called before the first frame update
    void Start()
    {
       
        ballscript = GameObject.FindGameObjectWithTag("Ball").GetComponent<ballscript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ballscript.ballVelocityY() > 7 )
        {
            SquareBody.velocity = new Vector2 (0,7);
        }
        else
        {
            SquareBody.velocity = new Vector2 (0, ballscript.ballVelocityY());
        }

        if (ballscript.ballVelocityY() < -7 )
        {
            SquareBody.velocity = new Vector2 (0,-7);
        }
           
    }
    public float getSquareY(){
        return SquareBody.velocity.y;
    }
}
