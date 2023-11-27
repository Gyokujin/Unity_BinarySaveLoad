using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UserPrefs.Save("Coin", 34);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var currentCoin = UserPrefs.Load("Coin", -1);
            Debug.Log(currentCoin);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Application.OpenURL(Application.persistentDataPath);
        }
    }
}