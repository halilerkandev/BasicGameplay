using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerState State;
    public static PlayerManager Instance;

    public static event Action<PlayerState> OnPlayerStateChanged;

    public void IncreaseScore() => Dispatch<Unit>(new(Type: PlayerActionType.IncreaseScore, Payload: new()));
    public void DecreaseLives() => Dispatch<Unit>(new(Type: PlayerActionType.DecreaseLives, Payload: new()));

    private void Awake()
    {
        Instance = this;
        State = new PlayerState { Lives = 3, Score = 0, IsGameOver = false };
    }

    private void Start()
    {
        Debug.Log("Lives = " + State.Lives);
        Debug.Log("Score = " + State.Score);
    }

    private void Dispatch<T>(PlayerAction<T> action)
    {
        switch (action.Type)
        {
            case PlayerActionType.IncreaseScore:
                HandleIncreaseScore();
                break;
            case PlayerActionType.DecreaseLives:
                HandleDecreaseLives();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }
        OnPlayerStateChanged?.Invoke(State);
    }

    private void HandleIncreaseScore()
    {
        State = State with { Score = State.Score + 1 };

    }

    private void HandleDecreaseLives()
    {
        if (State.Lives > 0)
            State = State with { Lives = State.Lives - 1 };
        if (State.Lives == 0 && !State.IsGameOver)
            State = State with { IsGameOver = true };
    }
}

interface IPlayerAction
{
    PlayerActionType Type { get; }
}

interface IPlayerAction<T> : IPlayerAction where T : notnull
{
    T Payload { get; }
}

class PlayerAction<T> : IPlayerAction<T>
{
    public PlayerActionType Type { get; }
    public T Payload { get; }

    public PlayerAction(PlayerActionType Type, T Payload)
    {
        this.Type = Type;
        this.Payload = Payload;
    }
}

enum PlayerActionType
{
    IncreaseScore,
    DecreaseLives
}

public record PlayerState
{
    public int Lives { get; set; }
    public int Score { get; set; }
    public bool IsGameOver { get; set; }
};

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}

public class Unit { }