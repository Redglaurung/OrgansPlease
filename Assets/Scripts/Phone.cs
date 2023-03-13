using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MoveableObject
{
    public Canvas canvasCanvas;
    public Image mainScreen;
    public Image email;
    public Image definitions;

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

    public void GoToDefinitions() {
        mainScreen.gameObject.SetActive(false);
        definitions.gameObject.SetActive(true);
    }

    public void GoToMenu() {
        mainScreen.gameObject.SetActive(true);
        definitions.gameObject.SetActive(false);
        //email.gameObject.SetActive(false);
    }

    public void GoToEmail() {
        mainScreen.gameObject.SetActive(false);
        email.gameObject.SetActive(true);
    }

}
