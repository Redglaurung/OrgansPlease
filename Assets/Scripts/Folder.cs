using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Folder : MonoBehaviour
{
    //Refrence to other necessary gameobjects
    public SpriteRenderer myRenderer;
    public GameObject[] pagesArray;
    public GameObject GreyOut;
    public string nextScene;

    //Bools that track state
    bool opened;
    bool characterChosen;
    bool dayEnding;
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        opened = false;
        characterChosen = false;
        dayEnding = false;
        timer = 500;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         if (Input.GetMouseButtonDown(0)) {
            Collider2D targetObj = Physics2D.OverlapPoint(mousePosition);
            //print("1");
            if (targetObj) {
                if((targetObj.transform.gameObject.name == "FileTop") && (!opened)){
                    //print("2");
                    myRenderer.sortingLayerName = "Default";
                    transform.localScale = new Vector3(1f,-1f,1f);
                    transform.position = new Vector3(11.96f,3.29f,0f);
                    opened=true;
                    for(int i=0; i<4; i++){
                        pagesArray[i].SendMessage("StartMovement");
                    }
                }
            }
         }

         //Watch where papers are inside the folder and end the day when all rejected papers are in
        if(characterChosen){
            for(int i=0; i<4; i++){
                        float distance = Vector2.Distance(pagesArray[i].transform.position, transform.position);
                        //print(distance);
                        if((distance <= 6.5f) && (pagesArray[i].tag != "Furniture")){
                                pagesArray[i].SendMessage("StopMovement");
                                int count=0;
                                for(int j=0; j<4; j++){
                                    if(pagesArray[j].tag =="Furniture"){
                                        count++;
                                    }
                                }
                                if(count >= 3){
                                    EndDay();
                                } else {
                                    count = 0;
                                }
                        }
            }
        }
        //Move to the next day
        if(dayEnding){
            if(timer <= 0){
                SceneManager.LoadScene(nextScene);
            } else {
                timer--;
            }
        }
    }
    public void Chosen(){
        characterChosen = true;
    }

    //Managing end of day tasks
    public void EndDay(){
        dayEnding = true;
        GreyOut.SendMessage("FadeOut");
        transform.localScale = new Vector3(1f,1f,1f);
        transform.position = new Vector3(7.09f,0.34f,0f);
        myRenderer.sortingLayerName = "Stamper";
        print("done");
    }
}
