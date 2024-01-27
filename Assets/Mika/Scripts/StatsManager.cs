using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public int viewers, money, strikes;

    [SerializeField] float streamQuality;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Button[] updatesButtons;

    public float categoryCoolDown;
    [SerializeField] string currentCategory = "null";
    [SerializeField] Image[] categoryButtons;
    [SerializeField] Sprite[] categorySpritesNonSelected;
    [SerializeField] Sprite[] categorySpritesSelected;

    [SerializeField] TextMeshProUGUI plusText;
    [SerializeField] GameObject plusTextParent;

    [SerializeField] Image banned;

    private void Start()
    {
        ChangeCategory("JustChatting");
        InvokeRepeating("DownViewers", 10, 2);
        InvokeRepeating("UpMoney", 1, 1);
    }
    private void Update()
    {
        CheckMoney();
        CheckStrikes();
        print(viewers);
        plusTextParent.transform.position = Input.mousePosition;
        moneyText.text = new string(money + "�");
        categoryCoolDown = categoryCoolDown - 1 * Time.deltaTime;
    }
    public void PlusViewers()
    {
        if (streamQuality == 0 && categoryCoolDown > 3)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 1;
            plusTextParent.SetActive(true);
            plusTextParent.transform.position = Vector2.zero;
            plusText.text = "+1";
        }
        if (streamQuality == 1 && categoryCoolDown > 5)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 2;
            plusTextParent.SetActive(true);
            plusText.text = "+2";
        }
        if (streamQuality == 2 && categoryCoolDown > 5)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 3;
            plusTextParent.SetActive(true);
            plusText.text = "+3";
        }
        if (streamQuality == 3 && categoryCoolDown > 5)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 5;
            plusTextParent.SetActive(true);
            plusText.text = "+5";
        }
        if (streamQuality == 4 && categoryCoolDown > 5)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 7;
            plusTextParent.SetActive(true);
            plusText.text = "+7";
        }
        if (streamQuality == 5 && categoryCoolDown > 5)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 10;
            plusTextParent.SetActive(true);
            plusText.text = "+10";
        }
        if (streamQuality == 6 && categoryCoolDown > 5)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 15;
            plusTextParent.SetActive(true);
            plusText.text = "+15";
        }
        if (streamQuality == 10 && categoryCoolDown > 5)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 25;
            plusTextParent.SetActive(true);
            plusText.text = "+25";
        }
        if (streamQuality > 10 && categoryCoolDown > 5)
        {
            Invoke("EndPlusText", 0.5f);
            viewers += 30;
            plusTextParent.SetActive(true);
            plusText.text = "+30";
        }
    }
    private void EndPlusText()
    {
        plusTextParent.SetActive(false);
    }
    public void PayMoney(int cost)
    {
        money = money - cost;
    }
    public void AddQuality(int quality)
    {
        streamQuality += quality;
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
    private void CheckMoney()
    {
        if (money >= 65)
        {
            updatesButtons[0].interactable = true;
        }
        else
        {
            updatesButtons[0].interactable = false;
        }
        if (money >= 100)
        {
            updatesButtons[1].interactable = true;
        }
        else
        {
            updatesButtons[1].interactable = false;
        }
        if (money >= 245)
        {
            updatesButtons[2].interactable = true;
        }
        else
        {
            updatesButtons[2].interactable = false;
        }
        if (money >= 1200)
        {
            updatesButtons[3].interactable = true;
        }
        else
        {
            updatesButtons[3].interactable = false;
        }
    }
    private void CheckStrikes()
    {
        if(strikes == 3)
        {
            banned.gameObject.SetActive(true);
        }
    }
}
