using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    [SerializeField] private GameObject _ñharacter;
    private Transform _player;

    void Start()
    {
        _player = _ñharacter.transform;
    }
    
    void Update()
    {
        Vector3 temp = transform.position; 
        temp.x = _player.position.x;
        temp.y = _player.position.y;

        transform.position = temp;
    }
}
