using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daybrayk
{
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 vector, int value)
        {
            vector.x = value;
            return vector;
        }

        public static Vector3 WithY(this Vector3 vector, int value)
        {
            vector.y = value;
            return vector;
        }

        public static Vector3 WithZ(this Vector3 vector, int value)
        {
            vector.z = value;
            return vector;
        }
    }
}
