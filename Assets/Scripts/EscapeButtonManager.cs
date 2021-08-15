using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeButtonManager : MonoBehaviour
{
    int count = 0;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0) {
            time += Time.deltaTime; 
            if (Input.GetKeyDown(KeyCode.Escape) && time < 2) {
                Application.Quit();
            }
            if (time > 2) {
                count = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (count == 0)
            {
                count++;
                showToast("Press again to exit game", 2);
            }
            //Debug.Log("Escape Button Clicked");
        }
    }
    IEnumerator waitForSeconds(float seconds) {
        yield return new WaitForSeconds(seconds); 
    }


    //This part is copies directly from stack overflow
    public Text txt;

    void showToast(string text,int duration)
    {
        StartCoroutine(showToastCOR(text, duration));
    }

    private IEnumerator showToastCOR(string text,
        int duration)
    {
        Color orginalColor = txt.color;

        txt.text = text;
        txt.enabled = true;

        //Fade in
        yield return fadeInAndOut(txt, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(txt, false, 0.5f);

        txt.enabled = false;
        txt.color = orginalColor;
    }

    IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        Color currentColor = Color.clear;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }
}
