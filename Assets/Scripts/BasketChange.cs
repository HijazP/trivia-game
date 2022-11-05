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
        baskets[order].transform.position = new Vector3(baskets[order].transform.position.x, baskets[order].transform.position.y, baskets[order].transform.position.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton19) || Input.GetKeyDown(KeyCode.JoystickButton15))
        {
            baskets[order].SetActive(false);

            if (order == 2)
            {
                order = 0;
                baskets[order].transform.position = new Vector3(baskets[order+2].transform.position.x, baskets[order+2].transform.position.y, baskets[order+2].transform.position.z);
            }
            else
            {
                order++;
                baskets[order].transform.position = new Vector3(baskets[order-1].transform.position.x, baskets[order-1].transform.position.y, baskets[order-1].transform.position.z);
            }

            baskets[order].SetActive(true);
        }
    }
}
