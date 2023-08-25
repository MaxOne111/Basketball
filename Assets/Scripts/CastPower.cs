using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastPower : MonoBehaviour
{
    [SerializeField] private GameUI _Game_UI;
    [SerializeField] private PauseSystem _Pause_System;
    private LineRenderer _Line_Renderer;

    private Camera _Camera;
    
    public float Force { get; private set; }
    

    private void Awake()
    {
        _Line_Renderer = GetComponent<LineRenderer>();
        _Camera = Camera.main;
    }

    private void Update()
    {
        if (!_Pause_System.IsPause)
        {
            CastForce();
        }
    }

    private void CastForce()
    {
        float _z = 0.75f;
        Vector3 _mouse_Screen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _z);
        
        Vector3 _mouse_World = _Camera.ScreenToWorldPoint(_mouse_Screen);

        if (Input.GetMouseButtonDown(0) && !_Pause_System.IsPause)
        {
            _Line_Renderer.enabled = true;

            _Line_Renderer.SetPosition(0, _mouse_World);
        }
        if (Input.GetMouseButton(0))
        {
            Force = Mathf.Abs((_mouse_World - _Line_Renderer.GetPosition(0)).magnitude);
            _Line_Renderer.SetPosition(1, _mouse_World);
            
            _Game_UI.ShowCastForce(Force);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _Line_Renderer.enabled = false;
            GameEvents.Cast();
        }
    }
    
}
