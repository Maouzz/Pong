using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class logic : MonoBehaviour
{
    public Text text;

    public Text Score;
    public int Ping = 0;
    public SpriteRenderer BackgroundSpriteRenderer;
    public ballscript ballscript;
    int x = 0;
    public AudioSource Src;
     public AudioSource DashSrc;
    public AudioClip sfx1, sfx2, sfx3;

    void Start(){
        BackgroundSpriteRenderer = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
        ballscript = GameObject.FindGameObjectWithTag("Ball").GetComponent<ballscript>();
        Ping = 0;
        text.text = Ping.ToString();
        BackgroundSpriteRenderer.color = new Color (1F, 1F ,1F);
    }
    void Update(){
        if (x > 0)
        {
            BackgroundSpriteRenderer.color -= new Color (0F,0.0002F,0.0002F,0F);
            x-=1;
            
        }
        if (x < 0)
        {
            BackgroundSpriteRenderer.color += new Color(0F,0.007F,0.007F,0F);
            x += 1;
        
        }
        if (Ping == 1)
        {
            BackgroundSpriteRenderer.color = new Color(1F,1F,1F,1F);
        }
       
        
    }
    
    [ContextMenu("addPing")]
    public void addPing(){
        Ping += 1;
        text.text = Ping.ToString();
        x = 200; 
        
    }
    

    public void removePing(){
        
        Ping = 0;
        text.text = Ping.ToString();
        x = -400;
    }

    public void BounceSfx(){
        Src.clip = sfx1;
        Src.Play();
    }
    public void DashSfx(){
        DashSrc.clip = sfx2;
        DashSrc.Play();
    }
    public void GoalSfx(){
        Src.clip = sfx3;
        Src.Play();
    }
}  
