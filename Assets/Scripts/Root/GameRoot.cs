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
            Destroy(this);
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
#endif

    [Serializable]
    public class GameRootData
    {
        
    }
}