using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyOut : MonoBehaviour
{

    SpriteRenderer myRenderer;
    float opacity;
    // Start is called before the first frame update
    void Start()
    {
        opacity = 1f;
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myRenderer.color = new Color(1f,1f,1f,1f);
        
    }
}
