using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public AudioSource[] audioSources;
    int audioTimer;

    public GameObject selectedObject;
    public GameObject[] pagesArray;
    public GameObject lastlookedat;
    int currentMax;

    // Used to keep track of itself in MoveObject()
    public GameObject movingObject;
    // Used to keep track of how much to move itself
    Vector3 offset;

    public bool hasPages;

    bool tap;
    double tapTimer;
    double tapStartTime;
    double TAP_TIME = 0.125;
    Collider2D targetObject;

    // Start is called before the first frame update
    void Start()
    {
        audioTimer = 2000;
        tapStartTime = -1;
        lastlookedat=gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ManageSound();
        if (hasPages) LayerPages();
        MouseClickTimer();
    }


/** Sound Management Script */

    void ManageSound() {
        if((audioTimer >= 1)&&(audioTimer<=2000)){audioTimer--;}
        else if(audioTimer < 1){
            audioSources[1].Play();
            audioTimer = 3000;
        }
    }


/** Page Management Script */

    // Update is called once per frame
    void LayerPages()
    {
     Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    // Layering of pages
    if (Input.GetMouseButtonDown(0)) {
            Collider2D targetObj = Physics2D.OverlapPoint(mousePosition);
            if (targetObj) {
                if(targetObj.transform.gameObject.tag == "Pages"){
                    selectedObject = targetObj.transform.gameObject;
                    if(selectedObject.name != pagesArray[3].name){
                        pagesArray[4] = pagesArray[3];
                        pagesArray[3] = null;
                        for(int i=0; i<3;i++){
                            if(selectedObject.name == pagesArray[i].name){
                                currentMax = i;
                                break;
                            }
                        }
                        pagesArray[3] = pagesArray[currentMax];
                        pagesArray[3].SendMessage("LayerUpdate", 6);
                        for(int i=currentMax+1; i<3;i++){
                            pagesArray[i-1]=pagesArray[i];
                        }
                        
                        pagesArray[2]=pagesArray[4];
                        pagesArray[4]=null;
                        pagesArray[2].SendMessage("LayerUpdate",4);
                        for(int i=0; i<3;i++){
                            pagesArray[i].SendMessage("LayerUpdate", 2*i);
                        }
                    }
                    else
                    {
                        pagesArray[3].SendMessage("LayerUpdate", 6);
                    }
                }
            }   
        } 
    }

    public void StopLookingAt(){

    }
    public void AllPapersDown(){
        if (hasPages) {
            for(int i=0; i<5; i++){
                pagesArray[i].SendMessage("StopLookingAt");
            }
        }
    } 

    void MouseClickTimer() {
        // Left click start
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tapStartTime = Time.time;
            targetObject = Physics2D.OverlapPoint(mousePosition);
        }

        // Increment time
        if (tapStartTime != -1) {
           tapTimer = Time.time - tapStartTime; 
           if (tapTimer > TAP_TIME) DragObject();
        }

        // Left click end
        if (Input.GetMouseButtonUp(0))
        {
            if (tapTimer <= TAP_TIME) TapObject();
            tapStartTime = -1;
            tapTimer = 0;
            movingObject = null;
            targetObject = null;
        }
    }


    void TapObject() {
        Debug.Log("TapObject");

        bool justExpanded = false;
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // targetObject = Physics2D.OverlapPoint(mousePosition);
        selectedObject = null;

        if (targetObject) Debug.Log("targetObj: " + targetObject.transform.gameObject.name);

        // Get Bigger
        if (targetObject) {
            if((targetObject.transform.gameObject.tag == "Pages") || (targetObject.transform.gameObject.tag == "Phone")){
                lselectedObject = targetObject.transform.gameObject;
                if(selectedObject != lastlookedat){
                    selectedObject.SendMessage("StartLookingAt");
                    lastlookedat.SendMessage("StopLookingAt");
                    lastlookedat=selectedObject;
                    justExpanded = true;
                }
            }
        }
        if (!justExpanded) {
            if (selectedObject != lastlookedat) {
                lastlookedat.SendMessage("StopLookingAt");
                // lastlookedat = null;
            }
        }
    }

    /** Movement Script */

    /**
    * Picks up and moves the object with the mouse
    */
    void DragObject() {
        Debug.Log("DragObject");
        // Code from: https://gamedevbeginner.com/how-to-move-an-object-with-the-mouse-in-unity-in-2d/
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // targetObject = Physics2D.OverlapPoint(mousePosition);
        if (movingObject == null && targetObject)
        {
            movingObject = targetObject.transform.gameObject;
            offset = movingObject.transform.position - mousePosition;
        }
        if ((movingObject)&&(movingObject.tag != "Furniture"))
        {
            movingObject.transform.position = mousePosition + offset;
        }
    }


}
