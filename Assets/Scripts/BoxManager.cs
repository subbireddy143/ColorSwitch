using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{

    public float rotateSpeed,size;
    public Vector2 rotaterange,sizerange;
    Vector3 sizeChange;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(rotaterange.x, rotaterange.y);
        size = Random.Range(sizerange.x,sizerange.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
        sizeChange.x = sizeChange.y = sizeChange.z = size;
        transform.localScale = sizeChange;
    }
}
