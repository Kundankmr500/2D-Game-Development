﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public GameObject ButtonLock;

    public void LockThisButton()
    {
        ButtonLock.SetActive(true);
    }
}
