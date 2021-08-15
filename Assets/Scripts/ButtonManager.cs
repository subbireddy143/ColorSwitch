using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void setActive(GameObject makePanelActive) {
        makePanelActive.SetActive(true);
    }
    public void setInactive(GameObject makePanelInactive) {
        makePanelInactive.SetActive(false);
    }
    public void StopTime() {
        Time.timeScale = 0;
    }
    public void StartTime() {
        Time.timeScale = 1f;
    }
    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
