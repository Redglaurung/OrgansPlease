using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some things to note:
// 1. the bounding box intersects method also take into account Z-levels
// 2. Physics2D.OverlapPoint works in a way that if more than one Collider overlaps
// a point, then the one returned will be the one with the LOWEST Z coordinate value
public class ApprovedScript : MonoBehaviour
{
    //page tracking
    public SpriteRenderer myRenderer;
    public GameObject Files;
    public GameObject[] pagesArray;
    
    //Readied Stamp variables
    GameObject readiedStamp;
    public Sprite stampType;
    public Sprite readystampType;
    public Sprite YesreadystampType;
    public float stampScale;
    SpriteRenderer readiedstampRenderer;
    BoxCollider2D readiedstampCollider;
    public float stampX;
    public float stampY;
    
    //State trackers
    bool readied;
    bool currentlyStamping;
    bool rising;
    string searchingforName;
    string currentName;
    int uptimer;
    int downtimer;
    bool canStamp;

    //chosen character data
    Collider2D targetObject;
    GameObject targetPaper;
    CharacterTrackingScript character;
    Collider2D chosenTarget;

    public Animator animator;
    public AudioSource stampPressSound;

    // public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        //Declare and create the readied stamp shadow
        readiedStamp = new GameObject("Readied Stamp Picture");
        readiedStamp.transform.SetParent(gameObject.transform);
        readiedStamp.transform.localPosition = new Vector3(0f, 0f, 10f);
        readiedStamp.transform.localScale = new Vector3(1.4f,1.4f,1f);
        readiedstampRenderer = readiedStamp.AddComponent<SpriteRenderer>();
        readiedStamp.tag = "Furniture";
        readiedstampRenderer.sprite = readystampType;
        readiedstampCollider = readiedStamp.AddComponent<BoxCollider2D>();
        readiedstampCollider.size = new Vector2(10f,5f);
        readiedstampRenderer.sprite = null;
        readiedstampRenderer.sortingLayerName = "Pages";
        readiedstampRenderer.sortingOrder = 10;

        //Set starting state variables
        canStamp=false;
        currentlyStamping=false;
        readied = false;
        uptimer = -1;
        downtimer = -1;
        myRenderer = GetComponent<SpriteRenderer>();
        character = GameObject.Find("GameManager").GetComponent<CharacterTrackingScript>();
        //readiedStamp.transform.localPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //If the stamp is moving upwards
        if((uptimer>=0)&&(readied)){
            uptimer--;
            if(transform.position.y <=4){
                transform.position += new Vector3(0f,0.1f,0f);
                readiedStamp.transform.position -= new Vector3(0f,0.1f,0f);
            } else {
                readiedStamp.transform.position -= new Vector3(0f,0.1f,0f);
            }
        }
        //if the stamp is moving downwards
         if((downtimer>=0)&&(!readied)){
             downtimer--;
             transform.position -= new Vector3(0f,0.1f,0f);
             readiedStamp.transform.position += new Vector3(0f,0.1f,0f);
             if((downtimer == 0) && (currentlyStamping)){
                ApplyStamp();
             }
         }
        if(readied){
            CheckStamping();
        }
    }
//Called my level manager
    public void ClickedOn(){
        //put stamp down
        if((readied)&&(uptimer==-1)){
            if(!canStamp){
                readiedstampRenderer.sprite = null;
                downtimer=20;
                readied=false;
            //stamp the targeted area
            } else if (canStamp){
                downtimer=20;
                readied=false;
                readiedstampRenderer.sprite = null;
                currentlyStamping = true;
            }
            

        }
        if((!readied)&&(downtimer==-1)){
            //readiedStamp.transform.localPosition = transform.localPosition;
            uptimer=20;
            
            readied=true;
            
            readiedstampRenderer.sprite = readystampType;
        }
    }
//check if the Stamp is already in a different state
    public void CheckStamping(){
        Vector2[] stampcorners = GetVertexes(this.gameObject);
        int count=1;
        
        
        for(int i=0;i<4;i++){
            Vector3 Stampposition = new Vector3 (stampcorners[i].x, stampcorners[i].y-2.5f, 0f);
            chosenTarget = Physics2D.OverlapPoint(Stampposition);
            if(chosenTarget){
                currentName = chosenTarget.transform.gameObject.name;
                //print(currentName);
                if(i == 0){
                    searchingforName = currentName;
                } else if(searchingforName != currentName){
                    count=0;
                }
            } else {
                count=0;
            }
        }
        //print(count);
        if((count == 1) && (chosenTarget.transform.gameObject.tag == "Pages")){
            canStamp=true;
            readiedstampRenderer.sprite = YesreadystampType;
            targetPaper = chosenTarget.transform.gameObject;
        } else {
            canStamp=false;
            readiedstampRenderer.sprite = readystampType;
            targetPaper = null;
        }
        

    }

    //returns the vertexes of the specified object
    Vector2[] GetVertexes(GameObject thing){
        Vector2[] verts = new Vector2[4];        // Array that will contain the BOX Collider Vertices
        BoxCollider2D b = thing.GetComponent<BoxCollider2D>();
 
        Bounds box = b.bounds;
        verts[0] = new Vector2( box.max.x, box.max.y); // or do = b.max for upper right
        verts[1] = new Vector2( box.max.x, box.min.y); // for lower right
        verts[2] = new Vector2( box.min.x, box.min.y); // = b.min for lower left
        verts[3] = new Vector2( box.min.x, box.max.y);    //for upper left
        return verts;
    }
//Called when the stamp is over a valid target
public void ApplyStamp() {
    if ((targetPaper.transform.childCount >= 2) || character.isChosen())
        {
            Debug.Log("Can't stamp. Already been stamped or a paper has been chosen already!");
        } else {
            Debug.Log("Stamped Approved!");
            
            //Make the stamp object appear on the page
            GameObject approvedStamp = new GameObject("Approved Stamp Picture");
            approvedStamp.transform.SetParent(targetPaper.transform);
            approvedStamp.transform.SetAsFirstSibling();
            approvedStamp.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            SpriteRenderer stampRenderer = approvedStamp.AddComponent<SpriteRenderer>();
            stampRenderer.sortingLayerName = "Pages";
            targetPaper.SendMessage("LayerUpdate", 6);
            stampRenderer.sprite = stampType;
            approvedStamp.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            approvedStamp.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);

            //Send data to other objects about the target chosen
            Pages paperScript = targetPaper.GetComponent<Pages>();
            paperScript.setStamped();
            Files.SendMessage("Chosen");

            animator.SetBool("Stamped", true);
            stampPressSound.Play();
            
            for(int i=0;i<4;i++){
                if(pagesArray[i].name != targetPaper.name){
                    pagesArray[i].SendMessage("IsRejected");
                }
            }
        }

}

}
