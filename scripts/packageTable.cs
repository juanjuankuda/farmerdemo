using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "farmer/packageData", fileName = "packageTable")]
public class PackageTable : ScriptableObject
{
    public List<PackageItem> DataList = new List<PackageItem>();
     
 }

[System.Serializable]
public class PackageItem
{
    public int id;
    public int type;
    public string name;
    public string description;
    public string imagePath;
}