using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image artworkImage;
    void Start()
    {
        artworkImage.sprite = card.artwork;
    }

}
