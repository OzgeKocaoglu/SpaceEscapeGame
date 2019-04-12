using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPick : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ScoreTextScript.coinAmount += 1;
            Debug.Log("Coin taken");
            Destroy(gameObject);
        }
    }
}
