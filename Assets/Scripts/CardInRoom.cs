using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInRoom : MonoBehaviour
{
    public Sprite cardImage;
    public string cardType;
    private void OnTriggerEnter(Collider other)
    {
        if (cardImage != null && cardType != null)
        {
            Player player = other.gameObject.GetComponent<Player>();
            Card newCard = new Card
            {
                image = cardImage,
                type = cardType
            };
            player.Cards.Add(newCard);
            player.UpdateCards();
        }
        Destroy(gameObject);
    }
}
