using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public void OnCastleDestroyed()
    {
        GameManager.I.OnCastleDestroyed();
    }
}
