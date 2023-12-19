using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] string targetMessage;
    public Color highlighColor = Color.cyan;

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
       
    }
    public void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        if(targetObject != null )
        {
            targetObject.SendMessage(targetMessage);
        }
    }
    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null )
        {
            sprite.color = highlighColor;
        }
    }
    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

}
