using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
using UnityEngine;

[Serializable]
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver
{

    [SerializeField]
    private List<T> items = new List<T>();

    //[SerializeField]
    //private List<TValue> values = new List<TValue>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        items.Clear();
        //values.Clear();
        foreach (T item in this)
        {
            items.Add(item);
            //values.Add(pair.Value);
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        this.Clear();

        //if (keys.Count != values.Count)
        //    throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

        for (int i = 0; i < items.Count; i++)
        {
            if (!this.Contains(items[i]))
            {
                this.Add(items[i]);
            }
        }
    }
}