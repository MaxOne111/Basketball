using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private string _Save_Filename = "_deviceData";
    private string _Path_To_Save_File;
    
    [field: SerializeField] public DeviceData _Device_Data;
    
    public string DeviceID
    {
        get => _Device_Data._ID;
    }

    private void Awake()
    {
        _Path_To_Save_File = Path.Combine(Application.persistentDataPath, _Save_Filename);
        DetectSaveFile();
    }

    private void DetectSaveFile()
    {
        if (File.Exists(_Path_To_Save_File))
        {
            _Device_Data = BinarySerializer.Deserialize<DeviceData>(_Path_To_Save_File);
        }
        else
        {
            _Device_Data._ID = Guid.NewGuid().ToString();
            Save();
        }
    }

    private void Save()
    {
        BinarySerializer.Serialize(_Path_To_Save_File, _Device_Data);
    }
}
