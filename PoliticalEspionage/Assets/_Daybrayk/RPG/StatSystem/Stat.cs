using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daybrayk.rpg
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField]
        float _baseValue = 0;
        public float baseValue { get { return _baseValue; } }

        float _value;
        public float value { get { if (isDirty) UpdateValue(); return _value; } }

        bool isDirty;

        List<StatModifier> modifiers = new List<StatModifier>();

        public bool AddModifier(StatModifier mod)
        {
            if (ContainsModifier(mod.source)) return false;
            modifiers.Add(mod);
            isDirty = true;

            return true;
        }

        public bool RemoveModifier(object obj)
        {
            for(int i = 0; i < modifiers.Count; i++)
            {
                if (modifiers[i].source == obj)
                {
                    modifiers.RemoveAt(i);
                    isDirty = true;
                    return true;
                }
            }
            
            return false;
        }

        public void RemoveAllModifiers()
        {
            modifiers.Clear();
            isDirty = true;
        }

        public bool ContainsModifier(object obj)
        {
            for(int i = 0; i < modifiers.Count; i++)
            {
                if (modifiers[i].source == obj) return true;
            }

            return false;
        }

        private void UpdateValue()
        {
            float total = baseValue;
            float flatTotal = 0;
            float addTotal = 0;
            float mulTotal = 0;
            int currentOrderValue = 0;

            IEnumerable<StatModifier> mods = modifiers.OrderBy(x => x.order);

            Debug.Log(mods.Count());

            for(int i = 0; i <= mods.Count(); i++)
            {
                StatModifier current =  i < mods.Count() ? mods.ElementAt(i) : null;

                if (i >= mods.Count())
                {
                    Debug.Log("Add Total: " + addTotal);
                    total *= (1 + addTotal);
                    total += mulTotal;
                    total += flatTotal;
                    addTotal = 0;
                    mulTotal = 0;
                    flatTotal = 0;
                    //currentOrderValue = current.order;
                }
                else if(currentOrderValue != current.order)
                {
                    Debug.Log("Add Total: " + addTotal);
                    total *= (1 + addTotal);
                    total += mulTotal;
                    total += flatTotal;
                    addTotal = 0;
                    mulTotal = 0;
                    flatTotal = 0;
                    currentOrderValue = current.order;
                }
                else
                {
                    switch (current.modType)
                    {
                        case StatModifier.ModType.Flat:
                            Debug.Log("Flat ModType: " + current.value);
                            flatTotal += current.value;
                            break;
                        case StatModifier.ModType.PercentAdd:
                            Debug.Log("Percent Add ModType: " + current.value);
                            addTotal += current.value/100;
                            break;
                        case StatModifier.ModType.PercentMul:
                            Debug.Log("Percent Multiply ModType: " + current.value);
                            mulTotal = ((mulTotal + total) * (1 + current.value/100)) - total;
                            break;
                    }
                }

                //switch (current.modType)
                //{
                //    case StatModifier.ModType.Flat:
                //        Debug.Log("Flat ModType: " + current.value);
                //        flatTotal += current.value;
                //        break;
                //    case StatModifier.ModType.PercentAdd:
                //        Debug.Log("Percent Add ModType: " + current.value);
                //        addTotal += current.value;
                //        break;
                //    case StatModifier.ModType.PercentMul:
                //        Debug.Log("Percent Multiply ModType: " + current.value);
                //        mulTotal = ((mulTotal + total) * (1+current.value)) - total;
                //        break;
                //}

                //if (i + 1 >= mods.Count())
                //{
                //    Debug.Log("Add Total: " + addTotal);
                //    total *= (1+addTotal);
                //    total += mulTotal;
                //    total += flatTotal;
                //    addTotal = 0;
                //    mulTotal = 0;
                //    flatTotal = 0;
                //}


            }
            Debug.LogError("End of Loop Iteration");
            Debug.Log("Value: " + total);
            _value = total;
            isDirty = false;
        }
    }
}
