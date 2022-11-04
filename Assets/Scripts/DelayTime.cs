using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayTime : MonoBehaviour
{
    private float cdTime = 3f;
    public Text cdMid;
    public Text cdRight;
    public GameObject[] canvasMid;
    public GameObject canvasRight;
    private bool isPlay = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
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
                canvasMid[1].SetActive(true);
                TrashRandom.instance.ChangeStatus();
                BasketMove.instance.ChangeStatus();
                Time.timeScale = 0f;
            }
        }
    }
}
