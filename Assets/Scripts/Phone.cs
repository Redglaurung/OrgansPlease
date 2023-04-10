using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Phone : MonoBehaviour
{
    public Canvas canvasCanvas;
    public Image mainScreen;
    public Image email;
    public Image definitions;
    public Image emailButton;
    public Sprite emailNotification;
    public Sprite emailNormal;
    // public GameObject pageManager;
    AudioSource notifSound;

    SpriteRenderer myRenderer;
    Vector3 defaultScale;
    Vector3 doubleScale;
    int timer;

    // Used for Start/Stop looking at
    Vector3 actualLocation;
    
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

        // Move to center
        actualLocation = transform.position;
        transform.position = Vector3.zero;
    }
    public void StopLookingAt(){
        myRenderer.sortingLayerName = "Pages";
        transform.localScale = defaultScale;
        canvasCanvas.sortingLayerName = "Pages";

        // Move back from center
        transform.position = actualLocation;
    }

    public void GoToDefinitions() {
        mainScreen.gameObject.SetActive(false);
        definitions.gameObject.SetActive(true);
    }

    public void GoToMenu() {
        mainScreen.gameObject.SetActive(true);
        definitions.gameObject.SetActive(false);
        email.gameObject.SetActive(false);
    }

    public void GoToEmail() {
        mainScreen.gameObject.SetActive(false);
        email.gameObject.SetActive(true);
        emailButton.sprite = emailNormal;
    }

    public void GoToFinalScene() {
        SceneManager.LoadScene("EndingFeedback");
    }
}
