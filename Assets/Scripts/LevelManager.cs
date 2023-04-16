using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Used in ManageSound
    public AudioSource[] audioSources;
    int audioTimer;

    // Used for page layering
    public GameObject selectedObject;
    public GameObject Greyout;
    public GameObject[] pagesArray;
    int currentMax;

    // Used to handle both Dragging and Tapping objects
    double tapTimer;
    double tapStartTime;
    double TAP_TIME = 0.125; 
    Collider2D targetObject;

    // Used in MouseTap
    Collider2D expandedObject;
    public GameObject stamper;

    // Used in MouseDrag
    public GameObject movingObject;
    Vector3 offset;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        audioTimer = 2000;
        tapStartTime = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // ManageSound();
        if (pagesArray.Length > 0) LayerPages();
        MouseClickTimer();
    }

    /** Sound Management Script */

    /**
    * Currently unused code (commented out in Update), used before new single audio file was created to start music late
    *
    * TODO: Delete upon agreement on new sounds
    */
    void ManageSound() {
        if((audioTimer >= 1)&&(audioTimer<=2000)){audioTimer--;}
        else if(audioTimer < 1){
            audioSources[1].Play();
            audioTimer = 3000;
        }
    }

    /** Layer Management Script */

    /**
    * Shuffles the page layers as a page is clicked on
    */
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
        for(int i=0;i<4;i++){
            float zcalculator = 8 - 2 * i;
            pagesArray[i].transform.position = new Vector3(pagesArray[i].transform.position.x , pagesArray[i].transform.position.y ,zcalculator);
        } 
    }

    /** Mouse Taps and Drags */

    /**
    * Times any mouse clicks to determine if a tap ro drag happened, and calls the appropriate method
    */
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
           if (tapTimer > TAP_TIME) MouseDrag();
        }

        // Left click end
        if (Input.GetMouseButtonUp(0))
        {
            if (tapTimer <= TAP_TIME) MouseTap();
            tapStartTime = -1;
            tapTimer = 0;
            movingObject = null;
            targetObject = null;
        }
    }

    /**
    * Handles a mouse tap
    *
    * A phone or page will be expanded
    * Expanded phones or pages will be put down
    * A stamper will be picked up
    */
    void MouseTap() {
        if(targetObject){
            print(targetObject.transform.gameObject.name);
        }
        // Expands a page or phone to the center
        if (expandedObject == null && targetObject) {
            if((targetObject.transform.gameObject.tag == "Pages") || (targetObject.transform.gameObject.tag == "Phone")){
                targetObject.transform.gameObject.SendMessage("StartLookingAt");
                expandedObject = targetObject;
                Greyout.transform.position = new Vector3(0f,0f,-3f);
            } 
        }
        // Puts down an expanded page or phone
        else if (expandedObject != null) {
            if (targetObject != expandedObject) {
                expandedObject.transform.gameObject.SendMessage("StopLookingAt");
                expandedObject = null;
                Greyout.transform.position = new Vector3(28f,0f,-3f);
            }
        }
        // Picks up/puts down the stamper
        if(targetObject){
            if(targetObject.tag == "Stamp"){
                stamper.SendMessage("ClickedOn");
            }
        }
    }

    /**
    * Picks up and moves an object with the mouse
    */
    void MouseDrag() {
        // Code from: https://gamedevbeginner.com/how-to-move-an-object-with-the-mouse-in-unity-in-2d/
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (movingObject == null && targetObject)
        {
            movingObject = targetObject.transform.gameObject;
            offset = movingObject.transform.position - mousePosition;
        }
        if ((movingObject)&&(movingObject.tag != "Furniture"))
        {
            Vector3 oldPos = movingObject.transform.position;
            movingObject.transform.position = mousePosition + offset;
            keepInBounds(oldPos);
        } 
    }

    /**
    * A helper function for MouseDrag
    * Checks if the object is out of bounds and moves it back appropriately if so
    */
    void keepInBounds(Vector3 oldPos) {
        float xMin = mainCamera.transform.position.x - (mainCamera.orthographicSize * 16/9); // 16/9 used for 16:9 screen scale - if we allow window size changes will need to change
        float xMax = mainCamera.transform.position.x + (mainCamera.orthographicSize * 16/9);
        float yMin = mainCamera.transform.position.y - (mainCamera.orthographicSize);
        float yMax = mainCamera.transform.position.y + (mainCamera.orthographicSize);
        // If out of bounds horizontally
        if (movingObject.transform.position.x < xMin || movingObject.transform.position.x > xMax) 
            movingObject.transform.position = new Vector3(oldPos.x, movingObject.transform.position.y, movingObject.transform.position.z);
        // If out of bounds vertically
        if (movingObject.transform.position.y < yMin || movingObject.transform.position.y > yMax)
            movingObject.transform.position = new Vector3(movingObject.transform.position.x, oldPos.y, movingObject.transform.position.z);
    }
}
