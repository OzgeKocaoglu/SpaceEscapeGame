using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBool : MonoBehaviour
{
    public float FireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;
    public Transform BulletTrailPrefab;
    float TimetoSpawnEffect = 0;
    float TimeforFire = 0;
    Transform firePoint1;
    public Transform MuzzleFlashPrefab;
    public Transform player;
    bool right = false;


    public float effectSpawnEffect = 0;

   
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player giris yapti");
            right = true;
        }
        
    }


    void Awake()
    {

        firePoint1 = this.gameObject.transform.GetChild(0);


        if (firePoint1 == null)
        {
            Debug.LogError("No firepoint1");

        }



    }

    void Update()
    {




        if (FireRate == 0)
        {
            if (right == true)
                Shoot();
            
        }

        else
        {
            if (right == true && Time.time > TimeforFire)
            {
                TimeforFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }

    }


    public void Shoot()
    {
        Vector2 firePointPosition1 = new Vector2(firePoint1.position.x, firePoint1.position.y);
        Vector2 playerPosition = new Vector2(player.position.x, player.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition1,  firePointPosition1-playerPosition, 80, whatToHit);

        if (Time.time >= TimetoSpawnEffect)
        {
            Effect();
            TimetoSpawnEffect = Time.time + 1 / effectSpawnEffect;
        }


        Debug.DrawLine(firePointPosition1, playerPosition, Color.cyan);


        if (hit.collider != null)
        {

            Debug.DrawLine(firePointPosition1, hit.point, Color.red);

            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage");
        }

    }


    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint1.position, firePoint1.rotation);
        Transform clone = (Instantiate(MuzzleFlashPrefab, firePoint1.position, firePoint1.rotation) as Transform);
        clone.parent = firePoint1;
        float size = UnityEngine.Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);

    }





   
}
