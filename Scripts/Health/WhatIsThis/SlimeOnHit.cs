using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float _health = 3;

    public float Health 
    {
        set
        {
            _health  = value;
            if(_health <= 0 )
                Destroy(gameObject);
        }
        get
        {
            return _health;
        }
    }
    
    void OnHit(float damage)
    { 
        Health -= damage;
    }
}
