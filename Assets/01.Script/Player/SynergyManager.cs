using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SynergyManager : MonoBehaviour
{
    Synergy[] synergyArray;

    private void Start()
    {
        InitializeSynergyList();
    }

    private void Update()
    {
        CheckSynergyCount();
    }

    private void InitializeSynergyList()
    {
        synergyArray = new Synergy[28];

        synergyArray[0] = new Synergy("class_blunt", 0, 3, 5);
        synergyArray[1] = new Synergy("class_blade", 0, 3, 5);
        synergyArray[2] = new Synergy("class_gun", 0, 3, 5);
        synergyArray[5] = new Synergy("class_magic", 0, 3, 5);
        synergyArray[4] = new Synergy("class_fight", 0, 3, 5);
        synergyArray[5] = new Synergy("class_tool", 0, 3, 5);
        synergyArray[6] = new Synergy("class_building", 0, 3, 5);
        synergyArray[7] = new Synergy("class_machine", 0, 3, 5);
        synergyArray[8] = new Synergy("class_food", 0, 3, 5);

        synergyArray[9] = new Synergy("type_gothic", 0, 3, 5);
        synergyArray[10] = new Synergy("type_modern", 0, 3, 5);
        synergyArray[11] = new Synergy("type_SF", 0, 3, 5);
        synergyArray[12] = new Synergy("type_machine", 0, 3, 5);
        synergyArray[13] = new Synergy("type_holy", 0, 3, 5);
        synergyArray[14] = new Synergy("type_fantasy", 0, 3, 5);
        synergyArray[15] = new Synergy("type_military", 0, 3, 5);
        synergyArray[16] = new Synergy("type_culture", 0, 3, 5);
        synergyArray[17] = new Synergy("type_alcohol", 0, 1, 9999999);
        synergyArray[18] = new Synergy("type_buddism", 0, 3, 5);

        synergyArray[19] = new Synergy("element_poision", 0, 3, 5);
        synergyArray[20] = new Synergy("element_water", 0, 3, 5);
        synergyArray[21] = new Synergy("element_grass", 0, 3, 5);
        synergyArray[22] = new Synergy("element_electric", 0, 3, 5);
        synergyArray[23] = new Synergy("element_metal", 0, 3, 5);
        synergyArray[24] = new Synergy("element_fire`", 0, 3, 5);
        synergyArray[25] = new Synergy("element_mad", 0, 3, 5);
        synergyArray[26] = new Synergy("element_light", 0, 3, 5);
        synergyArray[27] = new Synergy("element_physical", 0, 3, 5);

    }

    private void CheckSynergyCount()
    {
        for(int i = 0; i < synergyArray.Length; i++)
        {
            if(synergyArray[i].count >= synergyArray[i].secondBuffCount)
            {
                synergyArray[i].secondBuffEnabled = true;
            }
            else if(synergyArray[i].count >= synergyArray[i].firstBuffCount)
            {
                synergyArray[i].secondBuffEnabled = false;
                synergyArray[i].firstBuffEnabled = true;
            }
            else
            {
                synergyArray[i].secondBuffEnabled = false;
                synergyArray[i].firstBuffEnabled = false;
            }
        }
    }
    public void AddSynergyCount(string name, int value)
    {
        for(int i = 0; i < synergyArray.Length;i++)
        {
            if (synergyArray[i].name == name)
            {
                synergyArray[i].count += value;
                return;
            }
        }
        Debug.LogError("Cannot find synergy by name; " + name);
    }
}

[Serializable]
public struct Synergy
{
    public Synergy(string name, int count, int first, int second)
    {
        this.name = name;
        this.count = count;
        this.firstBuffCount = first;
        this.secondBuffCount = second;
        this.firstBuffEnabled = false;
        this.secondBuffEnabled = false;
    }
    public string name;
    public int count;
    public int firstBuffCount;
    public int secondBuffCount;

    public bool firstBuffEnabled;
    public bool secondBuffEnabled;
}
