using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    private void OnDestroy()
    {
        GameManager.I.OnCastleDestroyed();
    }
}
