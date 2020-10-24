using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Daybrayk.Properties
{
    [CustomPropertyDrawer(typeof(StringReference))]
    public class StringReferenceDrawer : VariableReferenceDrawerBase { }
}
