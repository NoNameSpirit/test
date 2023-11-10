using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Transparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite; // —юда в инспекторе нужно перетащить спрайт

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            var color = _sprite.color;
            color.a /=  1.3f; 
            _sprite.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            var color = _sprite.color;
            color.a *= 1.3f;
            _sprite.color = color;
        }
    }
}
