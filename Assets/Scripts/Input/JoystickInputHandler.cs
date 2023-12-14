using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInputHandler : InputHandler
{
    public Joystick CurrentJoystick;

    private void Update()
    {
        Direction = CurrentJoystick.Direction;
    }
}
