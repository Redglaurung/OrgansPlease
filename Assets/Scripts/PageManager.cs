using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject[] pagesArray;
    public GameObject lastlookedat;
    int currentMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
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
                        pagesArray[3]= pagesArray[currentMax];
                        pagesArray[3].SendMessage("LayerUpdate",6);
                        for(int i=currentMax+1; i<3;i++){
                            pagesArray[i-1]=pagesArray[i];
                            pagesArray[i-1].SendMessage("LayerUpdate",i-2);
                        }
                        pagesArray[2]=pagesArray[4];
                        pagesArray[4]=null;
                        pagesArray[2].SendMessage("LayerUpdate",4);
                    }
                }
            }   
        } else if(Input.GetMouseButtonDown(1)){
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        if (targetObject)
            {
            if((targetObject.transform.gameObject.tag == "Pages") || (targetObject.transform.gameObject.tag == "Phone")){
                selectedObject = targetObject.transform.gameObject;
                print(selectedObject.name);
                if(selectedObject != lastlookedat){
                    selectedObject.SendMessage("StartLookingAt");
                    lastlookedat.SendMessage("StopLookingAt");
                    lastlookedat=selectedObject;
                } else {
                    selectedObject.SendMessage("StopLookingAt");
                    lastlookedat=gameObject;
                }
            }

            }
    }
    }
    public void StopLookingAt(){

    } 
}
