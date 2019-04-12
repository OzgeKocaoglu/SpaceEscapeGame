using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRotation : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.rotation.y, player.rotation.x, player.rotation.z);
    }

    private void Update()
    {
        this.transform.Rotate(target.x, target.y, target.z, Space.Self);
    }


    
}