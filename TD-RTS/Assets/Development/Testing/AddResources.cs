using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddResources : MonoBehaviour {

    public int resourcesProduced = 5;
    public int timeBetween = 10;
    private float countdown;

    void Start()
    {
        countdown = timeBetween;
    }

    void Update()
    {
        if (countdown >= 10)
        {
            PlayerStats.Money += resourcesProduced;
            countdown = 0;
        }
        countdown += Time.deltaTime;
    }

}
