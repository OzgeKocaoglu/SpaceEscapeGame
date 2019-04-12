using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    
    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100; //saglik seviyesi
       
        
    }
    
    public PlayerStats playerStats = new PlayerStats(); //nesne oluşturuldu

    public int fallBoundary = -20;
  


    private void Update()
    {
        if(transform.position.y <= fallBoundary) //oyuncu aşağı düştüğünde
        {
            DamagePlayer(99999); //ölmesi için
            

        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if(playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this.gameObject);
            
            
        }
    }

   

}
