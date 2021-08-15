using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkiGameManager : MonoBehaviour
{
    public static int score;

    public Text Score;
    public Text EndScore;

    static int offset=5;
    static Vector3 pos;

    public GameObject[] Rows;

    private void Start()
    {
        score = 0;
        pos.x = 0;
        pos.y = 0;
        pos.z = 0;
        
        spawnRow();
        spawnRow();
        spawnRow();
        spawnRow();
    }

    private void Update()
    {
        Score.text = score.ToString();
        EndScore.text = score.ToString();
        
    }

    public void updateHighScore(int highScore) {
        PlayerPrefs.SetInt("SkiHigh",highScore);
    }

    public void spawnRow() {
        pos.y += offset;
        pos.x = Random.Range(-1f, 1f);
        Instantiate(Rows[Random.Range(0, Rows.Length)], pos, Quaternion.identity);
        pos.x = 0;
    }
}
