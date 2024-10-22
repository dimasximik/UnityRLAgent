using System.Collections.Generic;
using UnityEngine;

public class QLearning
{
    private Dictionary<string, Dictionary<string, float>> _qTable;
    private List<string> _actions;

    public QLearning()
    {
        _qTable = new Dictionary<string, Dictionary<string, float>>();
        _actions = new List<string> { "MoveForward", "MoveBackward", "MoveLeft", "MoveRight", "RotateLeft", "RotateRight" };
    }

    public string ChooseAction(string state, float explorationRate)
    {
        if (!_qTable.ContainsKey(state))
        {
            _qTable[state] = new Dictionary<string, float>();
            foreach (var action in _actions)
            {
                _qTable[state][action] = 0.0f;
            }
        }

        if (Random.value < explorationRate)
        {
            return _actions[Random.Range(0, _actions.Count)];
        }
        else
        {
            float maxQ = float.MinValue;
            string bestAction = _actions[0];
            foreach (var action in _actions)
            {
                if (_qTable[state][action] > maxQ)
                {
                    maxQ = _qTable[state][action];
                    bestAction = action;
                }
            }
            return bestAction;
        }
    }
    
    public void UpdateQ(string state, string action, float reward, string newState, float learningRate, float discountFactor)
    {
        if (!_qTable.ContainsKey(newState))
        {
            _qTable[newState] = new Dictionary<string, float>();
            foreach (var act in _actions)
            {
                _qTable[newState][act] = 0.0f;
            }
        }

       
        float maxQNewState = float.MinValue;
        foreach (var act in _actions)
        {
            if (_qTable[newState][act] > maxQNewState)
            {
                maxQNewState = _qTable[newState][act];
            }
        }

        _qTable[state][action] += learningRate * (reward + discountFactor * maxQNewState - _qTable[state][action]);
    }
}
