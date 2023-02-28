using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    GameObject selectedObject;
    public GameObject[] pagesArray;
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
                    pagesArray[3].SendMessage("LayerUpdate",3);
                    for(int i=currentMax+1; i<3;i++){
                        pagesArray[i-1]=pagesArray[i];
                        pagesArray[i-1].SendMessage("LayerUpdate",i-1);
                    }
                    pagesArray[2]=pagesArray[4];
                    pagesArray[4]=null;
                    pagesArray[2].SendMessage("LayerUpdate",2);
                }
            }   
        }
    }
}
