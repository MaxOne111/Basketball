using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Score_Text;
    [SerializeField] private TextMeshProUGUI _Cast_Force_Text;
    [SerializeField] private TextMeshProUGUI _Distance_Text;

    private void Awake()
    {
        GameEvents._Hit += ShowScore;
    }

    private void Start()
    {
        PlayerData.LoadData();
        ShowScore();
    }

    private void ShowScore()
    {
        _Score_Text.text = $"Score: {PlayerData.Score}";
    }

    public void ShowCastForce(float _force)
    {
        _Cast_Force_Text.text = $"Cast Force: {(_force * 10).ToString("F1")}";
    }

    public void ShowDistance(float _distance)
    {
        _Distance_Text.text = $"Distance: {_distance.ToString("F1")}";
    }

    private void OnDisable()
    {
        GameEvents._Hit -= ShowScore;
    }
}
