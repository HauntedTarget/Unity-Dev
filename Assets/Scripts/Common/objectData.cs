using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectData : MonoBehaviour
{
    [SerializeField] List<string> dataList = null;

    public bool CheckExistance(string targetString)
    {
        foreach (var item in dataList)
        {
            if (item.ToLower() == targetString.ToLower())
            {
                return true;
            }
        }

        return false;
    }
}
