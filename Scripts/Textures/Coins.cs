using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") 
        {
            TextCoins.Coin += 1;
            PlayerPrefs.SetInt("coin", TextCoins.Coin);
            Destroy(gameObject);
        }
    }
}
