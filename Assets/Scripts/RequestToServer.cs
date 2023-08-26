using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Application = UnityEngine.Device.Application;

public class RequestToServer : MonoBehaviour
{
   [SerializeField] private string _URL;
   [SerializeField] private SaveData _Save_Data;
   [SerializeField] private BrowserOpener _Web_View;
   [SerializeField] private TextMeshProUGUI _Answer_Text;

   public string Answer { get; private set; }

   public void StartSending()
   {
      StartCoroutine(SendRequest());
   }

   private void Start()
   {
      StartSending();
   }

   private IEnumerator SendRequest()
   {

      WWWForm _form_Data = new WWWForm();
      
      _form_Data.AddField("phone_name", $"{SystemInfo.deviceModel}/{SystemInfo.deviceName}");
      _form_Data.AddField("locale", $"{Application.systemLanguage}");
      _form_Data.AddField("unique", $"{_Save_Data.DeviceID}");

      UnityWebRequest _request = UnityWebRequest.Post(_URL, _form_Data);
      yield return _request.SendWebRequest();
      
      Answer = ProcessedAnswer(_request);

      _Answer_Text.text = $"{Answer}";
      
      ResponseReaction();
      
      _request.Dispose();

   }

   private string ProcessedAnswer(UnityWebRequest _request)
   {
      string[] _substring = _request.downloadHandler.text.Split(':');
      string _answer;

      if (_substring.Length > 2)
      {
         _substring[2] = _substring[2].Remove(0, 1);
         _answer = _substring[1] + ":/" + _substring[2];
      }
      else
      {
         _answer = _substring[1];
      }
      _answer = _answer.Trim('{', '}', '"');

      return _answer;
   }

   private void ResponseReaction()
   {
      switch (Answer)
         {
            case "no": Debug.Log("No");
               break;
         
            case "nopush": Debug.Log("No push");
               break;
         
            default: _Web_View._Url = Answer;
               GameEvents.Answer();
               break;
         }
      
   }
   
}
