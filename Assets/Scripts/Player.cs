using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using UnityEngine.Video;

public enum PlayerTurn { Move, NewRoom, NewItem };

public class Player : MonoBehaviour
{
    private PlayerClass playerClass = new Blank();

    public TMP_Text playerName;
    public TMP_Text[] SpeedValues = new TMP_Text[8];
    public TMP_Text[] MightValues = new TMP_Text[8];
    public TMP_Text[] SanityValues = new TMP_Text[8];
    public TMP_Text[] KnowledgeValues = new TMP_Text[8];

    public GameObject cardLayout;
    public List<Card> Cards;
    public PlayerTurn turn;

    private void Start()
    {
        Cards = new List<Card>();
        UpdatePlayer();
        turn = PlayerTurn.Move;
    }

    public void SwitchClass(int index)
    {
        switch (index)
        {
            case 0:
                playerClass = new Blank();
                break;
            case 1:
                playerClass = new Missy();
                break;
            case 2:
                playerClass = new Zoe();
                break;
            case 3:
                playerClass = new Jenny();
                break;
            case 4:
                playerClass = new Heather();
                break;
            case 5:
                playerClass = new Zostra();
                break;
            case 6:
                playerClass = new Vivian();
                break;
            case 7:
                playerClass = new Darrin();
                break;
            case 8:
                playerClass = new Ox();
                break;
            case 9:
                playerClass = new Brandon();
                break;
            case 10:
                playerClass = new Peter();
                break;
            case 11:
                playerClass = new Rhinehardt();
                break;
            case 12:
                playerClass = new Longfellow();
                break;
            default:
                Debug.Log("Unknown Player. Try Again?");
                break;
        }
        UpdatePlayer();
    }
    void ModifyStats(string type, int amount)
    {
        switch (type)
        {
            case "Speed":
                playerClass.KnowledgeLevel += amount;
                break;
            case "Might":
                playerClass.MightLevel += amount;
                break;
            case "Sanity":
                playerClass.SanityLevel += amount;
                break;
            case "Knowledge":
                playerClass.KnowledgeLevel += amount;
                break;
            default:
                Debug.Log("Unknown stat type. Try again?");
                break;
        }
        UpdatePlayer();
    }

    void UpdatePlayer()
    {
        playerName.text = playerClass.Name;
        for (int i = 0; i < 8; i++)
        {
            SpeedValues[i].text = playerClass.Speed[i + 1].ToString();
            MightValues[i].text = playerClass.Might[i + 1].ToString();
            SanityValues[i].text = playerClass.Sanity[i + 1].ToString();
            KnowledgeValues[i].text = playerClass.Knowledge[i + 1].ToString();
            SpeedValues[i].fontSize = 28;
            MightValues[i].fontSize = 28;
            SanityValues[i].fontSize = 28;
            KnowledgeValues[i].fontSize = 28;
            SpeedValues[i].color = Color.gray;
            MightValues[i].color = Color.gray;
            SanityValues[i].color = Color.gray;
            KnowledgeValues[i].color = Color.gray;
        }
        SpeedValues[playerClass.SpeedLevel-1].fontSize = 36;
        MightValues[playerClass.MightLevel-1].fontSize = 36;
        SanityValues[playerClass.SanityLevel-1].fontSize = 36;
        KnowledgeValues[playerClass.KnowledgeLevel-1].fontSize = 36;
        SpeedValues[playerClass.SpeedLevel-1].color = Color.black;
        MightValues[playerClass.MightLevel-1].color = Color.black;
        SanityValues[playerClass.SanityLevel-1].color = Color.black;
        KnowledgeValues[playerClass.KnowledgeLevel-1].color = Color.black;
    }

    public void UpdateCards()
    {
        foreach (Transform child in cardLayout.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Card card in Cards)
        {
            GameObject cardTransform = new GameObject();
            Image cardImage = cardTransform.AddComponent<Image>();
            cardImage.sprite = card.image;
            cardImage.name = card.image.name;
            cardImage.transform.SetParent(cardLayout.transform);
            cardImage.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void UpdateMap()
    {

    }
}
