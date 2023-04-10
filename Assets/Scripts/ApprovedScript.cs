using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some things to note:
// 1. the bounding box intersects method also take into account Z-levels
// 2. Physics2D.OverlapPoint works in a way that if more than one Collider overlaps
// a point, then the one returned will be the one with the LOWEST Z coordinate value
public class ApprovedScript : MonoBehaviour
{
    public SpriteRenderer myRenderer;
    public GameObject Files;
    GameObject readiedStamp;
    public Sprite stampType;
    public Sprite readystampType;
    public float stampScale;
    public float stampX;
    public float stampY;
    bool readied;
    bool rising;
    int timer;
    CharacterTrackingScript character;
    // public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        
        readied = false;
        myRenderer = GetComponent<SpriteRenderer>();
        character = GameObject.Find("GameManager").GetComponent<CharacterTrackingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if((timer>=0)&&(readied)){
            timer--;
            transform.position += new Vector3(0f,0.1f,0f);
            readiedStamp.transform.position -= new Vector3(0f,0.1f,0f);
        }
    }

    public void ClickedOn(){
        if(readied){

        }
        if(!readied){
            readiedStamp = new GameObject("Approved Stamp Picture");
            readiedStamp.transform.SetParent(gameObject.transform);
            timer=20;
            readiedStamp.transform.localPosition = new Vector3(0f, 0f, 0f);
            readied=true;
            SpriteRenderer stampRenderer = readiedStamp.AddComponent<SpriteRenderer>();
            stampRenderer.sortingLayerName = "Stamper";
            stampRenderer.sortingOrder = 3;
            stampRenderer.sprite = readystampType;
        }
    }
}
//     [ContextMenu("Pressed on me")]
//     public void OnMouseDown()
//     {
//         BoxCollider2D stampCollider = gameObject.GetComponent<BoxCollider2D>();
//         Bounds stampBounds = stampCollider.bounds;
//         // Debug.Log(bound.extents);
//         // Debug.Log(gameObject.transform.position);
        
//         // If the paper is within the ranges defined above, I will set the stamp picture to be a child of the paper.

//         GameObject[] papers = GameObject.FindGameObjectsWithTag("Pages");
//         Debug.Log("This is stampBounds.max " + stampBounds.max);        // stampBounds.max is the top right corner of the Stamp
//         Debug.Log("This is stampBounds.min " + stampBounds.min);        // stampBounds.min is the bottom left corner of the Stamp
//         // int highestPage = 6;
//         foreach (GameObject paper in papers)
//         {
//             // Check if page is the top page in the Pages Sorting Layer
//             // Make sure that we can't stamp when the page is in Looking At Mode
//             //if((paper.myRenderer.sortingOrder == 6) && (paper.myRenderer.sortingLayerName != "Looking At"))
            
//             // Check if the paper is within the 
//             BoxCollider2D paperCollider = paper.GetComponent<BoxCollider2D>();
//             Bounds paperBounds = paperCollider.bounds;

//             // var means figure out the data type for me
//             var intersection = 
//                 Vector3.Min(stampBounds.max, paperBounds.max)
//                 - Vector3.Max(stampBounds.min, paperBounds.min);


//             if (intersection.x > 0 && intersection.y > 0)       // Both intersection.x and intersection.y should be positive because negative width and height shouldn't result in an area
//             {
//                 Debug.Log("Paper is intersecting with the stamper!");
//                 SpriteRenderer paperRenderer = paper.GetComponent<SpriteRenderer>();
//                 if (paperRenderer.sortingOrder == 6 && paperRenderer.sortingLayerName != "Looking At")
//                 {
//                     float area = intersection.x * intersection.y;
//                     if (area > 3)
//                     {
//                         Debug.Log("This is the paper: " + paper + "and this is my area: " + area);
//                         ApplyStamp(paper);
//                     }
//                 }
//             }
//         }
//     }

//     private GameObject checkTopPaper()
//     {
//         return null;
//     }

//     private void ApplyStamp(GameObject paper)
//     {
//         if ((paper.transform.childCount >= 2) || character.isChosen())
//         {
//             Debug.Log("Can't stamp. Already been stamped or a paper has been chosen already!");
//         } else {
//             Debug.Log("Stamped Approved!");
//             GameObject approvedStamp = new GameObject("Approved Stamp Picture");
//             approvedStamp.transform.SetParent(paper.transform);
//             approvedStamp.transform.SetAsFirstSibling();
//             approvedStamp.transform.localPosition = new Vector3(0f, 0f, 0f);
//             SpriteRenderer stampRenderer = approvedStamp.AddComponent<SpriteRenderer>();
//             stampRenderer.sortingLayerName = "Pages";
//             paper.SendMessage("LayerUpdate", 6);
//             stampRenderer.sprite = stampType;
//             approvedStamp.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
//             Pages paperScript = paper.GetComponent<Pages>();
//             paperScript.setStamped();
//             Files.SendMessage("Chosen");
//             //Debug.Log("This is the stamp's current local position: " + approvedStamp.transform.localPosition);
//             //Debug.Log("This is the paper's position: " + paper.transform.position);
//             //Debug.Log("This is the paper's children's index 0: " + paper.transform.GetChild(0));
//             //Debug.Log("This is the paper's children's index 1: " + paper.transform.GetChild(1));
//             //Debug.Log("This is the paper's child count: " + paper.transform.childCount);
//         }
//     }
// }
