using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorToggle : MonoBehaviour
{

    public enum State { OPEN, CLOSED };

    public State currentState;

    Transform _doorHingeTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.CLOSED;
        _doorHingeTransform = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateDoor();
    }

    void AnimateDoor()
    {
        if(currentState == State.OPEN)
        {
            if(_doorHingeTransform.eulerAngles.y < 90)
            {
                _doorHingeTransform.Rotate(0, 3, 0);
            }
        }
        else
        {
            if (_doorHingeTransform.eulerAngles.y > 1)
            {
                _doorHingeTransform.Rotate(0, -3, 0);
            }
        }
    }

    
}
