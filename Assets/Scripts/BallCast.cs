using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCast : MonoBehaviour
{
    [SerializeField] private CastPower _Cast_Power;
    [SerializeField] private HitSystem _Hit_System;

    [SerializeField] private Transform _Start_Position;
    [SerializeField] private ParticleSystem _Start_Effect;

    [SerializeField] private Ball _Ball;
    
    private Camera _Camera;

    private float _Y_Offset = 1;
    private float _Force_Multiplier = 11f;
    
    private void Awake()
    {
        GameEvents._Cast += Cast;
    }

    private void Start()
    {
        _Camera = Camera.main;
    }

    private void Cast()
    {
        StartCoroutine(WasCast());
        
        _Ball.Rigidbody.useGravity = true;
        
        Vector3 _cast_Direction = new Vector3(_Camera.transform.forward.x, _Camera.transform.forward.y + _Y_Offset,
            _Camera.transform.forward.z);
        _Ball.Rigidbody.AddForce(_cast_Direction * _Cast_Power.Force * _Force_Multiplier, ForceMode.Impulse);
    }

    private IEnumerator WasCast()
    {
        _Cast_Power.enabled = false;
        
        float _delay = 5;
        while (_delay > 0)
        {
            if (_Hit_System.IsHit)
            {
                _Ball.Rigidbody.velocity = Vector3.zero;
                _Ball.Rigidbody.angularVelocity = Vector3.zero;
                _Ball.Rigidbody.useGravity = false;
        
                _Ball.transform.localPosition = _Start_Position.localPosition;
                _Ball.StartGrow();
                _Start_Effect.Play();
                
                GameEvents.NextRound();

                _Cast_Power.enabled = true;
                
                yield break;
            }
            _delay -= 1 * Time.deltaTime;
            yield return null;

        }
        _Ball.Rigidbody.velocity = Vector3.zero;
        _Ball.Rigidbody.angularVelocity = Vector3.zero;
        _Ball.Rigidbody.useGravity = false;
        
        _Ball.transform.localPosition = _Start_Position.localPosition;
        _Ball.StartGrow();
        _Start_Effect.Play();
        
        _Hit_System.HitColliderEnable(true);

        _Cast_Power.enabled = true;

    }

    private void OnDisable()
    {
        GameEvents._Cast -= Cast;
    }
}
