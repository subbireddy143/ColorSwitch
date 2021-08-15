using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlopPlayer : MonoBehaviour
{
    bool isrunning,down;
    Rigidbody2D rb;
    public float speed = 1;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        isrunning = true;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        down = true;
        direction.x = 2f;
        direction.y = -1f;
        direction.z = 0;
     }

    // Update is called once per frame
    void Update()
    {
        if (isrunning) {
            transform.Translate(speed * direction * Time.deltaTime);
            if (Input.GetMouseButtonDown(0) && GroundCheck.isgrounded)
            {
                direction.y *= -1;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") {
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
