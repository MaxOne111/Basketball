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
    [SerializeField] private GameObject _Webview_Background;

    private void Awake()
    {
        GameEvents._Answer += StartWebview;
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

    private void StartWebview()
    {
        _Webview_Background.SetActive(true);
    }

    private void OnDisable()
    {
        GameEvents._Answer -= StartWebview;
        GameEvents._Hit -= ShowScore;
    }
}
