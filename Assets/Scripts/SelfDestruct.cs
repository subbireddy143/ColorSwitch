﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
