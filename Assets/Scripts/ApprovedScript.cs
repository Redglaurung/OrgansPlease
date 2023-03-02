using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprovedScript : MonoBehaviour
{
    public Sprite stampType;
    // public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Pressed on me")]
    public void OnMouseDown()
    {
        BoxCollider2D col = gameObject.GetComponent<BoxCollider2D>();
        Bounds bound = col.bounds;
        // Debug.Log(bound.extents);
        Debug.Log(gameObject.transform.position);
        float width1 = gameObject.transform.position.x - bound.extents.x;   // width1 and width2 will give me 
        float width2 = gameObject.transform.position.x + bound.extents.x;   // the x-range which the stamp exists at

        float height1 = gameObject.transform.position.y - bound.extents.y;  // height1 and height 2 will give me the
        float height2 = gameObject.transform.position.y + bound.extents.y;  // y-range which the stamp exists at

        // If the paper is within the ranges defined above, I will set the stamp picture to be a child of the paper.

        GameObject[] papers = GameObject.FindGameObjectsWithTag("Pages");
        foreach (GameObject paper in papers)
        {
            // Check if the paper is within the ranges
            BoxCollider2D paperCollider = paper.GetComponent<BoxCollider2D>();
            Bounds paperBounds = paperCollider.bounds;
            float paperLeftX = paper.transform.position.x - paperBounds.extents.x;
            float paperRightX = paper.transform.position.x + paperBounds.extents.x;

            float paperTop = paper.transform.position.y + paperBounds.extents.y;
            float paperBottom = paper.transform.position.y - paperBounds.extents.y;

        }

        Debug.Log("Left: " + width1);
        Debug.Log("Right: " + width2);

        Debug.Log("Top: " + height2);
        Debug.Log("Bottom: " + height1);


    }

    private GameObject checkTopPaper()
    {

    }

    private void ApplyStamp()
    {
        Debug.Log("Stamped Approved!");
        GameObject approvedStamp = new GameObject("Approved Stamp Picture");
        SpriteRenderer stampRenderer = approvedStamp.AddComponent<SpriteRenderer>();
        stampRenderer.sprite = stampType;
    }
}
