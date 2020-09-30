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
        TouchInput();
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
                    if(Input.GetTouch(i).phase == TouchPhase.Began)
                        _firstLeftTapPos = Input.GetTouch(i).position;
                    _setLeftTouch = true;
                }

                if (CheckScreenSideOfInput(i) == 1 && !_setRightTouch && i != _leftTouchNumber)
                {
                    _rightTouchNumber = i;
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                        _firstRightTapPos = Input.GetTouch(i).position;
                    _setRightTouch = true;
                }
            }

            if(_setLeftTouch == true)
            {
                if(Input.GetTouch(_leftTouchNumber).phase == TouchPhase.Ended)
                {
                    _setRightTouch = false;
                    _setLeftTouch = false;
                    return;
                }

                Vector2 Distance = _firstLeftTapPos - Input.GetTouch(_leftTouchNumber).position;
                Distance = Distance.normalized * _moveSpeed;

                //if outside of deadzone
                if(Distance.sqrMagnitude > 0.2f)
                    _playerControllerReference.Move(Distance);
            }
            else
                _leftTouchNumber = -1;
            

            if(_setRightTouch == true)
            {

                if (Input.GetTouch(_rightTouchNumber).phase == TouchPhase.Ended)
                {
                    _setLeftTouch = false;
                    _setRightTouch = false;
                    return;
                }

                Vector2 Distance = _firstRightTapPos - Input.GetTouch(_rightTouchNumber).position;

                //deadzone
                if (Distance.magnitude > 10)
                {
                    Distance = Distance.normalized * _lookSpeed;

                    if (Distance.sqrMagnitude > 0.2f)
                        _playerControllerReference.Look(Distance);
                }
            }
            else
                _rightTouchNumber = -1;
            

        }
        else
        {
            _setRightTouch = false;
            _setLeftTouch = false;
            _leftTouchNumber = -1;
            _rightTouchNumber = -1;
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
