using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] float _lookSpeed = 3;
    [SerializeField] float _moveSpeed = 3;

    bool _setLeftTouch,
         _setRightTouch;

    int _leftTouchNumber = -1,
        _rightTouchNumber = -1;

    Vector2 _firstLeftTapPos,
            _firstRightTapPos;

    PlayerController _playerControllerReference;

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        _playerControllerReference = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Custom Functions

    void TouchInput()
    {
        if(Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if(CheckScreenSideOfInput(i) == -1 && !_setLeftTouch && i != _rightTouchNumber)
                {
                    _leftTouchNumber = i;
                    _firstLeftTapPos = Input.GetTouch(i).position;
                    _setLeftTouch = true;
                }

                if (CheckScreenSideOfInput(i) == 1 && !_setRightTouch && i != _leftTouchNumber)
                {
                    _rightTouchNumber = i;
                    _firstRightTapPos = Input.GetTouch(i).position;
                    _setLeftTouch = true;
                }
            }

            if(_setLeftTouch == true)
            {
                if(Input.GetTouch(_leftTouchNumber).phase == TouchPhase.Ended)
                {
                    _leftTouchNumber = -1;
                    _setLeftTouch = false;
                }

                Vector2 Distance = _firstLeftTapPos - Input.GetTouch(_leftTouchNumber).position;
                Distance = Distance * _moveSpeed;

                _playerControllerReference.Move(Distance);
            }

            if(_setRightTouch == true)
            {
                if (Input.GetTouch(_rightTouchNumber).phase == TouchPhase.Ended)
                {
                    _rightTouchNumber = -1;
                    _setRightTouch = false;
                }

                Vector2 Distance = _firstRightTapPos - Input.GetTouch(_rightTouchNumber).position;

                Distance = Distance.normalized * _lookSpeed;

                _playerControllerReference.Look(Distance);
            }
            
        }
    }

    private int CheckScreenSideOfInput(int InputNumber)
    {
        if (Input.GetTouch(InputNumber).position.x < Screen.width / 2)
            return -1;
        else if (Input.GetTouch(InputNumber).position.x > Screen.width / 2)
            return 1;
        else
            return 0;
        
    }

    #endregion
}
