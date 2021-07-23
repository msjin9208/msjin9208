using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SoonsoonData
{
    
    // Start is called before the first frame updateprivate 
    static SoonsoonData instance = null;
    public static SoonsoonData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SoonsoonData();
            }
            return instance;
        }
    }

    private SoonsoonData(){}


    [Serializable]
    public class SoonData
    {
        public List<List<bool>> packageList = new List<List<bool>>();
    }
    public SoonData _soonData = new SoonData();

    public SPUM_Manager _spumManager;


    public void SaveData()
    {
        // bool _saveAvailable = false;

        try
        {
            FileSaveToPrefab();
        }
        catch (System.Exception e)
        {
            Debug.Log("Failed to save the data");
            Debug.Log(e);
        }
        finally
        {
        }
    }


    private void FileSaveToPrefab()
    {
        var b = new BinaryFormatter();
        var m = new MemoryStream();
        b.Serialize(m , _soonData);
        PlayerPrefs.SetString("SoonsoonSave",Convert.ToBase64String(m.GetBuffer())); 
    }

    public IEnumerator LoadData()
    {
        yield return null;
        try
        {
            LoadProcess();
        }
        catch( System.Exception e)
        {
            Debug.Log(" Failed to load Data...");
            Debug.Log(e.ToString());
        }

        yield return new WaitForSecondsRealtime(0.1f);
    }
    public void LoadProcess()
    {
        Debug.Log("Trying Loading data ...");

        if(!PlayerPrefs.HasKey("SoonsoonSave"))
        {
            Debug.Log("You don't use save data yet.");
        }
        else
        {
            string _str = PlayerPrefs.GetString("SoonsoonSave");

            if( _str.Length > 0)
            {
                string _tmpStr = PlayerPrefs.GetString("SoonsoonSave");
                if(!string.IsNullOrEmpty(_tmpStr)) 
                {
                    var b = new BinaryFormatter();
                    var m = new MemoryStream(Convert.FromBase64String(_tmpStr));
                    _soonData = (SoonData) b.Deserialize(m);
                    Debug.Log("Load Successful!!");
                }
            }
        }
    }

    public void SavePackageData()
    {
        SoonsoonData.instance._soonData.packageList.Clear();
        #if UNITY_EDITOR
        for( var i = 0 ; i < _spumManager._textureList.Count;i++)
        {
            List<bool> tList = new List<bool>();
            for(var j = 0 ; j < _spumManager._textureList[i]._packageList.Count;j++)
            {
                tList.Add(_spumManager._textureList[i]._packageList[j]);
            }

            SoonsoonData.instance._soonData.packageList.Add(tList);
        }
        
        SaveData();
        #endif
    }

    public void LoadPackageData()
    {
        #if UNITY_EDITOR
        for( var i = 0 ; i < _spumManager._textureList.Count;i++)
        {
            List<bool> tList = new List<bool>();
            for(var j = 0 ; j < _spumManager._textureList[i]._packageList.Count;j++)
            {
                tList.Add(_soonData.packageList[i][j]);
            }

            _spumManager._textureList[i]._packageList.Clear();

            for ( var j = 0 ; j < tList.Count;j++)
            {
                 _spumManager._textureList[i]._packageList.Add(tList[j]);
            } 
        }

        _spumManager.LinkPackageList();
        #endif
    }
}
