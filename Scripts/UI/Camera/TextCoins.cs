using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextCoins : MonoBehaviour
{
    public static int Coin;
    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        Coin = PlayerPrefs.GetInt("coin", Coin);
    }

    void Update()
    {
        _text.text = Coin.ToString();
    }
}
