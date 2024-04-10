using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class CommonHelper
{
    public static JsonData ReadJson(string name)
    {
        //加载资源
        TextAsset obj = Resources.Load<TextAsset>(name);
        if (obj == null)
        {
            Debug.LogError($"无法读取到文件：{name}");
            return null;
        }

        //Debug.Log(obj.text);

        //使用JsonMapper.ToObject解析
        JsonData jsonData = JsonMapper.ToObject(obj.text);

        //foreach(var item in jsonData.Keys)
        //{
        //    Debug.Log(item);
        //}
        ////Debug.Log(jsonData.ToJson());
        return jsonData;
    }
}
