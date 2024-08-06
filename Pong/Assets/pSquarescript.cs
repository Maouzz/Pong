using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pSquarescript : MonoBehaviour
{
    public Rigidbody2D mySquareBody;

    public Transform Transform;
    bool spaceUsed = false;
    public SpriteRenderer SpriteRenderer;
    public ParticleSystem ParticleSystem;
    public Transform ParticleTransform;
    public logic logical;

    int count = 1300;
    
    // Start is called before the first frame update
    void Start()
    {
        mySquareBody.gravityScale = 0;
        SpriteRenderer = GameObject.FindGameObjectWithTag("DashIndicator").GetComponent<SpriteRenderer>();
        ParticleSystem = GameObject.FindGameObjectWithTag("DashParticles").GetComponent<ParticleSystem>();
        logical = GameObject.FindGameObjectWithTag("Logic").GetComponent<logic>();
        ParticleTransform = GameObject.FindGameObjectWithTag("DashParticles").GetComponent<Transform>();
        ParticleSystem.GetComponent<ParticleSystem>().Pause();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            mySquareBody.velocity = Vector2.down * 7 ;
        }
        if (Input.GetKeyDown(KeyCode.W)){
            mySquareBody.velocity = Vector2.down * -7 ;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) )
        {
            mySquareBody.velocity = new Vector2(0,0);
        }
        
        //Dash
        if(Input.GetKeyDown(KeyCode.Space)){
            if (spaceUsed == false )
            {
                
                //PVelocity down
                if (mySquareBody.velocity.y < 0 )
                {   
                    //sound
                logical.DashSfx();
                    //particles
                    ParticleTransform.transform.position = new Vector2 (-10, mySquareBody.position.y);
                    ParticleSystem.GetComponent<ParticleSystem>().Play();
                    spaceUsed = true;

                    if (mySquareBody.position.y < -1.45)
                    {
                        Transform.transform.position = new Vector2 (-10,-4);
                    }
                    else
                    {
                        Transform.transform.position = new Vector2 (-10,mySquareBody.position.y - 5);
                    }
                    
                    
                    //indicator colorchange
                    SpriteRenderer.color = new Color (0F,0F,0F,0F);
                    
                }
                //PVelocity up
                if(mySquareBody.velocity.y > 0)
                {
                    //sound
                    logical.DashSfx();
                    //particles
                    ParticleTransform.transform.position = new Vector2 (-10, mySquareBody.position.y);
                    ParticleSystem.GetComponent<ParticleSystem>().Play();
                    spaceUsed = true;

                    if (mySquareBody.position.y > 1.45)
                    {
                        Transform.transform.position = new Vector2 (-10,4);
                    }
                    else
                    {
                        Transform.transform.position = new Vector2 (-10,mySquareBody.position.y + 5);
                    }
                    
                    //indicator colorchange
                    SpriteRenderer.color = new Color (0F,0F,0F,0F);
                }
           
            }
            
            
        }
        if (spaceUsed == true)
        {
            count -= 1; 
            SpriteRenderer.color += new Color (0F,0F,0F,0.0008F);
            
        }
        if (count == 0)
        {   //indicator colorchange
            SpriteRenderer.color = new Color (0F,1F,0F,1F);
            spaceUsed = false;
            count = 1300;
        }
               
    }

    public float getPsquareY(){
        return mySquareBody.velocity.y;
    }

    
        
    

}
