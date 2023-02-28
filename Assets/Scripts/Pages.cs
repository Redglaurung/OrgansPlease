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
        print(myRenderer.sortingOrder);
        print(layer);
        myRenderer.sortingOrder = layer;
    }
}
