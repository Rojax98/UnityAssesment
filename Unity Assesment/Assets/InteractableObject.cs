using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    int _tapCount;
    bool _startTimer;

    float _timer;

    PlayerController _playerControllerReference;
    PlayerInventory _playerInventoryReference;

    [SerializeField] ObjectScript InventoryObj;

    #region unity Functions
    // Start is called before the first frame update
    void Start()
    {
        _playerControllerReference = GameObject.FindObjectOfType<PlayerController>();
        _playerInventoryReference = GameObject.FindObjectOfType<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_startTimer && _timer < 0.2f)
            _timer += 1 * Time.deltaTime;
        else if(_tapCount != 0)
            CheckInteraction();
    }
    #endregion

    #region Custom Functions

    private void OnMouseDown()
    {
        _tapCount += 1;
        _startTimer = true;
    }

    private void CheckInteraction()
    {
        var spawnPoint = GameObject.Find("ObjectSpawnPoint").transform.position;

        if (_playerControllerReference.CheckIfHoldingObject() == false) {
            if (_tapCount < 2) {
                transform.position = spawnPoint;
                GetComponent<Rigidbody>().isKinematic = true;
                _playerControllerReference.SetIsHoldingObjectBool(true);
                transform.parent = GameObject.Find("Player").transform;
            }
            else 
            {
                _playerInventoryReference.AddItemToInventory(InventoryObj);
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.parent)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                _playerControllerReference.SetIsHoldingObjectBool(false);
                transform.parent = null;
            }
        }

        _startTimer = false;
        _timer = 0;
        _tapCount = 0;
    }

    #endregion
}
