using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketChange : MonoBehaviour
{
    public GameObject[] baskets;
    private int order = 0;

    void Start()
    {
        baskets[order].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            baskets[order].SetActive(false);

            if (order == 2)
            {
                order = 0;
            }
            else
            {
                order++;
            }

            baskets[order].SetActive(true);
        }
    }
}
