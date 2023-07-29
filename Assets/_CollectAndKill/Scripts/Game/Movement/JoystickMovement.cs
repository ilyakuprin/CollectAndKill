using UnityEngine;

namespace CollectAndKill
{
    public class JoystickMovement : JoystickHandler
    {
        public Vector3 ToMove()
        {
            if (GetInputVector.x != 0 || GetInputVector.y != 0)
            {
                return new Vector3(GetInputVector.x, 0, GetInputVector.y);
            }
            else
            {
                return Vector3.zero;
            }
        }
    }
}