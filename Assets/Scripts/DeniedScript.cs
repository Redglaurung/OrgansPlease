using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeniedScript : MonoBehaviour
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

    [ContextMenu("Stamping")]
    public void OnMouseDown()
    {
        Debug.Log("Stamped Denied!");
        GameObject deniedStamp = new GameObject("Denied Stamp Picture");
        SpriteRenderer stampRenderer = deniedStamp.AddComponent<SpriteRenderer>();
        stampRenderer.sprite = stampType;
    }
}
