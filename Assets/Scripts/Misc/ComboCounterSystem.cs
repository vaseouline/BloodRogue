using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounterSystem : MonoBehaviour
{
    public int comboCounter;
    public float timeLeft;
    public float comboResetTimer;

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft == 0)
        {
            comboCounter = 0;
        }
    }

    public void increaseCounter() {
        comboCounter +=1;
        timeLeft = comboResetTimer;
        // Works for now probably
        switch(comboCounter)
        {
        case 1:
            print ("Nice!");
            break;
        case 5:
            print ("Good job!");
            break;
        case 10:
            print ("Wow!");
            break;
        case 15:
            print ("Keep it up");
            break;
        case 30:
            print ("So cool");
            break;
        case 50:
            print ("Get a life.");
            break;
    }
}
