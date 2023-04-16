using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour
{
    public Canvas canvasCanvas;
    public SpriteRenderer myRenderer;

    // Used for Start/Stop looking at
    Quaternion defaultRotation;
    Vector3 defaultScale;
    Vector3 scaledUp;
    Vector3 actualLocation;

    public bool isStamped;

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

    /**
    * Expands the page and moves it to the center at a larger scale for readability
    */
    public void StartLookingAt(){
        myRenderer.sortingLayerName = "Looking At";
        canvasCanvas.sortingLayerName = "Looking At";
        transform.position = new Vector3 (transform.position.x, transform.position.y, -1f);
        if (gameObject.transform.childCount == 2)
        {
            Transform stamp = gameObject.transform.GetChild(0);
            SpriteRenderer stampRenderer = stamp.GetComponent<SpriteRenderer>();
            stampRenderer.sortingLayerName = "Looking At";
        }

        // Move to center
        transform.localRotation = new Quaternion(0,0,0,0);
        transform.localScale = scaledUp;
        actualLocation = transform.position;
        transform.position = Vector3.zero;
    }

    /**
    * Contracts the page and moves it back to where it was before
    */
    public void StopLookingAt(){
        transform.position = new Vector3 (transform.position.x, transform.position.y, 2f);
        myRenderer.sortingLayerName = "Pages";
        canvasCanvas.sortingLayerName = "Pages";
        if (gameObject.transform.childCount == 2)
        {
            Transform stamp = gameObject.transform.GetChild(0);
            SpriteRenderer stampRenderer = stamp.GetComponent<SpriteRenderer>();
            stampRenderer.sortingLayerName = "Pages";
        }

        // Move back from center
        transform.localScale = defaultScale;
        transform.localRotation = defaultRotation;
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
