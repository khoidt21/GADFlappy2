using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseBird : MonoBehaviour
{
    
    public GameObject redBird,greenBird,blueBird;
    public GameObject btnSelectorBird;
    public GameObject btnPlayClick;
    
    public GameObject blackImage;
    public Animator blackAnim;

    
    public Text enemyText;
    public GameObject btnEnemy;

    public Text cloundText;
    public GameObject btnClound;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        redBird.SetActive(true);
        PlayerPrefs.SetInt("bird", 1);
        // goi ham fadeIn 
        StartCoroutine(FindInBlack());
        // set mac dinh text button on off enemy
        if(PlayerPrefs.GetInt("Enemy") == 1)
        {
            enemyText.text = "Open Enemy : ON";
        }
        else
        {
            enemyText.text = "Open Enemy : OFF";
        }
        // set mac dinh text button on off clound 
        if(PlayerPrefs.GetInt("Clound") == 1)
        {
            cloundText.text = "Open Clound : ON";
        }
        else
        {
            cloundText.text = "Open Clound : OFF";
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
    // ham chon bird red blue green 
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
        // goi ham fadeOut khi sang scenses 2
        StartCoroutine(FadeOutBlack());
    }
    // ham FadeIn animations

    public IEnumerator FindInBlack()
    {
        blackAnim.Play("FadeIn");
        yield return new WaitForSecondsRealtime(0.9f);
        blackImage.SetActive(false);
    }
    // ham FadeOut animations va chuyen sang man hinh choi
    public IEnumerator FadeOutBlack()
    {
        blackImage.SetActive(true);
        blackAnim.Play("FadeOut");
        yield return new WaitForSecondsRealtime(0.9f);
        SceneManager.LoadScene("MH-2");
    }
    // ham phong to nut choose bird 
    public void PointerEnter()
    {
        btnSelectorBird.transform.localScale = new Vector2(1.1f, 1.1f);
    }
    // ham thu nho nut choose bird
    public void PointerExit()
    {
        btnSelectorBird.transform.localScale = new Vector2(1f, 1f);
    }
    // ham phong to nut vao man hinh 2
    public void PointerEnterClickScenesSecond()
    {
        btnPlayClick.transform.localScale = new Vector2(1.1f, 1.1f);
    }
    // ham thu nho nut vao man hinh 2
    public void PointerExitClickSecenesSecond()
    {
        btnPlayClick.transform.localScale = new Vector2(1f, 1f);
    }
    // ham on off enemy 
    public void TurnOnOffEnemy()
    {
        int choose = PlayerPrefs.GetInt("Enemy");
        if(choose == 0)
        {
            PlayerPrefs.SetInt("Enemy", 1);
            enemyText.text = "Open Enemy : ON";
        }
        else
        {
            PlayerPrefs.SetInt("Enemy", 0);
            enemyText.text = "Open Enemy : OFF";
        }
    }
    // ham on off clound 
    public void TurnOnOffClound()
    {
        int chooseClound = PlayerPrefs.GetInt("Clound");
        if(chooseClound == 0)
        {
            PlayerPrefs.SetInt("Clound", 1);
            cloundText.text = "Open Clound : ON";
        }
        else
        {
            PlayerPrefs.SetInt("Clound", 0);
            cloundText.text = "Open Clound : OFF";
        }
    }

}
