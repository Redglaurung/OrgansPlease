using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour
{
    public Canvas canvasCanvas;
    public int layer;
    public SpriteRenderer myRenderer;
    Vector3 defaultScale;
    Vector3 scaledUp;
    public bool isStamped;

    // Used for Start/Stop looking at
    Quaternion defaultRotation;
    Vector3 actualLocation;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        defaultScale = transform.localScale;
        defaultRotation = transform.localRotation;
        scaledUp = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z);
        isStamped = false;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void LayerUpdate(int layer){
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
        myRenderer.sortingLayerName = "Looking At";
        transform.localRotation = new Quaternion(0,0,0,0);
        transform.localScale = scaledUp;
        canvasCanvas.sortingLayerName = "Looking At";
        if (gameObject.transform.childCount == 2)
        {
            Transform stamp = gameObject.transform.GetChild(0);
            SpriteRenderer stampRenderer = stamp.GetComponent<SpriteRenderer>();
            stampRenderer.sortingLayerName = "Looking At";
        }

        // Move to center
        actualLocation = transform.position;
        transform.position = Vector3.zero;
    }
    public void StopLookingAt(){
        myRenderer.sortingLayerName = "Pages";
        transform.localScale = defaultScale;
        transform.localRotation = defaultRotation;
        canvasCanvas.sortingLayerName = "Pages";
        if (gameObject.transform.childCount == 2)
        {
            Transform stamp = gameObject.transform.GetChild(0);
            SpriteRenderer stampRenderer = stamp.GetComponent<SpriteRenderer>();
            stampRenderer.sortingLayerName = "Pages";
        }

        // Move back from center
        transform.position = actualLocation;
    }

    public void setStamped()
    {
        // There are no takebacks after stamping. It's one and done.
        isStamped = true;
    }

    public void StartMovement(){
        gameObject.tag = "Pages";
    }
    public void StopMovement(){
        gameObject.tag = "Furniture";
    }
}
