using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    public Player Player { get { return player; } private set { player = value; } }
    [SerializeField] private Player player;

    public Collider PlayerCollider { get { return playerCollider; } private set { playerCollider = value; } }
    [SerializeField] private Collider playerCollider;

    HashSet<AllyEntity> allyEntities = new HashSet<AllyEntity>();
    HashSet<EnemyEntity> enemyEntities = new HashSet<EnemyEntity>();

    public float timer = 0;

    public float timeScale = 1f;

    bool paused = false;

    bool isGameOver = false;

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

    }

    public static bool TryGetPlayer(out Player player)
    {
        player = I.Player;
        return player != null;
    }

    public void AddAllyEntity(AllyEntity troop)
    {
        allyEntities.Add(troop);
    }

    public void removeAllyEntity(AllyEntity troop)
    {
        allyEntities.Remove(troop);
    }

    public void AddEnemyEntity(EnemyEntity enemy)
    {
        enemyEntities.Add(enemy);
    }

    public void removeEnemyEntity(EnemyEntity enemy)
    {
        enemyEntities.Remove(enemy);
    }

    public List<AllyEntity> GetAllyEntities()
    {
        return new List<AllyEntity>(allyEntities);
    }

    public List<EnemyEntity> GetEnemyEntities()
    {
        return new List<EnemyEntity>(enemyEntities);
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (paused)
        {
            UiManager.I.HidePausemenu();
            paused = false;
            Time.timeScale = 1;
            GameInput.I.EnableInput();
        }
        else
        {
            GameInput.I.DisableInput();
            UiManager.I.ShowPausemenu();
            paused = true;
            Time.timeScale = 0;
        }
    }

    public void OnContinue()
    {
        UiManager.I.HidePausemenu();
        paused = false;
        Time.timeScale = 1;
    }

    public void OnPlayerDead()
    {
        if(isGameOver)
        {
            return;
        }

        isGameOver = true;
        GameInput.I.DisableInput();
        Time.timeScale = 0;
        UiManager.I.ShowGameOverMenu();
        UiManager.I.SetReasonText("You died!");
    }

    public void OnVictory()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        GameInput.I.DisableInput();
        Time.timeScale = 0;
        UiManager.I.ShowVictoryMenu();
    }

    public void OnCastleDestroyed()
    {
        if(isGameOver)
        {
            return;
        }
        isGameOver = true;
        GameInput.I.DisableInput();
        Time.timeScale = 0;
        UiManager.I.ShowGameOverMenu();
        UiManager.I.SetReasonText("Your castle got destroyed!");
    }
}
