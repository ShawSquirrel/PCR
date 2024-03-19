using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMono : MonoBehaviour
{
    private void Start()
    {
        ITest iTest = new Test2();
        iTest.Test();
    }
}

interface ITest
{
    void Test();
}

public class Test1 : ITest
{
    public virtual void Test()
    {
        Debug.Log("Test1");
    }
}

public class Test2 : Test1
{
    public override void Test()
    {
        Debug.Log("Test2");
    }
} 
