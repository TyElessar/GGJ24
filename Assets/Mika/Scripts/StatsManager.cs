using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public int viewers, money;

    [SerializeField] float streamQuality;

    [SerializeField] TextMeshProUGUI moneyText;

    public float categoryCoolDown;
    [SerializeField] string currentCategory = "null";
    [SerializeField] Image[] categoryButtons;
    [SerializeField] Sprite[] categorySpritesNonSelected;
    [SerializeField] Sprite[] categorySpritesSelected;

    private void Start()
    {
        InvokeRepeating("DownViewers", 5, 5);
        InvokeRepeating("UpMoney", 5, 5);
    }
    private void Update()
    {
        print(viewers);
        moneyText.text = new string(money + "€");
        categoryCoolDown = categoryCoolDown - 1 * Time.deltaTime;
    }
    public void PlusViewers()
    {
        if (streamQuality <= 20 && categoryCoolDown > 3)
        {
            viewers += 1;
        }
        if (streamQuality >= 21 && streamQuality <= 40 && categoryCoolDown > 5)
        {
            viewers += 2;
        }
        if (streamQuality >= 41 && streamQuality <= 60 && categoryCoolDown > 5)
        {
            viewers += 4;
        }
        if (streamQuality >= 61 && streamQuality <= 80 && categoryCoolDown > 5)
        {
            viewers += 8;
        }
        if (streamQuality >= 81 && categoryCoolDown > 5)
        {
            viewers += 16;
        }
    }
    public void AddQuality()
    {
        streamQuality += 20;
    }
    public void ChangeCategory(string category)
    {
        if (category != currentCategory)
        {
            currentCategory = category;
            categoryCoolDown = 20;

            switch (currentCategory)
            {
                case "IRL":
                    categoryButtons[0].sprite = categorySpritesSelected[0];
                    categoryButtons[1].sprite = categorySpritesNonSelected[1];
                    categoryButtons[2].sprite = categorySpritesNonSelected[2];
                    categoryButtons[3].sprite = categorySpritesNonSelected[3];
                    break;
                case "JustChatting":
                    categoryButtons[0].sprite = categorySpritesNonSelected[0];
                    categoryButtons[1].sprite = categorySpritesSelected[1];
                    categoryButtons[2].sprite = categorySpritesNonSelected[2];
                    categoryButtons[3].sprite = categorySpritesNonSelected[3];
                    break;
                case "Game_1":
                    categoryButtons[0].sprite = categorySpritesNonSelected[0];
                    categoryButtons[1].sprite = categorySpritesNonSelected[1];
                    categoryButtons[2].sprite = categorySpritesSelected[2];
                    categoryButtons[3].sprite = categorySpritesNonSelected[3];
                    break;
                case "Game_2":
                    categoryButtons[0].sprite = categorySpritesNonSelected[0];
                    categoryButtons[1].sprite = categorySpritesNonSelected[1];
                    categoryButtons[2].sprite = categorySpritesNonSelected[2];
                    categoryButtons[3].sprite = categorySpritesSelected[3];
                    break;
            }
        }
    }
    private void DownViewers()
    {
        if (categoryCoolDown <= 0)
        {
            viewers -= 5;
        }
    }
    private void UpMoney()
    {
        money = money + viewers / 100;
    }
}
