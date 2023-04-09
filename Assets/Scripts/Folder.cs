using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour
{
    public SpriteRenderer myRenderer;
    public GameObject[] pagesArray;
    bool opened;
    bool characterChosen;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        opened = false;
        characterChosen = false;
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
    }
    public void Chosen(){
        characterChosen = true;
        print("yeet");
    }
}
