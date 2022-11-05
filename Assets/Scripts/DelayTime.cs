using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DelayTime : MonoBehaviour
{
    private float cdTime = 3f;
    public Text cdMid;
    public Text cdRight;
    public GameObject[] canvasMid;
    public GameObject canvasRight;
    public GameObject buttonBack;
    public GameObject buttonPlay;
    private bool isPlay = false;
    private bool playGame = false;

    void Start()
    {
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttonPlay);
    }

    void Update()
    {
        if (!playGame)
        {
            return;
        }

        if (cdTime >= 0)
        {
            cdMid.text = ((int)cdTime + 1).ToString();
            cdRight.text = ((int)cdTime + 1).ToString();
            cdTime -= Time.deltaTime;
        }
        else
        {
            if (!isPlay)
            {
                canvasMid[0].SetActive(false);
                cdTime = 30;
                canvasRight.SetActive(true);
                isPlay = true;
            }
            else if (isPlay)
            {
                canvasRight.SetActive(false);
                canvasMid[2].SetActive(false);
                canvasMid[1].SetActive(true);
                canvasMid[3].SetActive(false);
                TrashRandom.instance.GameOver();
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(buttonBack);
                TrashRandom.instance.ChangeStatus();
                BasketMove.instance.ChangeStatus();
            }
        }
    }

    public void PlayGame()
    {
        playGame = true;
    }

    public void ResetTime()
    {
        Time.timeScale = 1f;
    }
}
