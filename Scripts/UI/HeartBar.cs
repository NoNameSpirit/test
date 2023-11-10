using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarTotal;
    [SerializeField] private Image _healthBarCurrent;
    [SerializeField] private CharacterHealth _playerHealth;

    private void Start()
    {
        _healthBarTotal.fillAmount = _playerHealth.CurrentHealth / 10;
    }
    private void Update()
    {
        _healthBarCurrent.fillAmount = _playerHealth.CurrentHealth / 10;
    }
}
