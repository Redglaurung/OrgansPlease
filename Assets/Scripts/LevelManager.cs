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

    // Start is called before the first frame update
    void Start()
    {
        audioTimer = 2000;
        tapStartTime = -1;
    }

    // Update is called once per frame
    void Update()
    {
        ManageSound();
        if (hasPages) LayerPages();
        HandleTaps();
    }


/** Sound Management Script */

    void ManageSound() {
        if((audioTimer >= 1)&&(audioTimer<=2000)){audioTimer--;}
        else if(audioTimer < 1){
            print("go");
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
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject) {
                if(targetObject.transform.gameObject.tag == "Pages"){
                    selectedObject = targetObject.transform.gameObject;
                    print(selectedObject.name);
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
        // Right Click
    //     else if(Input.GetMouseButtonDown(1)){
    //     Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
    //     if (targetObject) {
    //         if((targetObject.transform.gameObject.tag == "Pages") || (targetObject.transform.gameObject.tag == "Phone")){
    //             selectedObject = targetObject.transform.gameObject;
    //             print(selectedObject.name);
    //             if(selectedObject != lastlookedat){
    //                 selectedObject.SendMessage("StartLookingAt");
    //                 lastlookedat.SendMessage("StopLookingAt");
    //                 lastlookedat=selectedObject;
    //             } else {
    //                 selectedObject.SendMessage("StopLookingAt");
    //                 lastlookedat=gameObject;
    //             }
    //         }
    //     }
    // }
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

    void HandleTaps() {
        // Left click start
        if (Input.GetMouseButtonDown(0)) {
            tapStartTime = Time.time;
        }
        if (tapStartTime != -1) {
           tapTimer = Time.time - tapStartTime; 
        }

        // Left click end
        if (Input.GetMouseButtonUp(0))
        {
            if (tapTimer < 0.1) TapObject();
            tapStartTime = -1;
            movingObject = null;
        }
        if (tapStartTime != -1 && tapTimer > 0.1) DragObject();

    }


    void TapObject() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

        // Get Bigger
        if (targetObject) {
            if((targetObject.transform.gameObject.tag == "Pages") || (targetObject.transform.gameObject.tag == "Phone")){
                selectedObject = targetObject.transform.gameObject;
                if(selectedObject != lastlookedat){
                    selectedObject.SendMessage("StartLookingAt");
                    lastlookedat.SendMessage("StopLookingAt");
                    lastlookedat=selectedObject;
                }
            }
        Debug.Log("TapObject");
        }
    }

    /** Movement Script */

    /**
    * Picks up and moves the object with the mouse
    */
    void DragObject() {
        // Code from: https://gamedevbeginner.com/how-to-move-an-object-with-the-mouse-in-unity-in-2d/
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
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
