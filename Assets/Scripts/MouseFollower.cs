using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class MouseFollower : MonoBehaviour
{

    public Collider2D MouseCollider;
    public Collider2D StampCollider;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        
        if (MouseCollider.IsTouching(StampCollider))
            {
                spriteRenderer.sprite = spriteArray[2]; 
            }
        else {
            spriteRenderer.sprite = spriteArray[0];
        }

    }
}
