using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteReshape : MonoBehaviour
{

    public float mag = 100;

    // Start is called before the first frame update
    void Start()
    {
        float targetHeight = mag;
        var bounds = GetComponent<SpriteRenderer>().sprite.bounds;
        var factor = targetHeight / bounds.size.y;
        transform.localScale = new  Vector3(factor, factor, factor);
    }
    
}
