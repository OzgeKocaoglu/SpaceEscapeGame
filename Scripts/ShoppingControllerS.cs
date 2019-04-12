using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShoppingControllerS : MonoBehaviour
{

    public static int money;
    public Text moneyAmountText;
    public static int IsHeathSold = 0;
    public static int IsDamageSold = 0;
    public static int IsRobotSold = 0;


    public GameObject bH;
    public GameObject buttonH;
    public GameObject bD;
    public GameObject buttonD;
    public GameObject bR;
    public GameObject buttonR;
    public GameObject NotEnoughUI;
    public GameObject NotToBuyH;



    // Start is called before the first frame update
    void Start()
    {

        money = ScoreTextScript.GetInt();

        
      
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = money.ToString();
        
        
    }


    public void BuyHealth()
    {

        if (GameMaster.currentHeath < 3)
        {

            if (IsHeathSold == 0)
            {

                if (money >= 15)
                {
                    money = money - 15;
                    ScoreTextScript.coinAmount = money;
                    bH.SetActive(true);
                    IsHeathSold = 1;
                    buttonH.SetActive(false);

                }

                else
                {
                    NotEnoughUI.SetActive(true);
                }
            }


        }

        else
        {

            NotToBuyH.SetActive(true);
        }
    }

    public void BuyDamage()
    {
        if (IsDamageSold == 0)
        {

            if (money >= 20)
            {
                money = money - 20;
                ScoreTextScript.coinAmount = money;
                bD.SetActive(true);
                IsDamageSold = 1;
                buttonD.SetActive(false);

            }

            else
            {
                NotEnoughUI.SetActive(true);
            }
        }



    }


    public void BuyRobot()
    {
        if (IsRobotSold == 0)
        {

            if (money >= 30)
            {
                money = money - 30;
                ScoreTextScript.coinAmount = money;
                bR.SetActive(true);
                IsRobotSold = 1;
                buttonR.SetActive(false);

            }

            else
            {
                NotEnoughUI.SetActive(true);
            }
        }



    }

    public void GoNext2Scene()
    {

        SceneManager.LoadScene("SecondLevel");
    }


}
