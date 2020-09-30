using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] List<ObjectScript> _itemsInInventory = new List<ObjectScript>();

    Image _backgroundTint;

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
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
        
    }
    #endregion

    #region Custom Functions

    public void SpawnItem(int itemNumber)
    {
        var spawnPoint = GameObject.Find("ObjectSpawnPoint").transform.position;
        var spawnedObject = Instantiate(_itemsInInventory[itemNumber].prefab);

        spawnedObject.transform.position = spawnPoint;
    }

    public void ToggleShowHide()
    {
        _backgroundTint.enabled = !_backgroundTint.enabled;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.active = 
                !transform.GetChild(i).gameObject.active;
        }
    }

    public void AddItemToInventory(ObjectScript ObjectToAdd)
    {
        _itemsInInventory.Add(ObjectToAdd);
    }

    public void RemoveItemFromInventory(ObjectScript ObjectToRemove)
    {
        _itemsInInventory.Remove(ObjectToRemove);
    }

    #endregion
}
