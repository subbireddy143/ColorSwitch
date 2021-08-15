using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    static float offset = 15;
    public GameObject[] floors;
    static Vector3 pos;
    private void Start()
    {
        pos.x = 35;
        pos.y = 0;
        pos.z = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.gameObject.tag == "Row") {
            Debug.Log("Row trigger");
            Destroy(collision.gameObject);
            SpawnFloor();
        }
    }

    private void SpawnFloor() {
        pos.x += offset;
        Instantiate(floors[Random.Range(0, floors.Length)], pos, Quaternion.identity);
    }
}
