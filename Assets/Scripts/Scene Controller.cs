using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    [SerializeField] MemoryCard originalCard;
    [SerializeField] Sprite[] sprites;
    [SerializeField] TMP_Text text;

    public const int columns = 4;
    public const int rows = 2;
    public const float offsetX = 2f;
    public const float offsetY = -2.5f;

    private MemoryCard firstCard;
    private MemoryCard secondCard;
    private int score;
    private void Start()
    {
        score = 0;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);
        Vector3 startPos = originalCard.transform.position;
        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0 )
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }
                int index = j * columns + i;
                int id= numbers[index];
                card.SetCard(id, sprites[id]);
                float posX = startPos.x + offsetX * i;
                float posY = startPos.y + offsetY * j;
                card.transform.position = new Vector3(posX, posY, startPos.z); 
            }
        }
    }
    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length - 1; i++)
        {
            int randomNumber = UnityEngine.Random.Range(i, newArray.Length -1);
            (newArray[randomNumber], newArray[i]) = (newArray[i], newArray[randomNumber]);
        }
        return newArray;    
    }
    public void CardRevealed(MemoryCard card)
    {
        if(firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
            StartCoroutine(CheckMath());
        }
    }
    private IEnumerator CheckMath()
    {
        if(firstCard.ID == secondCard.ID)
        {
            score++;
            text.text = $"Score: {score}";
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            firstCard.SetActiveCardBack();
            secondCard.SetActiveCardBack();
        }
        firstCard = null;
        secondCard = null;
    }
    public bool CanReveal
    {
        get { return secondCard == null;}
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
