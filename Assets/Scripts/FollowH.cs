using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowH : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player.position.x > transform.position.x)
        {
            transform.position = new Vector3( player.position.x, transform.position.y, transform.position.z);
        }
    }
}
