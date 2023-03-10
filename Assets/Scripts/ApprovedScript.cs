using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprovedScript : MonoBehaviour
{
    public SpriteRenderer myRenderer;
    public Sprite stampType;
    public float stampScale;
    public float stampX;
    public float stampY;
    // public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Pressed on me")]
    public void OnMouseDown()
    {
        BoxCollider2D stampCollider = gameObject.GetComponent<BoxCollider2D>();
        Bounds stampBounds = stampCollider.bounds;
        // Debug.Log(bound.extents);
        // Debug.Log(gameObject.transform.position);
        //float widthLeft = gameObject.transform.position.x - bound.extents.x;   // width1 and width2 will give me the
        //float widthRight = gameObject.transform.position.x + bound.extents.x;   // the x-range which the stamp exists at

        //float heightBottom = gameObject.transform.position.y - bound.extents.y;  // height1 and height 2 will give me the
        //float heightTop = gameObject.transform.position.y + bound.extents.y;  // y-range which the stamp exists at

        // If the paper is within the ranges defined above, I will set the stamp picture to be a child of the paper.

        GameObject[] papers = GameObject.FindGameObjectsWithTag("Pages");
        Debug.Log("This is stampBounds.max " + stampBounds.max);
        Debug.Log("This is stampBounds.min " + stampBounds.min);
        // int highestPage = 6;
        foreach (GameObject paper in papers)
        {
            // Check if page is the top page in the Pages Sorting Layer
            // Make sure that we can't stamp when the page is in Looking At Mode
            //if((paper.myRenderer.sortingOrder == 6) && (paper.myRenderer.sortingLayerName != "Looking At"))
            
            // Check if the paper is within the ranges
            BoxCollider2D paperCollider = paper.GetComponent<BoxCollider2D>();
            Bounds paperBounds = paperCollider.bounds;

            // var means figure out the data type for me
            var intersection = 
                Vector3.Min(stampBounds.max, paperBounds.max)
                - Vector3.Max(stampBounds.min, paperBounds.min);


            if (intersection.x > 0 && intersection.y > 0)       // Both intersection.x and intersection.y should be positive because negative width and height shouldn't result in an area
            {
                if (stampBounds.Intersects(paperBounds))
                {
                    Debug.Log("Paper is intersecting with the stamper!");
                    float area = intersection.x * intersection.y;
                    if (area > 3)
                    {
                        Debug.Log("This is the paper: " + paper + "and this is my area: " + area);
                        ApplyStamp(paper);
                    }
                }

                
            }
        }
    }

    private GameObject checkTopPaper()
    {
        return null;
    }

    private void ApplyStamp(GameObject paper)
    {
        Debug.Log("Stamped Approved!");
        GameObject approvedStamp = new GameObject("Approved Stamp Picture");
        Vector3 stampPosition = approvedStamp.transform.position;
        approvedStamp.transform.SetParent(paper.transform);
        SpriteRenderer stampRenderer = approvedStamp.AddComponent<SpriteRenderer>();
        stampRenderer.sprite = stampType;
        approvedStamp.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        Debug.Log("This is the current position: " + approvedStamp.transform.position);
        stampPosition.x = -9;
        stampPosition.y = 3;
        

    }
}
