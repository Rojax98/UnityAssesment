using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorToggle : MonoBehaviour
{

    enum State { OPEN, CLOSED };

    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.CLOSED;
    }

    // Update is called once per frame
    void Update()
    {
        checkIfTouched();
    }

    void checkIfTouched()
    {
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                if (currentState == State.CLOSED)
                    currentState = State.OPEN;
                else
                    currentState = State.CLOSED;

            }
        }
    }
}
