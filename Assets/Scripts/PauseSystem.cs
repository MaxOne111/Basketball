using System;
using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class PauseSystem : MonoBehaviour
{
    public bool IsPause { get; private set; }

    private void Awake()
    {
        GameEvents._Answer += Pause;
    }

    public void Pause()
    {
        IsPause = true;
    }

    public void StartGame()
    {
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        float _delay = 0.05f;
        yield return new WaitForSeconds(_delay);
        IsPause = false;
    }

    private void OnDisable()
    {
        GameEvents._Answer -= Pause;
    }
}
