using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    PlayerController _playerControllerReference;
    PlayerInventory _playerInventoryReference;

    Text _tutorialText;

    bool step2;

    bool hasPickedUpObject;

    int lastInventoryCount;

    // Start is called before the first frame update
    void Start()
    {
        _playerControllerReference = GameObject.FindObjectOfType<PlayerController>();
        _playerInventoryReference = GameObject.FindObjectOfType<PlayerInventory>();

        _tutorialText = transform.GetChild(0).GetComponent<Text>();
        lastInventoryCount = _playerInventoryReference.CheckInventoryCount();

    }

    // Update is called once per frame
    void Update()
    {
        if (step2 == false)
        {
            if (_playerControllerReference.CheckIfHoldingObject() == false)
            {
                _tutorialText.text = "Tap on object to pick it up";
                if (hasPickedUpObject)
                    step2 = true;
            }
            else if (_playerControllerReference.CheckIfHoldingObject() == true)
            {
                _tutorialText.text = "Tap the object again to drop it";
                hasPickedUpObject = true;
            }
        }
        else
        {
           
            _tutorialText.text = "Double tap an object to place it in your inventory";
            if (_playerInventoryReference.CheckInventoryCount() > lastInventoryCount)
                gameObject.active = false;
            lastInventoryCount = _playerInventoryReference.CheckInventoryCount();
        }
    }
}
