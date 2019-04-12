using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {


    public static GameMaster gm;
    public static Color c;

    private void Start()
    {

        ShoppingControllerS.IsRobotSold = 1;
        if(gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            Debug.Log("gm boş");

        }

        c = playerPrefab.GetComponent<SpriteRenderer>().color;
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public static int currentHeath = 3;
    public GameObject gOverUI;
   
    
   
    


    public IEnumerator RespawnPlayer()
    {
        Debug.Log("TODO: Add waiting for spawn sound");
        yield return new WaitForSeconds(spawnDelay);

        Debug.Log("clone oluşturuluyor.");
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        
        
    }
    public static void KillPlayer(GameObject player)
    {
        Destroy(player.gameObject);
        currentHeath--;

        gm.StartCoroutine(gm.RespawnPlayer());
    }


    private void Update()
    {
        if(currentHeath <= 0)
        {
            gOverUI.SetActive(true);
            Time.timeScale = 0f;
        }


        if(ShoppingControllerS.IsHeathSold == 1)
        {
            if(currentHeath<3) {
                currentHeath = currentHeath + 1;
            }  
        }

        if(ShoppingControllerS.IsRobotSold == 1)
        {
           c.Equals("FFE89E");
        }
    }


    public int Gethealth()
    {
        return currentHeath;
    }

}
