using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassicPlayer : MonoBehaviour
{
    
    private bool isrunning;
    enum Playercolor { yellow,blue,orange,skyblue};
    Rigidbody2D rb;

    [SerializeField]
    Playercolor self ;
    public Vector2 force;
    SpriteRenderer PlayerSprite;

    public GameObject Box;

    public Text Score;
    int score;

    public GameObject gameOver;
    public Text endScore;

    public GameObject particles;
    public GameObject ColorChanger;

    public AudioClip GameOverSound, CollectSound, HighScoreSound, ColorChangeSound, BounceSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isrunning = true;
        score = 0;
        self = Playercolor.yellow;
        PlayerSprite = GetComponent<SpriteRenderer>();
        PlayerSprite.color = new Color(1,1,0,1);
        rb = GetComponent<Rigidbody2D>();
        GameManager.spawn(Box);
        GameManager.spawn(Box);
        GameManager.spawn(ColorChanger, 0, 3, 0);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        changeColor(self);
        if (isrunning && Input.GetMouseButtonDown(0)) {
            rb.velocity = force;
            audioSource.PlayOneShot(BounceSound,0.6F);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isrunning) {
            if (collision.gameObject.tag == "Star")
            {
                audioSource.PlayOneShot(CollectSound, 0.9F);
                Destroy(collision.gameObject);
                score++;
                Score.text = score.ToString();

                GameManager.spawn(Box);
                GameManager.spawn(ColorChanger,0,3,0);
            }
            if (collision.gameObject.tag == "ColorChange") {
                audioSource.PlayOneShot(ColorChangeSound, 0.8F);
                Destroy(collision.gameObject);
                int num = Random.Range(1,5);
                switch (num) {
                    case 1:
                        if (self != Playercolor.yellow)
                            self = Playercolor.yellow;
                        else self = Playercolor.orange;
                        break;
                    case 2:
                        if (self != Playercolor.blue)
                            self = Playercolor.blue;
                        else self = Playercolor.yellow;
                        break;
                    case 3:
                        if (self != Playercolor.orange)
                            self = Playercolor.orange;
                        else self = Playercolor.skyblue;
                        break;
                    case 4:
                        if (self != Playercolor.skyblue)
                            self = Playercolor.skyblue;
                        else self = Playercolor.blue;
                        break;
                    default:
                        if (self != Playercolor.yellow)
                            self = Playercolor.yellow;
                        else self = Playercolor.orange;
                        break;
                }
            }
            switch (collision.gameObject.tag)
            {
                case "YellowEdge":
                    if (self != Playercolor.yellow)
                    {
                        StartCoroutine(GameEnds());
                    }
                    break;
                case "BlueEdge":
                    if (self != Playercolor.blue)
                    {
                        StartCoroutine(GameEnds());
                    }
                    break;
                case "SkyBlue":
                    if (self != Playercolor.skyblue)
                    {
                        StartCoroutine(GameEnds());
                    }
                    break;
                case "OrangeEdge":
                    if (self != Playercolor.orange)
                    {
                        StartCoroutine(GameEnds());
                    }
                    break;
            }
        }
    }

    void changeColor(Playercolor color) {
        switch (color) {
            case Playercolor.yellow:
                PlayerSprite.color = new Color(1, 1, 0, 1);//yellow
                break;
            case Playercolor.blue:
                PlayerSprite.color = new Color(0, 0, 1, 1);//blue
                break;
            case Playercolor.orange:
                PlayerSprite.color = new Color32(255, 69, 0, 255);//orange
                break;
            case Playercolor.skyblue:
                PlayerSprite.color = new Color32(135, 206, 235, 255);//skyblue
                break;
            default:
                PlayerSprite.color = new Color(1, 1, 0, 1);//yellow
                break;
        }
    }

    private IEnumerator GameEnds()
    {
        isrunning = false;
        if (score >= PlayerPrefs.GetInt("ClassicHigh", 0))
        {
            endScore.text = score.ToString()+"\n(High Score)";
            audioSource.PlayOneShot(HighScoreSound, 1F);
            PlayerPrefs.SetInt("ClassicHigh", score);
        }
        else {
            endScore.text = score.ToString();
            audioSource.PlayOneShot(GameOverSound, 0.8F);
        }
        PlayerSprite.enabled = false;
        particles.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        gameOver.SetActive(true);
        Debug.Log("Game Ends");
        yield return null;
    }

}
