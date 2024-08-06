using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ballscript : MonoBehaviour
{
    public CircleCollider2D myColider;
    public Rigidbody2D myBallBody;

    public logic logical;
    
    public pSquarescript pSquareRef;
    public Squarescript SquareRef;
    
    float x = 0;
    float y = 0;
    int scoreL = 0;
    int scoreR = 0;
    float accell = 1;
    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        
        myBallBody.gravityScale = 0;
        logical = GameObject.FindGameObjectWithTag("Logic").GetComponent<logic>();
        pSquareRef = GameObject.FindGameObjectWithTag("pSquare").GetComponent<pSquarescript>();
        SquareRef = GameObject.FindGameObjectWithTag("Square").GetComponent<Squarescript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && start == false)
        {
            start = true;
            x = -5;
            y= Random.Range(-4,5);
        }
        myBallBody.velocity = new Vector2(x,y);
        
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
       
        if(collision.gameObject.name == "pSquare" || collision.gameObject.name == "Square"){   
            logical.BounceSfx(); 
            if (myBallBody.position.x > -9.66 && myBallBody.position.x < 9.66)
            {
                x = x * -1;
            }

            // accellerates the ball on tuch
            if(x<0){
                x = x - accell;
            }
            else{
                x = x + accell;
            }

            if (collision.gameObject.name == "pSquare")
            {
                // Ping + 1
                logical.addPing();

                // speeds ball.y up on contact 
                y= y + (pSquareRef.getPsquareY() / 2 );
            }
            if (collision.gameObject.name == "Square")
            {
                // Ping + 1
                logical.addPing();

                // speeds ball.y up on contact 
                y= y + (SquareRef.getSquareY() / 2 );
            }
        }

       if(collision.gameObject.name == "Roof" || collision.gameObject.name == "Floor"){
            
            y = y * -1;
            logical.BounceSfx(); 
            
              
        }
        if(collision.gameObject.name == "LeftWall" || collision.gameObject.name == "RightWall"){
            myBallBody.position = new Vector2(0,0); 
            x= -5;
            y= Random.Range(-4,5);
            logical.removePing();
            SquareRef.Transform.transform.position = new Vector2 (10,0);
            logical.GoalSfx();

            if (collision.gameObject.name == "LeftWall")
            {
                scoreR = scoreR + 1;
                logical.Score.text = scoreL.ToString() + "I" + scoreR.ToString();
            }
            else
            {
                scoreL =scoreL + 1;
                logical.Score.text = scoreL.ToString() + "I" + scoreR.ToString();
            }
        }
       
       
      
    }
    

    public float ballVelocityY(){
        return myBallBody.velocity.y;
    }

    public float ballPossitionX(){
        return myBallBody.position.x;
    }
    
    
}
    
        
