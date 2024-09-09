using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    public Player Player { get { return player; } private set { player = value; } }
    [SerializeField] private Player player;

    public Collider PlayerCollider { get { return playerCollider; } private set { playerCollider = value; } }
    [SerializeField] private Collider playerCollider;



    public float timer = 0;

    public float timeScale = 1f;

    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(this);
            return;
        }

        I = this;

        Time.timeScale = timeScale;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Time.timeScale = Mathf.Lerp(Time.timeScale, timeScale, 0.1f);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public static bool TryGetPlayer(out Player player)
    {
        player = I.Player;
        return player != null;
    }
    //public static bool TryGetPlayerCollider(out Collider playerCollider)
    //{
    //    playerCollider = I.playerCollider;
    //    return playerCollider != null;
    //}

}
