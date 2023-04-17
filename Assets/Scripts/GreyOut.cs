using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyOut : MonoBehaviour
{

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
            if(opacity >=.001){
                opacity-=.001f;
                myRenderer.color = new Color(0f,0f,0f,opacity);
            } else {
                fadein=false;
                transform.position = new Vector3(26f,.5f,-3f);
            }
        } else if(fadeout){
            if(opacity <=.999){
                opacity+=.001f;
                myRenderer.color = new Color(0f,0f,0f,opacity);
            } else {
                fadeout=false;
            }
        } else {
            myRenderer.color = new Color(0f,0f,0f,normalopacity);
        }
    }
    public void FadeOut(){
        fadeout= true;
    }
}
