using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] List<ObjectScript> _itemsInInventory = new List<ObjectScript>();

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

    #endregion
}
