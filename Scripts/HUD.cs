using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void Update()
    {
        HeartUI.sprite = HeartSprites[gm.Gethealth()];
    }
}
