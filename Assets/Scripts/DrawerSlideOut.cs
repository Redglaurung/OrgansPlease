using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerSlideOut : MonoBehaviour
{
    public bool slideOut = false;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>=1){
            timer-=1;
        }
        if(slideOut==false){
            if(transform.position.y<=1.8f){
                transform.position = transform.position + new Vector3(0f,0.01f,0.0f);
            }
        }
        if(slideOut==true){
            if(transform.position.y>=-1.8f){
                transform.position = transform.position - new Vector3(0f,0.01f,0.0f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if((collision.tag == "Mouse")&&(slideOut==false)&&(timer==0)){
            timer=600;
            slideOut=true;
            print("Yippee");
            
        } else if((collision.tag == "Mouse")&&(slideOut ==true )&&(timer==0)){
            timer=600;
            slideOut=false;
            print("Wahoooo");
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        
    }
    public void MakeSlidingOut(){
        slideOut=true;
    }
    public void MakeSlidingIn(){
        slideOut=false;
    }
}
