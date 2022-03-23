using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    //[SerializeField]
    //private float minX = -30;
    //[SerializeField]
   // private float minX = 255;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;
        tempPos = transform.position;
        tempPos.x = player.position.x;
         
        
        transform.position = tempPos;
    }
}
