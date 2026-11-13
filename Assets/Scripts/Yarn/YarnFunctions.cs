using System;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Yarn.Unity;

public class YarnFunctions : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] InMemoryVariableStorage storage;

    [YarnCommand] public void SetMoney()
    {
        storage.SetValue("money", money);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [YarnCommand] public void GetVariable(int num)
    {
        Debug.Log("Variable value: " + num);
    }
    
}
