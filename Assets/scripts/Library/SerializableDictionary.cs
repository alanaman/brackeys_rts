using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [Serializable]
    public class PairClass : SerializablePair<TKey, TValue> { }
    [SerializeField]
    private List<PairClass> keys = new List<PairClass>();

    //[SerializeField]
    //private List<TValue> values = new List<TValue>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        keys.Clear();
        //values.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            PairClass pairClass = new PairClass();
            pairClass.First = pair.Key;
            pairClass.Second = pair.Value;
            keys.Add(pairClass);
            //values.Add(pair.Value);
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        this.Clear();

        //if (keys.Count != values.Count)
        //    throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

        for (int i = 0; i < keys.Count; i++)
        {
            if(!this.ContainsKey(keys[i].First))
            {
                this.Add(keys[i].First, keys[i].Second);
            }
            else
            {
                this.Add(keys[i].First, keys[i].Second);
            }
        }
    }
}