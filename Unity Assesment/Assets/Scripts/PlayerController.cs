using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;

    Transform _playerCameraTransform;

    bool isHoldingObject;

    bool canWalk = true;

    float yRotation;
    float xRotation;


    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerCameraTransform = transform.GetComponentInChildren<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        ClampCamera();
    }
    #endregion

    #region Custom Functions

    public void Move(Vector2 direction)
    {
        if (!canWalk) return;

        _rigidbody.velocity = (transform.forward * -direction.y) + (transform.right * -direction.x);
    }

    public void Look(Vector2 direction)
    {

        if (!canWalk) return;
        yRotation += direction.y;
        xRotation += -direction.x;

        _rigidbody.rotation = Quaternion.Euler(0, xRotation, 0);

       _playerCameraTransform.localRotation = Quaternion.Euler(yRotation, 0, 0);
    }

    void ClampCamera()
    {

    }

    public bool CheckIfHoldingObject()
    {
        return isHoldingObject;
    }

    public void SetIsHoldingObjectBool(bool state)
    {
        isHoldingObject = state;
    }

    public void SetCanWalkBool(bool state)
    {
        canWalk = state;
    }

    #endregion
}
