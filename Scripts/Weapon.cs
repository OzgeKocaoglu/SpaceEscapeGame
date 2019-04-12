using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float FireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;
    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;

    float TimetoSpawnEffect = 0;
    float TimeforFire = 0;
    public float effectSpawnEffect = 0;
    Transform firePoint1;
    private float hitCounter = 0f;


	// Use this for initialization
	void Awake () {

        firePoint1 = this.gameObject.transform.GetChild(0);
       
        if(firePoint1 == null)
        {
                Debug.LogError("No firepoint1");

        }
		
	}
	
	// Update is called once per frame
	void Update () {

        
        

        if(FireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Shoot();
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > TimeforFire)
            {
                TimeforFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }
		
	}

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition1 = new Vector2(firePoint1.position.x, firePoint1.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition1, mousePosition-firePointPosition1, 100, whatToHit);
        if(Time.time >= TimetoSpawnEffect)
        {
            Effect();
            TimetoSpawnEffect = Time.time + 1 / effectSpawnEffect;
        }
        
        
        Debug.DrawLine(firePointPosition1, mousePosition, Color.cyan);
        

        if(hit.collider != null)
        {
            
            Debug.DrawLine(firePointPosition1, hit.point, Color.red);
           
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage");

            if(hit.collider.tag == "Enemy")
            {

                if(hitCounter == 5)
                {
                    Debug.Log("Düşman yok edildi");
                    Destroy(hit.collider);
                    hitCounter = 0f;
                }
                hitCounter++;
          
            }
        }

    }


    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint1.position, firePoint1.rotation);
       Transform clone = (Instantiate(MuzzleFlashPrefab, firePoint1.position, firePoint1.rotation) as Transform);
        clone.parent = firePoint1;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);
  
    }
}
