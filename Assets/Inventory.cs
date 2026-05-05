using UnityEngine;
using System.Collections.Generic;
public class Inventory
{
    private Dictionary<string, int> dict;
    public Inventory()
    {
        dict = new Dictionary<string, int>();
        dict["Bullets"] = 0;
        dict["AND"] =0;
        dict["OR"] = 0;
        dict["XOR"] = 0;
        dict["WIRE"] = 0;
        dict["NOT"] =0;
        dict["SWITCH"] = 0;
        dict["LED"] = 0;
        dict["MUX"] = 0;
        dict["DMUX"] = 0;
        dict["HalfSum"] = 0;
        dict["FullSum"] = 0;
    }

    public void Transact(Inventory other)
    {
        var keys = new List<string>(dict.Keys);

        foreach (var key in keys)
        {
            int amount = dict[key];

            Debug.Log($"Player get {key}: {amount}");

            if (other.dict.ContainsKey(key))
                other.dict[key] += amount;

            dict[key] = 0;
        }
    }

    public bool ChangeByName(string name, int add)
    {
        if (dict[name] + add>= 0)
        {
            dict[name] += add;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RandamLoot()
    {
        dict["Bullets"] = Random.Range(0, 30);
        dict["AND"] = Random.Range(0, 10);
        dict["OR"] = Random.Range(0, 10);
        dict["XOR"] = Random.Range(0, 10);
        dict["WIRE"] = Random.Range(0, 50);
        dict["NOT"] = Random.Range(0, 10);
        dict["SWITCH"] = Random.Range(0, 10);
        dict["LED"] = Random.Range(0, 10);
        dict["MUX"] = Random.Range(0, 10);
        dict["DMUX"] = Random.Range(0, 10);
        dict["HalfSum"] = Random.Range(0, 5);
        dict["FullSum"] = Random.Range(0, 5);
    }
    // bool isValid(string name)
    // {
    //     return dict[name] >=0;
    // }
}