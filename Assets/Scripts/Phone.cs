using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public Canvas canvasCanvas;
    public Image mainScreen;
    public Image email;
    public Image definitions;
    public Image emailButton;
    public Sprite emailNotification;
    public Sprite emailNormal;
    public GameObject pageManager;
    AudioSource notifSound;

    SpriteRenderer myRenderer;
    Vector3 defaultScale;
    Vector3 doubleScale;
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        defaultScale = transform.localScale;
        doubleScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
        timer = 1000;
        notifSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>=1){timer--;}
        else if(timer == 0){
            emailButton.sprite = emailNotification;
            timer=-1;
            notifSound.Play();
        }
        
    }

    public void StartLookingAt(){
        myRenderer.sortingLayerName = "Looking At";
        transform.localScale = doubleScale;
        canvasCanvas.sortingLayerName = "Looking At";
    }
    public void StopLookingAt(){
        myRenderer.sortingLayerName = "Pages";
        transform.localScale = defaultScale;
        canvasCanvas.sortingLayerName = "Pages";
    }

    public void GoToDefinitions() {
        mainScreen.gameObject.SetActive(false);
        definitions.gameObject.SetActive(true);
        StartLookingAt();
        pageManager.SendMessage("AllPapersDown");
    }

    public void GoToMenu() {
        mainScreen.gameObject.SetActive(true);
        definitions.gameObject.SetActive(false);
        email.gameObject.SetActive(false);
        StartLookingAt();
        pageManager.SendMessage("AllPapersDown");
    }

    public void GoToEmail() {
        mainScreen.gameObject.SetActive(false);
        email.gameObject.SetActive(true);
        emailButton.sprite = emailNormal;
    }

}
