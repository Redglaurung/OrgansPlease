using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyOut : MonoBehaviour
{
    public GameObject tutorial;
    SpriteRenderer myRenderer;
    float opacity;
    float normalopacity;
    bool fadein;
    bool fadeout;
    // Start is called before the first frame update
    void Start()
    {
        fadein = true;
        fadeout = false;
        opacity = 1f;
        normalopacity = .3f;
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadein){
            if(opacity >=.002){
                opacity-=.002f;
                myRenderer.color = new Color(0f,0f,0f,opacity);
            } else {
                fadein=false;
                transform.position = new Vector3(26f,.5f,-3f);
            }
        } else if(fadeout){
            transform.position = new Vector3(0f,0f,-6f);
            if(opacity <=.998){
                opacity+=.002f;
                myRenderer.color = new Color(0f,0f,0f,opacity);
            } else {
                
            }
        } else {
            myRenderer.color = new Color(0f,0f,0f,normalopacity);
        }
    }
    public void FadeOut(){
        fadeout= true;
    }
    //places the desired tutorial on screen
    public void TutorialStart(int tutorialNum){
        tutorialNum--;
        transform.position = new Vector3(0f,0f,-6f);
        tutorial.transform.GetChild(tutorialNum).position = Vector3.zero;
    }
    //removes the desired tutorial from screen
    public void TutorialClose(int tutorialNum){
        tutorialNum--;
        transform.position = new Vector3(26f,.5f,-3f);
        tutorial.transform.GetChild(tutorialNum).position = new Vector3(26f,.5f,-3f);
    }
}
