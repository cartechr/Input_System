using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Test
{
    public string TestName;

    public InputActionReference currentInput;

    public int num = -1;

    public bool testbool;

    public GameObject GameObject;
}
