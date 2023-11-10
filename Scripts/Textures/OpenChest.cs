using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OpenChest : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _E;
    [SerializeField] private GameObject _chestObject;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _coinPrefab2;

    private float X;
    private float Y;
    private float Z;

    private bool _inZone = false;
    private bool _isOpened = false;
    private Animator _animator;
    private SpriteRenderer _changeSprite;

    //GameObject GO = Instantiate(CoinPrefab, new Vector3(1, 1 , -1), Quaternion.identity) as GameObject; // StartCoroutine(Upd());

    private void Start()
    {
        _changeSprite = GetComponent<SpriteRenderer>();
        _E.SetActive(false);
    }

    private void Update()
    {
        CheckIsOpenedOrNot();
    }
    private void CheckIsOpenedOrNot()
    {
        if (_inZone && Input.GetKey(KeyCode.E))
        {
            _changeSprite.sprite = _sprite;
            _isOpened = true;
            DestroyPlusSpawnCoins();
             /* как сделать дабы через опред. промежуток времени
             * т.к. при помощи Invoke(nameof(DestroyPlusSpawnCoins), 2) - вызывается не 3 коина
             * а больше чем надо? Из-за update происходит?
             */ 
        }
    }

    private void DestroyPlusSpawnCoins()
    {
       // if (_inZone && Input.GetKey(KeyCode.E))
       // {
            X = _chestObject.transform.position.x;
            Y = _chestObject.transform.position.y;
            Z = _chestObject.transform.position.z;

            Destroy(_chestObject);
            int ChoicesForSpawnCoins = Random.Range(0, 3);
            switch (ChoicesForSpawnCoins)
            {
                case 0:
                    FirstChoiceForSpawnCoins();
                    break;
                case 1:
                    SecondChoiceForSpawnCoins();
                    break;
                case 2:
                    ThirdChoiceForSpawnCoins();
                    break;
            }
            
       // }
    }

    private void FirstChoiceForSpawnCoins()
    {
        GameObject[] CPrefabs = new GameObject[2] { _coinPrefab, _coinPrefab2 };

        for (float i = 0.0f; i < 1.5f; i += 0.5f)
        {
            int k = Random.Range(0, 2);

            if (i == 0.5f)
                Y -= i;
            Instantiate(CPrefabs[k], new Vector3(X + i, Y, Z), Quaternion.identity);
            if (i == 0.5f)
                Y += i;
        }
    }

    private void SecondChoiceForSpawnCoins()
    {
        GameObject[] CPrefabs = new GameObject[2] { _coinPrefab, _coinPrefab2 };

        for (float i = 0.0f; i < 1.5f; i += 0.5f)
        {
            int k = Random.Range(0, 2);

            if (i == 1)
                Y -= i;
            Instantiate(CPrefabs[k], new Vector3(X + i, Y, Z), Quaternion.identity);
        }
    }

    private void ThirdChoiceForSpawnCoins()
    {
        GameObject[] CPrefabs = new GameObject[2] { _coinPrefab, _coinPrefab2 };

        for (float i = 0.0f; i < 1.5f; i += 0.5f)
        {
            int k = Random.Range(0, 2);

            if (i == 1)
            { 
                Y += i;
                X += i;
            }
            Instantiate(CPrefabs[k], new Vector3(X , Y - i , Z), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (!_isOpened)
            {
                _E.SetActive(true);
                _inZone = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(_isOpened)
        {
            _E.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _E.SetActive(false);
            _inZone = false;
        }
    }       
   /*private void IsOpened()
   {
        if (_inZone && Input.GetKey(KeyCode.E))
   {
            _changeSprite.sprite = _sprite;
            _isOpened = true;
        }

   }*/

        }

// 




/* private IEnumerator Upd()
 {
     while (true)
     {
         yield return null;
         CheckIsOpenedOrNot();
     }
 }
 

//          GameObject GO = Instantiate(CPrefabs[k], new Vector3(X + i, Y, Z), Quaternion.identity) as GameObject;
*/