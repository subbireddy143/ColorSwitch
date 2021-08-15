using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowDestruct : MonoBehaviour
{
    public SkiGameManager ski;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Row") {
            Destroy(collision.gameObject);
            ski.spawnRow();
        }
    }
}
