using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiPlayer : MonoBehaviour
{
    public Vector2 boundary;
    Rigidbody2D rb;

    public GameObject gameOver;
    public static bool isrunning;

    public Vector3 direction;

    public AudioSource audioSource;
    public AudioClip SkiingSound, CollectSound, TreeHitSound, HighScoreSound;

    private void Start()
    {
        isrunning = true;
        Time.timeScale = 1f;
        boundary.x = -2.5f;
        boundary.y = 2.5f;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        direction.y = (2 + SkiGameManager.score / 20);
        if (direction.y > 7) {
            direction.y = 7;
        }
        if (isrunning)
        {
            transform.Translate(direction * Time.deltaTime);
            stayInBoundary();

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                direction.x = touchPos.x - transform.position.x;
                //Debug.Log(direction.x);
                if (touch.phase == TouchPhase.Ended) {
                    direction.x = 0;
                }
            }
            
        }
    }

    void stayInBoundary() {
        if (transform.position.x < boundary.x) {
            Vector3 pos = transform.position;
            pos.x = boundary.x;
            transform.position = pos;
        }
        if (transform.position.x > boundary.y) {
            Vector3 pos = transform.position;
            pos.x = boundary.y;
            transform.position = pos;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) {
            case "Tree":
                audioSource.PlayOneShot(TreeHitSound);
                isrunning = false;
                StartCoroutine(GameEnds());
                break;
            case "Star":
                audioSource.PlayOneShot(CollectSound);
                Destroy(collision.gameObject);
                SkiGameManager.score += 1; 
                break;
        }
    }

    private IEnumerator GameEnds()
    {
        isrunning = false;
        //PlayerPrefs.SetInt("SkiHigh", 1);
        if (SkiGameManager.score > PlayerPrefs.GetInt("SkiHigh", 0))
        {
            audioSource.PlayOneShot(HighScoreSound);
            PlayerPrefs.SetInt("SkiHigh", SkiGameManager.score);
        }
        yield return new WaitForSeconds(0.1f);

        gameOver.SetActive(true);
        //Debug.Log("Game Ends");
        yield return null;
    }
}
