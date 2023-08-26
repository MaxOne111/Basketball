using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HitSystem : MonoBehaviour
{
    [SerializeField] private GameUI _Game_UI;
    [SerializeField] private GameObject _Player;
    [SerializeField] private ParticleSystem _Hit_Effect;

    [SerializeField] private GameObject _Hit_Collider;

    [Space]
    [SerializeField] private float _Min_X_Position;
    [SerializeField] private float _Max_X_Position;

    private float _Three_Point_Distance = 7f;

    public bool IsHit { get; private set; }

    private void Awake()
    {
        GameEvents._Hit += Hit;
        GameEvents._Next_Round += ChangePosition;
        GameEvents._Miss += Miss;
        
    }

    private void Hit()
    {
        IsHit = true;
        _Hit_Effect.Play();

        if (_Player.transform.localPosition.x >= _Three_Point_Distance)
        {
            PlayerData.AddScore(3);
        }
        else
        {
            PlayerData.AddScore(2);
        }
        
        PlayerData.SaveData();
    }

    private void Miss()
    {
        HitColliderEnable(false);
    }

    public void HitColliderEnable(bool _enable)
    {
        _Hit_Collider.SetActive(_enable);
    }

    private void ChangePosition()
    {
        _Hit_Collider.SetActive(true);
        StartCoroutine(MoveToNewPosition());
    }

    private IEnumerator MoveToNewPosition()
    {
        float _x_Position = Random.Range(_Min_X_Position, _Max_X_Position);
        float _move_Speed = 10;
        
        Vector3 _new_Position = new Vector3(_x_Position, _Player.transform.localPosition.y, _Player.transform.localPosition.z);
        _Game_UI.ShowDistance(_x_Position);
        
        while (_Player.transform.localPosition != _new_Position)
        {
            _Player.transform.localPosition =
                Vector3.Lerp(_Player.transform.localPosition, _new_Position, _move_Speed * Time.deltaTime);

            yield return null;
        }

        IsHit = false;
    }

    private void OnDisable()
    {
        GameEvents._Hit -= Hit;
        GameEvents._Next_Round -= ChangePosition;
        GameEvents._Miss -= Miss;
    }
}
