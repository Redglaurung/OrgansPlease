using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Folder : MonoBehaviour
{
    public SpriteRenderer myRenderer;
    public GameObject[] pagesArray;
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
        timer = 100;
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
        if(characterChosen){
            for(int i=0; i<4; i++){
                        float distance = Vector3.Distance(pagesArray[i].transform.position, transform.position);
                        //print(distance);
                        if((distance <= 8.5f) && (pagesArray[i].tag != "Furniture")){
                                pagesArray[i].SendMessage("StopMovement");
                                int count=0;
                                for(int j=0; j<4; j++){
                                    if(pagesArray[j].tag =="Furniture"){
                                        count++;
                                    }
                                }
                                if(count >= 4){
                                    EndDay();
                                } else {
                                    count = 0;
                                }
                        }
            }
        }
        if(dayEnding){
            if(timer <= 0){
                SceneManager.LoadScene("EndingStart");
            } else {
                timer--;
            }
        }
    }
    public void Chosen(){
        characterChosen = true;
        //print("yeet");
    }
    public void EndDay(){
        dayEnding = true;
        transform.localScale = new Vector3(1f,-1f,1f);
        transform.position = new Vector3(7.09f,0.34f,0f);
        myRenderer.sortingLayerName = "Stamper";
        print("done");
    }
}
