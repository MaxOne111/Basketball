
using System.Collections.Generic;
using UnityEngine;

public static class LanguageList
{

    private static Dictionary<string, SystemLanguage> _Languages;

    public static string CurrentLanguage()
    {
        string _system_Language = Application.systemLanguage.ToString();
        _Languages = new Dictionary<string, SystemLanguage>()
        {
            ["ru"] = SystemLanguage.Russian,
            ["eng"] = SystemLanguage.English,
            ["fr"] = SystemLanguage.French,
            ["ja"] = SystemLanguage.Japanese,
            ["zh"] = SystemLanguage.Chinese,
            ["it"] = SystemLanguage.Italian,
            ["de"] = SystemLanguage.German,
            ["es"] = SystemLanguage.Spanish,
        };
        foreach (var _lang in _Languages)
        {
            if (_lang.Value == Application.systemLanguage)
            {
                _system_Language = _lang.Key;
            }
        }

        return _system_Language;
    }
}
