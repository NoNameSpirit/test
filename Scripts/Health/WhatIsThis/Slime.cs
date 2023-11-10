using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOnHit : MonoBehaviour
{
    public float Health 
    {
        set
        {
            _health  = value;
            if(_health < 0 )
                Destroy(gameObject);
        }
        get
        {
            return _health;
        }
    }

    public float _health = 3;
    void OnHit(float damage)
    { 
        Health -= damage;
    }
}
