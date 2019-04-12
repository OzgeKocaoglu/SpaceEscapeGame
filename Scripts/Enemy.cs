using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
   



    private void Start()
    {
        anim = GetComponent<Animator>();
        

    }


    private void Update()
    {
        if(this.GetComponent<Collider2D>() == null)
        {
            Destroy(gameObject);
        }


       
        

    }


   




}
