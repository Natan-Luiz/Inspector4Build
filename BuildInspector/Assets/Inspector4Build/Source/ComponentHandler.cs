using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CommonType
{
    Vector2,
    Vector3,
    Vector4,
    Int,
    Bool,
    Float,
    Double,
    String,
    Object

}

public struct DataHandle
{
    public string name;
    public CommonType datatype;

    public string ViewData()
    {
        switch (datatype)
        {
            case CommonType.Vector2: return dataVector2.ToString();
            case CommonType.Vector3: return dataVector3.ToString();
            case CommonType.Vector4: return dataVector4.ToString();
            case CommonType.Int: return dataInt.ToString();
            case CommonType.Float: return dataFloat.ToString();
            case CommonType.Double: return dataDouble.ToString();
            case CommonType.Object: return dataObject.ToString();
            case CommonType.String: return dataString;
            case CommonType.Bool: return dataBool.ToString();
        }
        return "";
    }

    public DataHandle(Vector3 _data, string _name)
    {
        dataInt = 0;
        dataFloat = 0;
        dataDouble = 0;
        dataString = "";
        dataObject = null;
        dataVector2 = Vector2.zero;
        dataVector3 = _data;
        dataVector4 = Vector4.zero;
        dataBool = false;

        datatype = CommonType.Vector3;
        name = _name;
    }

    public DataHandle(string _data, string _name)
    {
        dataInt = 0;
        dataFloat = 0;
        dataDouble = 0;
        dataString = _data;
        dataObject = null;
        dataVector2 = Vector2.zero;
        dataVector3 = Vector3.zero;
        dataVector4 = Vector4.zero;
        dataBool = false;

        datatype = CommonType.String;
        name = _name;
    }

    public Vector3 GetVerctor3()
    {
        return dataVector3;
    }

    private int dataInt;
    private bool dataBool;
    private float dataFloat;
    private double dataDouble;
    private string dataString;
    private Object dataObject;
    private Vector2 dataVector2;
    private Vector3 dataVector3;
    private Vector4 dataVector4;
}

namespace Inspector4Build
{
    /// <summary>
    /// In this class is Serialized all possible components for the inspector to show;
    /// </summary>
    public static class ComponentHandler
    {
        public static DataHandle[] ProcessComponent(Transform c)
        {
            DataHandle[] data = new DataHandle[3];

            data[0] = new DataHandle(c.localPosition, "Position");
            data[1] = new DataHandle(c.localRotation.eulerAngles, "Rotation");
            data[2] = new DataHandle(c.localScale, "Scale");

            return data;
        }

        public static DataHandle[] ProcessComponent (Material c)
        {
            DataHandle[] data = new DataHandle[1];

            data[0] = new DataHandle(c.shader.ToString(), "Shader");

            return data;
        }
    }
}