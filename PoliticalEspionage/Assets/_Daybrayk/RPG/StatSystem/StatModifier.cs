using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daybrayk.rpg
{
    [System.Serializable]
    public class StatModifier
    {
        public enum ModType
        {
            Flat,
            PercentAdd,
            PercentMul,
        }

        [SerializeField]
        float _value;
        public float value { get { return _value; } private set { _value = value; } }
        [SerializeField]
        int _order;
        public int order { get { return _order; } private set { _order = value; } }
        [SerializeField]
        ModType _modType;
        public ModType modType { get { return _modType; } private set { _modType = value; } }
        public object source { get; set; }

        public StatModifier(float value, ModType modType, int order, object source)
        {
            this.value = value;
            this.order = order;
            this.modType = modType;
            this.source = source;
        }

        public StatModifier(float value, ModType type) : this(value, type, (int)type, null) { }

        public StatModifier(float value, ModType type, int order) : this(value, type, order, null) { }

        public StatModifier(float value, ModType type, object source) : this(value, type, (int)type, source) { }
    }
}
