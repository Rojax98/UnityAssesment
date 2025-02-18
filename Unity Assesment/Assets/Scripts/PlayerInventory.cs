﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] List<ObjectScript> _itemsInInventory = new List<ObjectScript>();

    Image _backgroundTint;

    PlayerController _playerControllerReference;

    bool _isActive = false;

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        _playerControllerReference = GameObject.FindObjectOfType<PlayerController>();

        if(_itemsInInventory.Count > 0)
        {
            for (int i = 0; i < _itemsInInventory.Count; i++)
            {
                transform.GetChild(i).GetChild(0).GetComponent<Text>().text 
                    = _itemsInInventory[i].objectName;
            }
        }

        _backgroundTint = GameObject.Find("background").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
            UpdateUI();
        else
            hideUI();
    }
    #endregion

    #region Custom Functions

    void UpdateUI()
    {

        if (_itemsInInventory.Count > 0)
        {
            for (int i = 0; i < _itemsInInventory.Count; i++)
            {
                transform.GetChild(i).GetChild(0).GetComponent<Text>().text
                    = _itemsInInventory[i].objectName;
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i >= _itemsInInventory.Count)
            {
                transform.GetChild(i).gameObject.active = false;
            }
            else
            {
                transform.GetChild(i).gameObject.active = true;
            }
        }
    }

    void hideUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.active = false;
        }
    }

    public void SpawnItem(int itemNumber)
    {
        var spawnPoint = GameObject.Find("ObjectSpawnPoint").transform.position;
        var spawnedObject = Instantiate(_itemsInInventory[itemNumber].prefab);

        RemoveItemFromInventory(_itemsInInventory[itemNumber]);

        spawnedObject.transform.position = spawnPoint;
    }

    public void ToggleShowHide()
    {

        _backgroundTint.enabled = !_backgroundTint.enabled;

        _isActive = !_isActive;

        _playerControllerReference.SetCanWalkBool(!_isActive);

       
    }

    public bool CheckIfActive()
    {
        return _isActive;
    }

    public void AddItemToInventory(ObjectScript ObjectToAdd)
    {
        _itemsInInventory.Add(ObjectToAdd);
    }

    public void RemoveItemFromInventory(ObjectScript ObjectToRemove)
    {
        _itemsInInventory.Remove(ObjectToRemove);
    }

    public int CheckInventoryCount()
    {
        return _itemsInInventory.Count;
    }

    #endregion
}
