using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static Vector3 pos;
    static float offset = 6;

    // Start is called before the first frame update
    void Start()
    {
        pos.x = 0;
        pos.y = 3;
        pos.z = 0;
    }

    public static void spawn(GameObject Box) {
        Instantiate(Box,pos,Quaternion.identity);
        pos.y += offset;
    }

    public static void spawn(GameObject spawn, float x, float y, float z)
    {
        Vector3 pos;
        pos = GameManager.pos; 
        pos.x += x;
        pos.y += y;
        pos.z += z;
        Instantiate(spawn, pos, Quaternion.identity);
    }
}
