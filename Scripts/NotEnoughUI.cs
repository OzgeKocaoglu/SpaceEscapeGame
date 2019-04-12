using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughUI : MonoBehaviour
{
    public GameObject backUI;

    public void GoBack()
    {
        backUI.SetActive(false);
    }
}
