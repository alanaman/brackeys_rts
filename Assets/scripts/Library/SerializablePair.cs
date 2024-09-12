using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializablePair<TKey, TValue> : Pair<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private TKey key;

    [SerializeField]
    private TValue value;

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        //keys.Clear();
        //values.Clear();
        //foreach (KeyValuePair<TKey, TValue> pair in this)
        //{
        //    keys.Add(KeyValuePair.Create(pair.Key, pair.Value));
        //    //values.Add(pair.Value);
        //}

        key = this.First;
        value = this.Second;
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        //this.Clear();

        //if (keys.Count != values.Count)
        //    throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

        //for (int i = 0; i < keys.Count; i++)
        //    this.Add(keys[i].Key, keys[i].Value);
        this.First = key;
        this.Second = value;
    }
}
