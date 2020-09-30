using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;

    Transform _playerCameraTransform;

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
        
    }
    #endregion

    #region Custom Functions

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = new Vector3(direction.x, 0, direction.y);
    }

    public void Look(Vector2 direction)
    {
       _playerCameraTransform.Rotate(direction.x, direction.y, 0);
    }

    void ClampCamera()
    {

    }

    #endregion
}
