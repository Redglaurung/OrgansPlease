using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MoveableObject
{
    public Canvas canvasCanvas;
    SpriteRenderer myRenderer;
    Vector3 defaultScale;
    Vector3 doubleScale;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        defaultScale = transform.localScale;
        doubleScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
        
    }

    public void StartLookingAt(){
        // myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sortingLayerName = "Looking At";
        transform.localScale = doubleScale;
        canvasCanvas.sortingLayerName = "Looking At";
    }
    public void StopLookingAt(){
        // myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sortingLayerName = "Pages";
        transform.localScale = defaultScale;
        canvasCanvas.sortingLayerName = "Pages";
    }

}
