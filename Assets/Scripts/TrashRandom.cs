using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRandom : MonoBehaviour
{
    public GameObject[] trashes;
    private float startTime = 3f;
    private float cdTime;

    void Start()
    {
        cdTime = startTime;
    }
}
