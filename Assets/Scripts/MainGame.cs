using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TapButtonClick;
    public GameObject blueb, greenb, redb;
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick()
    {
        TapButtonClick.SetActive(false);
        Time.timeScale = 1;
        
        //disply chim
        int bird = PlayerPrefs.GetInt("bird");

       // Debug.Log(bird);

        if(bird == 1)
        {
            redb.SetActive(true);
        }
        else if (bird == 2)
        {
            greenb.SetActive(true);
        }
        else if (bird == 3)
        {
            blueb.SetActive(true);
        }
    }
}
