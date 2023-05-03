using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Phone : MonoBehaviour
{
    // Used for email notification
    public Sprite emailNotification;
    public Sprite emailNormal;
    AudioSource notifSound;
    int timer;

    // Used for Start/Stop looking at
    public Canvas canvasCanvas;
    SpriteRenderer myRenderer;
    Vector3 defaultScale;
    Vector3 expandedScale;
    Vector3 actualLocation;

    // Used for phone screen transitions
    public Image mainScreen;
    public Image email;
    public Image topPanel;
    public Image definitions;
    public Image emailButton;
    public ScrollRect scrollRect;
    public GameObject levelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 1000;
        notifSound = GetComponent<AudioSource>();
        myRenderer = GetComponent<SpriteRenderer>();
        defaultScale = transform.localScale;
        expandedScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1) {
            timer--;
        }
        else if(timer == 0) {
            emailButton.sprite = emailNotification;
            timer=-1;
            notifSound.Play();
            if(SceneManager.GetActiveScene().name == "Day1"){
                levelManager.SendMessage("Tutorial",1);
            }
        }
    }

    /** ------------------------------ Expansion ------------------------------ */

    /**
    * Expands the phone and moves it to the center at a larger scale for readability
    */
    public void StartLookingAt(){
        myRenderer.sortingLayerName = "Looking At";
        canvasCanvas.sortingLayerName = "Looking At";
        
        // Move to center
        transform.localScale = expandedScale;
        actualLocation = transform.position;
        transform.position = Vector3.zero;
        transform.position = new Vector3(transform.position.x, transform.position.y, -4f);
    }

    /**
    * Contracts the phone and moves it back to where it was before
    */
    public void StopLookingAt(){
        myRenderer.sortingLayerName = "Pages";
        canvasCanvas.sortingLayerName = "Pages";
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        // Move back from center
        transform.localScale = defaultScale;
        transform.position = actualLocation;
    }

    /** ------------------------------ Phone Button Presses ------------------------------ */

    /**
    * Called when a back button is pressed
    */
    public void GoToMenu() {
        mainScreen.gameObject.SetActive(true);
        definitions.gameObject.SetActive(false);
        email.gameObject.SetActive(false);
        topPanel.gameObject.SetActive(false);

        levelManager.SendMessage("MouseTap");
    }

    /**
    * Called when the definitions button is pressed
    */
    public void GoToDefinitions() {
        definitions.gameObject.SetActive(true);
        topPanel.gameObject.SetActive(true);
        mainScreen.gameObject.SetActive(false);
        
        scrollRect.content = definitions.rectTransform;
        levelManager.SendMessage("MouseTap");
    }

    /**
    * Called when the email button is pressed
    */
    public void GoToEmail() {
        email.gameObject.SetActive(true);
        topPanel.gameObject.SetActive(true);
        mainScreen.gameObject.SetActive(false);

        emailButton.sprite = emailNormal;
        scrollRect.content = email.rectTransform;
        levelManager.SendMessage("MouseTap");
    }

    /**
    * Only available in the "EndingStart" scene, called when the PDF button is pressed
    */
    public void GoToFinalScene() {
        SceneManager.LoadScene("EndingFeedback");
    }
}
