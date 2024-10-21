using System;
using System.Collections;
using Features.OrderedEvents;
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

    [Serializable]
    public class GameRootData
    {
        
    }
}
