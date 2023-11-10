using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class InventoryOpen : MonoBehaviour
{
    [SerializeField] private GameObject GameObjectInventory;
    
    private bool IsOpened = false;

    void Start()
    {
        GameObjectInventory.SetActive(false);
    }

    void Update()
    {
        CheckPressKey();
    }

    void CheckPressKey()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!IsOpened)
                OpenInventory();
            else if (IsOpened)
                CloseInventory();
        }
    }
    void OpenInventory()
    {
        GameObjectInventory.SetActive(true);
        IsOpened = true;
    }

    void CloseInventory() 
    {
        GameObjectInventory.SetActive(false);
        IsOpened = false;
    }
}
