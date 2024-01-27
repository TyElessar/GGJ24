using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public int viewers, money, strikes;
    bool flat, crypto;
    int viewersToAdd = 1;

    [SerializeField] Animator irl_Anim;
    [SerializeField] float actionCountdown;

    [SerializeField] GameObject[] donationNotifs;
    bool don20_0 = false, don20_1 = false, don50_0 = false, don50_1 = false, don50_2 = false, don100_0 = false, don100_1 = false, don100_2 = false,
     don1000_0 = false, don1000_1 = false, don1000_2 = false, don1000_3 = false, don1000_4 = false;

    [SerializeField] Image[] imagesFromStream;
    [SerializeField] Sprite newChair;

    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Button[] updatesButtons;

    public float categoryCoolDown;
    [SerializeField] string currentCategory = "null";
    [SerializeField] Image[] categoryButtons;
    [SerializeField] Sprite[] categorySpritesNonSelected, categorySpritesSelected;
    [SerializeField] GameObject coolDownZeroNotification;
    bool coolDownToZeroNoticed = false;

    [SerializeField] TextMeshProUGUI viewersText;

    [SerializeField] TextMeshProUGUI plusText;
    [SerializeField] GameObject plusTextParent, nullTextParent;

    [SerializeField] Image strikeImage, bannedImage;

    bool andorra = false;

    int moneyRatio = 100;

    private void Start()
    {
        ChangeCategory("JustChatting");
        InvokeRepeating("DownViewers", 10, 2);
        InvokeRepeating("UpMoney", 1, 1);
        InvokeRepeating("GenerateDonations", 1, 1);
    }
    private void Update()
    {
        CheckForUpgrades();
        CheckStrikes();
        CheckCooldown();

        plusTextParent.transform.position = Input.mousePosition;
        nullTextParent.transform.position = Input.mousePosition;

        if(actionCountdown > 0f)
        {
            irl_Anim.SetBool("action", true);
        }
        else
        {
            irl_Anim.SetBool("action", false);
        }

        actionCountdown = actionCountdown - 1f * Time.deltaTime;

        if (money < 10000)
        {
            moneyText.text = new string(money+ " €");
        }
        else
        {
            moneyText.text = new string(money / 1000 + "k " + "€");
        }
        if (viewers < 10000)
        {
            viewersText.text = new string(viewers.ToString());
        }
        else
        {
            viewersText.text = new string(viewers/1000 + "k");
        }
        categoryCoolDown = categoryCoolDown - 1 * Time.deltaTime;
    }
    public void PlusViewers()
    {
        actionCountdown = 0.4f;
        if (categoryCoolDown < 5f)
        {
            nullTextParent.SetActive(true);
            Invoke("EndPlusText", 0.5f);
        }
        else
        {
            Invoke("EndPlusText", 0.5f);
            viewers += viewersToAdd;
            plusTextParent.SetActive(true);
            plusTextParent.transform.position = Vector2.zero;
            plusText.text = "+" + viewersToAdd;
        }
    }
    private void EndPlusText()
    {
        plusTextParent.SetActive(false);
        nullTextParent.SetActive(false);
    }
    public void PayMoney(int cost)
    {
        money = money - cost;
    }
    public void AddViewersMaker(string whichAdd)
    {
        if (whichAdd == "lightring")
        {
            viewersToAdd += 1;
            for (int i = 0; i < imagesFromStream.Length; i++)
            {
                imagesFromStream[i].color = Color.white;
            }
        }
        if (whichAdd == "microphone")
        {
            viewersToAdd += 2;
        }
        if (whichAdd == "gamingchair")
        {
            viewersToAdd += 4;
            imagesFromStream[1].sprite = newChair;
        }
        if (whichAdd == "focus")
        {
            viewersToAdd += 8;
        }
        if (whichAdd == "splitscreen")
        {
            viewersToAdd += 16;
        }
        if (whichAdd == "PC")
        {
            viewersToAdd += 32;
        }
        if (whichAdd == "girlfiend")
        {
            viewersToAdd += 64;
        }
        if (whichAdd == "bots")
        {
            viewersToAdd += 128;
        }
    }
    public void AddMoneyRatio(string whichAdd)
    {
        if (whichAdd == "merch")
        {
            moneyRatio = moneyRatio - 20;
        }
        if (whichAdd == "andorra")
        {
            moneyRatio = moneyRatio - 30;
        }
    }
    public void AddMoneyMaker(string whichAdd)
    {
        if (whichAdd == "flat")
        {
            flat = true;
        }
        if (whichAdd == "crypto")
        {
            flat = true;
        }

    }
    public void Donation(int donation)
    {
        money = money + donation;
    }
    public void Donation2(string donation)
    {
        if (donation == "20_0")
        {
            don20_0 = false;
            donationNotifs[0].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "20_1")
        {
            don20_1 = false;
            donationNotifs[1].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "50_0")
        {
            don50_0 = false;
            donationNotifs[2].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "50_1")
        {
            don50_1 = false;
            donationNotifs[3].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "50_2")
        {
            don50_2 = false;
            donationNotifs[4].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "100_0")
        {
            don100_0 = false;
            donationNotifs[5].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "100_1")
        {
            don100_1 = false;
            donationNotifs[6].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "100_2")
        {
            don100_2 = false;
            donationNotifs[7].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "1000_0")
        {
            don1000_0 = false;
            donationNotifs[8].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "1000_1")
        {
            don1000_1 = false;
            donationNotifs[9].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "1000_2")
        {
            don1000_2 = false;
            donationNotifs[10].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "1000_3")
        {
            don1000_3 = false;
            donationNotifs[11].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
        if (donation == "1000_4")
        {
            don1000_4 = false;
            donationNotifs[12].transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
        }
    }
    public void AddStrike()
    {
        strikes++;
        strikeImage.gameObject.SetActive(true);
        Invoke("DisappearStrikeImage", 1f);
    }
    private void DisappearStrikeImage()
    {
        strikeImage.gameObject.SetActive(false);
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
            viewers = viewers * 9 / 10;
        }
    }
    private void UpMoney()
    {
        money = money + viewers / moneyRatio;
        if (flat)
        {
            money = money + 50;
        }
        if (crypto)
        {
            money = money + 150;
        }
    }
    private void CheckForUpgrades()
    {
        if (money >= 0)
        {
            updatesButtons[0].gameObject.SetActive(true);
            if (money >= 45)
            {
                updatesButtons[0].interactable = true;
            }
            else
            {
                updatesButtons[0].interactable = false;
            }
        }
        else
        {
            updatesButtons[0].gameObject.SetActive(false);
        }

        if (money >= 0)
        {
            updatesButtons[1].gameObject.SetActive(true);
            if (money >= 100)
            {
            updatesButtons[1].interactable = true;
            }
            else
            {
                updatesButtons[1].interactable = false;
            }
        }
        else
        {
            updatesButtons[1].gameObject.SetActive(false);
        }

        if (money >= 0)
        {
            updatesButtons[2].gameObject.SetActive(true);
            if (money >= 400)
            {
                updatesButtons[2].interactable = true;
            }
            else
            {
                updatesButtons[2].interactable = false;
            }
        }
        else
        {
            updatesButtons[2].gameObject.SetActive(false);
        }

        if (money >= 0)
        {
            updatesButtons[3].gameObject.SetActive(true);
            if (money >= 900)
            {
                updatesButtons[3].interactable = true;
            }
            else
            {
                updatesButtons[3].interactable = false;
            }
        }
        else
        {
            updatesButtons[3].gameObject.SetActive(false);
        }

        if (money >= 0)
        {
            updatesButtons[4].gameObject.SetActive(true);
            if (money >= 1000)
            {
                updatesButtons[4].interactable = true;
            }
            else
            {
                updatesButtons[4].interactable = false;
            }
        }
        else
        {
            updatesButtons[4].gameObject.SetActive(false);
        }

        if (money >= 0)
        {
            updatesButtons[5].gameObject.SetActive(true);
            if (money >= 1500)
            {
                updatesButtons[5].interactable = true;
            }
            else
            {
                updatesButtons[5].interactable = false;
            }
        }
        else
        {
            updatesButtons[5].gameObject.SetActive(false);
        }

        if (money >= 0)
        {
            updatesButtons[6].gameObject.SetActive(true);
            if (money >= 5000)
            {
                updatesButtons[6].interactable = true;
            }
            else
            {
                updatesButtons[6].interactable = false;
            }
        }
        else
        {
            updatesButtons[6].gameObject.SetActive(false);
        }

        if (money >= 0)
        {
            updatesButtons[7].gameObject.SetActive(true);
            if (money >= 7500)
            {
                updatesButtons[7].interactable = true;
            }
            else
            {
                updatesButtons[7].interactable = false;
            }
        }
        else
        {
            updatesButtons[7].gameObject.SetActive(false);
        }

        if (viewers > 10000)
        {
            updatesButtons[8].gameObject.SetActive(true);
            if (money >= 15000)
            {
                updatesButtons[8].interactable = true;
            }
            else
            {
                updatesButtons[8].interactable = false;
            }
        }
        else
        {
            updatesButtons[8].gameObject.SetActive(false);
        }

        if (viewers > 150000)
        {
            updatesButtons[9].gameObject.SetActive(true);
            if (money >= 50000)
            {
                updatesButtons[9].interactable = true;
            }
            else
            {
                updatesButtons[9].interactable = false;
            }
        }
        else
        {
            updatesButtons[9].gameObject.SetActive(false);
        }

        if (viewers > 200000)
        {
            updatesButtons[10].gameObject.SetActive(true);
            if (money >= 100000)
            {
                updatesButtons[10].interactable = true;
            }
            else
            {
                updatesButtons[10].interactable = false;
            }
        }
        else
        {
            updatesButtons[10].gameObject.SetActive(false);
        }

        if (viewers > 250000)
        {
            updatesButtons[11].gameObject.SetActive(true);
            if (money >= 200000)
            {
                updatesButtons[11].interactable = true;
            }
            else
            {
                updatesButtons[11].interactable = false;
            }
        }
        else
        {
            updatesButtons[11].gameObject.SetActive(false);
        }

    }
    private void CheckCooldown()
    {
        if (categoryCoolDown <= 0f && !coolDownToZeroNoticed)
        {
            coolDownToZeroNoticed = true;
            coolDownZeroNotification.transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
        }
        if (categoryCoolDown > 0)
        {
            coolDownToZeroNoticed = false;
        }
    }
    private void GenerateDonations()
    {
        int donationRatio = 10;
        if (Random.Range(0, donationRatio) == 0)
        {

            if (viewers < 250)
            {
                if (!don20_0)
                {
                    don20_0 = true;
                    donationNotifs[0].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
                else if (!don20_1)
                {
                    don20_1 = true;
                    donationNotifs[1].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
            }
            if (viewers > 251 && viewers < 1000)
            {
                donationRatio = 8;
                if (!don50_0)
                {
                    don50_0 = true;
                    donationNotifs[2].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
                else if (!don50_1)
                {
                    don50_1 = true;
                    donationNotifs[3].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
                else if (!don50_2)
                {
                    don50_2 = true;
                    donationNotifs[4].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
            }
            if (viewers > 1001 && viewers < 10000)
            {
                donationRatio = 4;
                if (!don100_0)
                {
                    don100_0 = true; 
                    donationNotifs[5].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
                else if (!don100_1)
                {
                    don100_1 = true;
                    donationNotifs[6].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));

                }
                else if (!don100_2)
                {
                    don100_2 = true;
                    donationNotifs[7].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
            }
            if (viewers > 10001)
            {
                donationRatio = 3;
                if (!don1000_0)
                {
                    don1000_0 = true;
                    donationNotifs[8].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
                else if (!don1000_1)
                {
                    don1000_1 = true;
                    donationNotifs[9].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
                else if (!don1000_2)
                {
                    don1000_2 = true;
                    donationNotifs[10].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
                else if (!don1000_3)
                {
                    don1000_3 = true;
                    donationNotifs[11].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
                else if (!don1000_4)
                {
                    don1000_4 = true;
                    donationNotifs[12].transform.position = new Vector2(Random.Range(Screen.width / 5, Screen.width / 5 * 4), Random.Range(Screen.height / 5, Screen.height / 5 * 4));
                }
            }
        }
    }
    public void QuitCoolDownNotification()
    {
        coolDownZeroNotification.transform.position = new Vector2(Screen.width * 5, Screen.height * 5);
    }
    private void CheckStrikes()
    {
        if(strikes == 3)
        {
            bannedImage.gameObject.SetActive(true);
        }
    }
}
