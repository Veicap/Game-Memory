using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] GameObject cardBack;
    [SerializeField] SceneController controller;
    private int _id;
    private void OnMouseDown()
    {
        if(cardBack.activeSelf && controller.CanReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }
    public void SetCard(int id, Sprite sprite)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public int ID
    {
        get { return _id; }
    }
    public void SetActiveCardBack()
    {
        cardBack.SetActive(true);
    }
}
