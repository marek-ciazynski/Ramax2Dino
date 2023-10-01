using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DinosaurResponse
{
    public string name;
    public string motto;
}


[System.Serializable]
public class DinosaurRequest
{
    public List<string> keywords;
}
