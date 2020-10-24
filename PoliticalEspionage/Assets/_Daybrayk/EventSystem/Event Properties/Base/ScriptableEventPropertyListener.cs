﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Daybrayk
{
    public abstract class ScriptableEventPropertyListener<T, TEvent> : MonoBehaviour, IScriptableEventListener where TEvent : UnityEvent<T>, new()
    {
        public TEvent onPropertyChanged;

        [SerializeField]
        ScriptableEvent _scriptableProperty;

        public ScriptableEvent scriptableProperty
        {
            get { return _scriptableProperty; }

            set
            {
                if (scriptableProperty) scriptableProperty.RemoveListener(this);
                _scriptableProperty = value;
                if (scriptableProperty) scriptableProperty.AddListener(this);
            }
        }

        public void Raise()
        {
            OnEventRaised(scriptableProperty);
        }

        public void OnEventRaised(Object raiser)
        {
            if(onPropertyChanged != null) onPropertyChanged.Invoke((raiser as ScriptableEventProperty<T>).Value);
        }

        private void OnEnable()
        {
            scriptableProperty.AddListener(this);
        }

        private void OnDisable()
        {
            scriptableProperty.RemoveListener(this);   
        }
    }
}
