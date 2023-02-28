using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprovedScript : MonoBehaviour
{
    public Sprite stampType;
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
        Debug.Log("Stamped Approved!");
        GameObject approvedStamp = new GameObject("Approved Stamp Picture");
        SpriteRenderer stampRenderer = approvedStamp.AddComponent<SpriteRenderer>();
        stampRenderer.sprite = stampType;
    }
}
