using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseBird : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject redBird,greenBird,blueBird;
    public GameObject blackImage;
    public Animator blackAnim;

    void Start()
    {
        Time.timeScale = 1;
        redBird.SetActive(true);
        StartCoroutine(StopBlack());
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void chooseBird()
    {
        if (blueBird.activeSelf)
        {
            redBird.SetActive(true);
            blueBird.SetActive(false);
            greenBird.SetActive(false);
            PlayerPrefs.SetInt("bird", 1);
        }
        else if (redBird.activeSelf)
        {
            greenBird.SetActive(true);
            redBird.SetActive(false);
            blueBird.SetActive(false);
            PlayerPrefs.SetInt("bird", 2);

        }
        else if (greenBird.activeSelf)
        {
            blueBird.SetActive(true);
            greenBird.SetActive(false);
            redBird.SetActive(false);
            PlayerPrefs.SetInt("bird", 3);
        }

    }
    
    // click button vao man hinh 2
    public void playButtonClickScence()
    {
        // SceneManager.LoadScene("MH-2");
        StartCoroutine(StartBlack());
    }
    

    // ham FadeIn animations
    
    public IEnumerator StopBlack()
    {
        blackAnim.Play("FadeIn");
        yield return new WaitForSecondsRealtime(1f);
        blackImage.SetActive(false);
    }
    // ham FadeOut animations va chuyen sang man hinh choi
    public IEnumerator StartBlack()
    {
        blackImage.SetActive(true);
        blackAnim.Play("FadeOut");
        yield return new WaitForSecondsRealtime(0.8f);
        SceneManager.LoadScene("MH-2");
    }
   
}
