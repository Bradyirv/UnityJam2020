using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Daybrayk.Properties
{
    [CustomPropertyDrawer(typeof(IntReference))]
    public class IntReferenceDrawer : VariableReferenceDrawerBase { }
}
