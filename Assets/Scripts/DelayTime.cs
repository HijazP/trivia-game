using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayTime : MonoBehaviour
{
    private float cdTime = 3f;
    public Text cdMid;
    public Text cdRight;
    public GameObject canvasMid;
    public GameObject canvasRight;

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
            canvasMid.SetActive(false);
            cdTime = 10;
            canvasRight.SetActive(true);
        }
    }
}
