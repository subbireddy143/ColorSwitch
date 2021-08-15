using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if(SkiPlayer.isrunning)
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
}
