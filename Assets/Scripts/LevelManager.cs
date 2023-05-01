using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Used for page layering
    public GameObject selectedObject;
    public GameObject[] pagesArray;
    int currentMax;

    // Used to handle both Dragging and Tapping objects
    Collider2D clickedObject;
    Vector3 prevPosition;
    float mouseMvmtThreshold = 0.5f;
    string mouseDownState;
    public GameObject greyOut;

    // Used in MouseTap
    Collider2D expandedObject;
    public GameObject stamper;
    public GameObject emailButton;
    public GameObject dictButton;
    public GameObject backButton;

    // Used in MouseDrag
    public GameObject movingObject;
    Vector3 offset;
    public Camera mainCamera;

    //Tutorial Booleans
    public bool isDayOne;
    public bool firstClickedOffPhone;
    public bool allPapersDraggedOut;
    public bool clickedOnStamp;
    int tutorialActive;
    public List<GameObject> touchedPapers;

    // Start is called before the first frame update
    void Start()
    {
        firstClickedOffPhone = false;
        allPapersDraggedOut = false;
        clickedOnStamp = false;
        tutorialActive = -1;

        touchedPapers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pagesArray.Length > 0) {
            LayerPages();
        }
        MouseClickHandler();
        if (isDayOne) EndTutorial();
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
            SpriteRenderer pageRenderer = pagesArray[i].GetComponent<SpriteRenderer>();
            if(pageRenderer.sortingLayerName != "Looking At"){
                float zcalculator = 8 - 2 * i;
                pagesArray[i].transform.position = new Vector3(pagesArray[i].transform.position.x , pagesArray[i].transform.position.y ,zcalculator);
            }
        } 
    }

    /** ------------------------------ Mouse Taps and Drags ------------------------------ */

    /**
    * Times any mouse clicks to determine if a tap or drag happened, and calls the appropriate method
    */
    void MouseClickHandler() {
        // Left click start
        if (Input.GetMouseButtonDown(0)) {
            prevPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickedObject = Physics2D.OverlapPoint(prevPosition);
            mouseDownState = "Started";
        }

        // Left mouse button still down
        if (mouseDownState != "Ended") {
            if (mouseDownState != "Drag") {
                TestMouseMvmt();
            }
            else {
                MouseDrag();
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            LeftClickRelease();
        }
    }

    /**
    * Handles what happens on the release of a left click
    * Includes: Tap actions and third tutorial
    */
    void LeftClickRelease() {
        if (mouseDownState == "Tap") {
            MouseTap();
        }
        else {
            if (isDayOne && !touchedPapers.Contains(movingObject)) {
                touchedPapers.Add(movingObject);
            }
        }

        // Third tutorial
        if(tutorialActive == -1 && firstClickedOffPhone && !allPapersDraggedOut && touchedPapers.Count >= 3) {
            allPapersDraggedOut = true;
            Tutorial(3);
        }

        movingObject = null;
        clickedObject = null;
        mouseDownState = "Ended";
    }

    /**
    * Checks how far the mouse has moved since it was first clicked, and either sets the mouse click to a tap or drag accordingly
    */
    void TestMouseMvmt() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mvmt = prevPosition - mousePosition;

        if (mvmt.magnitude > mouseMvmtThreshold) {
            mouseDownState = "Drag";
            MouseDrag();
        }
        else {
            mouseDownState = "Tap";
        }
    }

    /**
    * Handles a mouse tap
    *
    * A phone or page will be expanded
    * Expanded phones or pages will be put down
    * A stamper will be picked up
    *
    * On day one a tutorial may be activated
    */
    void MouseTap() {
        if(clickedObject){
            if(isDayOne) {
                TutorialClickActions();
            }
        }
        if (expandedObject == null && clickedObject) {
            ExpandObject();
        }
        else if (expandedObject != null) {
            PutDownExpandedObject();
        }
        // Picks up/puts down the stamper
        if(clickedObject){
            if(clickedObject.tag == "Stamp"){
                stamper.SendMessage("ClickedOn");
            }
        }
    }

    /**
    * Handles all tutorial events caused by a click 
    * Includes: Second tutorial, fourth tutorial, ending a tutorial
    */
    void TutorialClickActions() {
        // Second tutorial
        if((!firstClickedOffPhone)&&expandedObject != null && expandedObject.transform.gameObject.name=="Phone"&&clickedObject.transform.gameObject.name=="GreyOut"){
            firstClickedOffPhone = true;
            Tutorial(2);
        }
        // --- Note: Third tutorial can be found under left click end in MouseClickHandler() ----
        // Fourth tutorial
            else if (allPapersDraggedOut && !clickedOnStamp && clickedObject.transform.gameObject.name == "Stamp") {
            clickedOnStamp = true;
            Tutorial(4);
        }
    }

    void ExpandObject() {
        if((clickedObject.transform.gameObject.tag == "Pages") || (clickedObject.transform.gameObject.tag == "Phone")){
            clickedObject.transform.gameObject.SendMessage("StartLookingAt");
            expandedObject = clickedObject;
            greyOut.transform.position = new Vector3(0f,0f,-3f);
            if(clickedObject.transform.gameObject.tag != "Phone"){
                ChangePhoneButtonActivation(false);
            }
        } 
    }

    void PutDownExpandedObject() {
        if (clickedObject != expandedObject) {
            expandedObject.transform.gameObject.SendMessage("StopLookingAt");
            expandedObject = null;
            if (tutorialActive == -1) {
                greyOut.transform.position = new Vector3(28f,0f,-3f);
            }
            ChangePhoneButtonActivation(true);
        }
    }

    void ChangePhoneButtonActivation(bool active) {
        if(emailButton.activeSelf){
            emailButton.GetComponent<Button>().interactable = active;
        }
        if(dictButton.activeSelf){
            dictButton.GetComponent<Button>().interactable = active;
        }
        if(backButton.activeSelf){
            backButton.GetComponent<Button>().interactable = active;
        }
    }

    /**
    * Picks up and moves an object with the mouse
    */
    void MouseDrag() {
        // Code from: https://gamedevbeginner.com/how-to-move-an-object-with-the-mouse-in-unity-in-2d/
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (movingObject == null && clickedObject)
        {
            movingObject = clickedObject.transform.gameObject;
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

    void EndTutorial() {
        if (Input.GetKeyDown("space") && tutorialActive != -1) {
            greyOut.SendMessage("TutorialClose",tutorialActive);
            tutorialActive = -1;
        }
    }

    //Triggers the necessary tutorial and lets Greyout know
    void Tutorial(int tutorialNum){
        greyOut.SendMessage("TutorialStart",tutorialNum);
        tutorialActive = tutorialNum;
    }
}
