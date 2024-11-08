using System;
using System.Collections;
using Features.OrderedEvents;
using NaughtyAttributes;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }
    public GameRootData Data;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    private IEnumerator Start()
    {
        // Initialize game
        GameEvents.OnGameInitialized.Invoke();
        
        yield return null;
        GameEvents.OnGameStart.Invoke();
    }

    private void OnDestroy()
    {
        GameEvents.ResetAll();
    }
    
#if UNITY_EDITOR
    [HorizontalLine(2f,EColor.Blue)]
    [ReadOnly]
    public string _editor = "Editor";
    [Button()]
    public void SendGameStartEvent()
    {
        GameEvents.OnGameStart.Invoke();
    }
    
    [Button()]
    public void SendGameEndEvent()
    {
        GameEvents.OnGameEnd.Invoke();
    }
    
    [Button()]
    public void SendRoundStartEvent()
    {
        GameEvents.OnRoundStart.Invoke();
    }
    
    [Button()]
    public void SendRoundCompleteEvent()
    {
        GameEvents.OnRoundComplete.Invoke();
    }
    
    [Button()]
    public void SendRoundFailEvent()
    {
        GameEvents.OnRoundFail.Invoke();
    }
    
    [Button()]
    public void PrintGameEvents()
    {
        Debug.Log("Game Initialized: " + GameEvents.OnGameInitialized);
        Debug.Log("Game Start: " + GameEvents.OnGameStart);
        Debug.Log("Game End: " + GameEvents.OnGameEnd);
        Debug.Log("Round Start: " + GameEvents.OnRoundStart);
        Debug.Log("Round Complete: " + GameEvents.OnRoundComplete);
        Debug.Log("Round Fail: " + GameEvents.OnRoundFail);
    }
#endif

    [Serializable]
    public class GameRootData
    {
        
    }
}