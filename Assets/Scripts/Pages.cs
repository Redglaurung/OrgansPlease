using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MoveableObject
{
    //public GameObject canvas;
    public Canvas canvasCanvas;
    public int layer;
    public SpriteRenderer myRenderer;
    Vector3 defaultScale;
    Vector3 doubleScale;
    public bool isStamped;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        defaultScale = transform.localScale;
        doubleScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
        isStamped = false;
        // print(myRenderer.sortingOrder);
    }

    // Update is called once per frame
    void Update()
    {
       MoveObject();
         
    }
    public void LayerUpdate(int layer){
        // myRenderer = GetComponent<SpriteRenderer>();
        //print(myRenderer.sortingOrder);
        //print(layer);
        myRenderer.sortingOrder = layer;
        canvasCanvas.sortingOrder = layer + 1; 
        if (gameObject.transform.childCount == 2)
        {
            Transform stamp = gameObject.transform.GetChild(0);
            SpriteRenderer stampRenderer = stamp.GetComponent<SpriteRenderer>();
            stampRenderer.sortingOrder = layer + 1;
        }
    }
    public void StartLookingAt(){
        // myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sortingLayerName = "Looking At";
        transform.localScale = doubleScale;
        canvasCanvas.sortingLayerName = "Looking At";
        if (gameObject.transform.childCount == 2)
        {
            Transform stamp = gameObject.transform.GetChild(0);
            SpriteRenderer stampRenderer = stamp.GetComponent<SpriteRenderer>();
            stampRenderer.sortingLayerName = "Looking At";
        }
    }
    public void StopLookingAt(){
        // myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sortingLayerName = "Pages";
        transform.localScale = defaultScale;
        canvasCanvas.sortingLayerName = "Pages";
        if (gameObject.transform.childCount == 2)
        {
            Transform stamp = gameObject.transform.GetChild(0);
            SpriteRenderer stampRenderer = stamp.GetComponent<SpriteRenderer>();
            stampRenderer.sortingLayerName = "Pages";
        }
    }

    public void setStamped()
    {
        // There are no takebacks after stamping. It's one and done.
        isStamped = true;
    }
}
