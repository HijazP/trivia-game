using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject[] teks;
    private bool isDialog = false;

    void Update()
    {
        if (isDialog)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton19) || Input.GetKeyDown(KeyCode.JoystickButton15))
            {
                for (int i = 0; i < teks.Length; i++)
                {
                    teks[i].SetActive(false);
                }
                TopDownCharacterController.instance.ChangeStatusOn();
                isDialog = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colid)
    {
        if (colid.gameObject.CompareTag("Player1"))
        {
            TopDownCharacterController.instance.ChangeStatus();
            teks[0].SetActive(true);
            isDialog = true;
        }
        else if (colid.gameObject.CompareTag("Player2"))
        {
            TopDownCharacterController.instance.ChangeStatus();
            teks[1].SetActive(true);
            isDialog = true;
        }
        else if (colid.gameObject.CompareTag("Player3"))
        {
            TopDownCharacterController.instance.ChangeStatus();
            teks[2].SetActive(true);
            isDialog = true;
        }
        else if (colid.gameObject.CompareTag("Player4"))
        {
            TopDownCharacterController.instance.ChangeStatus();
            teks[3].SetActive(true);
            isDialog = true;
        }
        else if (colid.gameObject.CompareTag("Player5"))
        {
            TopDownCharacterController.instance.ChangeStatus();
            teks[4].SetActive(true);
            isDialog = true;
        }
    }
}
