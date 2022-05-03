using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Count { get; set; }
    public IItem Type { get; set; }
    public int Price { get; set; }
    public string PrefabLink { get; set; }
}
