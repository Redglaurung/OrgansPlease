using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MoveableObject
{
    public int layer;
    SpriteRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        print(myRenderer.sortingOrder);
    }

    // Update is called once per frame
    void Update()
    {
       MoveObject();
         
    }
    public void LayerUpdate(int layer){
        myRenderer = GetComponent<SpriteRenderer>();
        //print(myRenderer.sortingOrder);
        //print(layer);
        myRenderer.sortingOrder = layer;
    }
    public void StartLookingAt(){
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sortingLayerName = "Looking At";
        transform.localScale = new Vector3(5.6f,8.4f,1.0f);
    }
    public void StopLookingAt(){
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sortingLayerName = "Pages";
        transform.localScale = new Vector3(2.8f,4.2f,1.0f);
    }
}
