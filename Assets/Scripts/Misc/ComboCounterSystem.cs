using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounterSystem : MonoBehaviour
{
    public static int comboCounter = 0;
    public static float timeLeft = 0;
    public static float comboResetTimer = 5;

    void Update()
    {
        //Debug.Log(timeLeft);
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            comboCounter = 0;
            UI.Instance.updateCombo(comboCounter);

        }
    }

    public static void increaseCounter() {
        comboCounter +=1;
        UI.Instance.updateCombo(comboCounter);
        timeLeft = comboResetTimer;
        // Works for now probably
        switch(comboCounter)
        {
        case 1:
            Debug.Log("Nice!");
            break;
        case 5:
            Debug.Log("Good job!");
            break;
        case 10:
            Debug.Log("Wow!");
            break;
        case 15:
            Debug.Log("Keep it up");
            break;
        case 30:
            Debug.Log("So cool");
            break;
        case 50:
            Debug.Log("Get a life.");
            break;
        }

        //Debug.Log(comboCounter);
    }
}
