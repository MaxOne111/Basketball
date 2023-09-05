using System;
using UnityEngine;
using System.Collections;

public class BrowserOpener : MonoBehaviour {

	public string _Url = "https://www.google.com";

	// check readme file to find out how to change title, colors etc.

	private void Awake()
	{
		GameEvents._Answer += OnButtonClicked;
	}

	public void OnButtonClicked() {
		InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
		options.hidesTopBar = true;
		options.androidBackButtonCustomBehaviour = true;
		options.hidesDefaultSpinner = true;
		InAppBrowser.OpenURL(_Url, options);
	}

	public void OnClearCacheClicked() {
		Debug.Log("Clear Cache!");
		InAppBrowser.ClearCache();
	}

	private void OnDisable()
	{
		GameEvents._Answer -= OnButtonClicked;
	}
}
