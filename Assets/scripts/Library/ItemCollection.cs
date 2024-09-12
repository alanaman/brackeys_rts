using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.InputSystem;

[Serializable]
public class ItemCollection : ISerializationCallbackReceiver
{
    [Serializable]
    public class TypeAmountPair : SerializablePair<Inventory.ResourceType, int> { }

    [SerializeField]
    List<TypeAmountPair> sList;

    [SerializeField]
    public Dictionary<Inventory.ResourceType, int> items = new Dictionary<Inventory.ResourceType, int>();
    public void OnBeforeSerialize()
    {
        if(sList == null)
        {
            sList = new List<TypeAmountPair>();
        }
        else
        {
            sList.Clear();
        }
        //values.Clear();
        foreach (KeyValuePair<Inventory.ResourceType, int> pair in items)
        {
            TypeAmountPair pairClass = new TypeAmountPair();
            pairClass.First = pair.Key;
            pairClass.Second = pair.Value;
            sList.Add(pairClass);
            //values.Add(pair.Value);
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        items.Clear();

        //if (keys.Count != values.Count)
        //    throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

        for (int i = 0; i < sList.Count; i++)
        {
            if (!items.ContainsKey(sList[i].First))
            {
                items.Add(sList[i].First, sList[i].Second);
            }
            else
            {
                foreach(Inventory.ResourceType type in Enum.GetValues(typeof(Inventory.ResourceType)))
                {
                    if (!items.ContainsKey(type))
                    {
                        items.Add(type, 0);
                        break;
                    }
                }
            }
        }
    }


}
