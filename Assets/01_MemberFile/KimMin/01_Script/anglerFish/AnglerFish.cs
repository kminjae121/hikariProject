using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFish : AnglerFishMovement
{
    public Transform targetTrm;

    private AnglerFishEnum _currentStateEnum;
    private Dictionary<AnglerFishEnum, AnglerFishState> _stateDictionay
        = new Dictionary<AnglerFishEnum, AnglerFishState>();

    private void Awake()
    {
        foreach (AnglerFishEnum anglerFishEnum in Enum.GetValues(typeof(AnglerFishEnum)))
        {
            string enumName = anglerFishEnum.ToString();
            Type t = Type.GetType($"AnglerFish{enumName}State");
            AnglerFishState state = Activator.CreateInstance(t) as AnglerFishState;
            _stateDictionay.Add(anglerFishEnum, state);
        }

        ChangeState(AnglerFishEnum.Move);
    }

    private void Update()
    {
        _stateDictionay[_currentStateEnum].UpdateState();
    }

    public void ChangeState(AnglerFishEnum newStateEnum)
    {
        if (_currentStateEnum != null)
            _stateDictionay[_currentStateEnum].Exit();
        _currentStateEnum = newStateEnum;
        _stateDictionay[_currentStateEnum].Enter();

    }
}
