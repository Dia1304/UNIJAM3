using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SynergyManager : MonoBehaviour
{
    public Synergy[] synergyArray;
    public int[] synergyCnt = new int[28];
    public Sprite[] synergySprite = new Sprite[28];
    public bool inBattle = false;
    public PlayerManager playerManager;
    private void Awake()
    {
        InitializeSynergyList();
        playerManager = GetComponent<PlayerManager>();
    }
    private void Start()
    {

    }

    public void nowSynergy()
    {
        for (int i = 0; i < synergyArray.Length; i++)
        {
            synergyCnt[i] = synergyArray[i].count;
        }
    }

    private void Update()
    {
        CheckSynergyCount();
        nowSynergy();
    }

    private void InitializeSynergyList()
    {
        synergyArray = new Synergy[28];

        synergyArray[0] = new Synergy("class_blunt", 0, 3, 5);
        synergyArray[1] = new Synergy("class_blade", 0, 3, 5);
        synergyArray[2] = new Synergy("class_gun", 0, 3, 5);
        synergyArray[3] = new Synergy("class_magic", 0, 3, 5);
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
        synergyArray[17] = new Synergy("type_alcohol", 0, 1, 9999999); //���ܰ�
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
            if(synergyArray[i].count >= synergyArray[i].secondBuffCount && synergyArray[i].secondBuffEnabled == false)
            {
                Debug.Log("Enable second buff");
                EnableBuff(i, false);
                synergyArray[i].secondBuffEnabled = true;
            }
            else if (synergyArray[i].count < synergyArray[i].secondBuffCount && synergyArray[i].secondBuffEnabled == true)
            {
                Debug.Log("Disable second buff");
                DisableBuff(i, false);
                synergyArray[i].secondBuffEnabled = false;
            }
            if(synergyArray[i].count >= synergyArray[i].firstBuffCount && synergyArray[i].firstBuffEnabled == false)
            {
                Debug.Log("Enable first buff");
                EnableBuff(i, true);
                synergyArray[i].firstBuffEnabled = true;
            }
            else if (synergyArray[i].count < synergyArray[i].firstBuffCount && synergyArray[i].firstBuffEnabled == true)
            {
                Debug.Log("Disable first buff");
                DisableBuff(i, true);
                synergyArray[i].firstBuffEnabled = false;
            }
        }
    }
    private void EnableBuff(int index, bool isFirst)
    {
        if(!inBattle)
        {
            return;
        }
        switch(index)
        {
            case 0: //class_blunt
                if(isFirst)
                {
                    PlayerController.instance.Stat.bluntCoolTimeMultiplier -= 0.4f;
                    PlayerController.instance.Stat.bluntDamageMultiplier += 1.0f;
                }
                else
                {
                    //�б� ������ ���� ��Ĩ�ϴ�
                }
                break;
            case 1: //class_blade
                if(isFirst)
                {
                    PlayerController.instance.Stat.bladeCoolTimeMultiplier += 0.5f;
                }
                else
                {
                    //������ ���ݿ� ���� ���� ������ ���ݿ� �߰� ���ظ� �޽��ϴ�
                }
                break;
            case 2: //class_gun
                if(isFirst)
                {
                    PlayerController.instance.Stat.gunRangeMultiplier += 0.50f;
                    PlayerController.instance.Stat.gunAreaMultiplier += 0.50f;
                }
                else
                {
                    PlayerController.instance.Stat.gunCoolTimeMultiplier += 0.70f;
                }
                break;
            case 3: //case_magic
                if(isFirst)
                {
                    //���� ���� ������ ������ ����ϴ�
                }
                else
                {
                    PlayerController.instance.Stat.magicDamageMultiplier += 0.50f;
                }
                break;
            case 4: //class_fight
                if(isFirst)
                {
                    PlayerController.instance.Stat.fightRangeMultiplier += 2.00f;
                }
                else
                {
                    //���� ������ ���� 5�ʸ��� ������ŵ�ϴ�
                }
                break;
            case 5: //class_tool
                if(isFirst)
                {
                    //���� 25�� Ÿ���� �� �Ҹ�ǰ ��ٿ��� 1ĭ �����մϴ�
                }
                else
                {
                    PlayerController.instance.Stat.toolRangeMultiplier += 1.00f;
                    PlayerController.instance.Stat.toolAreaMultiplier += 1.00f;
                }
                break;
            case 6: //class_building
                if(isFirst)
                {
                    PlayerController.instance.Stat.structureDurabilityMultiplier += 1.0f;
                }
                else
                {
                    //���� �������� �ߺ� ��ġ�� �� �ֽ��ϴ�
                }
                break;
            case 7: //class_machine
                if(isFirst)
                {
                    PlayerController.instance.Stat.moveSpeed *= 1.25f;
                }
                else
                {
                    //��� ���� ������ ����ϴ� ��ȣ�� ȹ��
                }
                break;
            case 8: //class_food
                if(isFirst)
                {
                    PlayerController.instance.Stat.attackSpeed += 0.1f;
                }
                else
                {
                    PlayerController.instance.Stat.foodCoolTimeMultiplier += 0.5f;
                }
                break;
            case 9: //type_gothic
                if (isFirst)
                {
                    playerManager.AddArm(0,0,0);
                }
                else
                {

                }
                break;
            case 10: //type_modern
                if(isFirst)
                {
                    playerManager.AddArm(0, 0, 1);
                }
                else
                {

                }
                break;
            case 11: //type_SF
                if(isFirst)
                {
                    playerManager.AddArm(0, 0, 2);
                }
                else
                {

                }
                break;
            case 12: //type_machine
                if(isFirst)
                {
                    playerManager.AddArm(0, 0, 3);
                }
                else
                {

                }
                break;
            case 13: //type_holy
                if(isFirst)
                {
                    playerManager.AddArm(0, 0, 4);

                }
                else
                {

                }
                break;
            case 14: //type_fantasy
                if(isFirst)
                {
                    playerManager.AddArm(0, 0, 5);

                }
                else
                {

                }
                break;
            case 15: //type_military
                if(isFirst)
                {
                    playerManager.AddArm(0, 0, 6);
                }
                else
                {

                }
                break;
            case 16: //type_culture
                if(isFirst)
                {
                    playerManager.AddArm(0, 0, 7);
                    playerManager.AddArm(0, 0, 7);
                }
                else
                {

                }
                break;
            case 17: //type_alcohol
                if(isFirst)
                {

                }
                else
                {

                }
                break;
            case 18: //type_Buddism
                if(isFirst)
                {
                    playerManager.AddArm(0, 0, 9);
                }
                else
                {

                }
                break;
            case 19: //element_poision
                if(isFirst)
                {
                    PlayerController.instance.Stat.poisionMultiplier += 0.3f;
                    //�� ������ ���� �ߵ����� ���� ���ظ� �ݴϴ�
                }
                else
                {
                    //�ߵ��� ���� ������ �ֺ��� ���� �۶߸��ϴ�
                }
                break;
            case 20: //element_water
                if(isFirst)
                {
                    PlayerController.instance.Stat.waterMultiplier += 0.3f;
                    //�� ���� 30%, �� ������ ���� ���� �������� �մϴ�
                }
                else
                {
                    //������ ���� ���� �ӵ��� �������ϴ�
                }
                break;
            case 21: //element_grass
                if(isFirst)
                {
                    PlayerController.instance.Stat.grassMultiplier += 0.3f;
                    //Ǯ ���� 30%, Ǯ ������ ���� �������� �ൿ�� �����մϴ�
                }
                else
                {
                    //��� ������ �� �� ���˴ϴ�
                }
                break;
            case 22: //element_electric
                if(isFirst)
                {
                    PlayerController.instance.Stat.electricMultiplier += 0.3f;
                    //���� ���� 20%, ���� ������ ���� �������� �߰� ���ظ� �ݴϴ�
                }
                else
                {
                    //������ ���� ���� ������ ������ �ֺ��� ��� ������ ������ �Ű����ϴ�
                }
                break;
            case 23: //element_metal
                if(isFirst)
                {
                    PlayerController.instance.Stat.metalMultiplier += 0.3f; 
                    //�ݼ� ���� 30%, ��� ��� ���⿡ �ݼ��� �ο��մϴ�
                }
                else
                {
                    //�ݼ� �Ӽ� ���ݿ� ���� ���� �ݼ� ���ݿ� �߰� ���ظ� �޽��ϴ�
                }
                break;
            case 24: //element_fire
                if(isFirst)
                {
                    PlayerController.instance.Stat.fireMultiplier += 0.3f;
                    //�� ���� 30%, ��� ������ ���⿡ ���� �ο��մϴ�
                }
                else
                {
                    //�� �Ӽ� ���� ���Ⱑ ���� ������ ����ϴ�
                }
                break;
            case 25: //element_mad
                if(isFirst)
                {
                    PlayerController.instance.Stat.madMultiplier += 0.3f;
                    //���� ���� 30%, ���� ������ ���� ȥ������ �־����� �մϴ�
                }
                else
                {
                    //ȥ���� ���� ���� �ٸ� ���� �����մϴ�
                }
                break;
            case 26: //element_light
                if(isFirst)
                {
                    PlayerController.instance.Stat.lightMultiplier += 0.3f;
                    //�� ���� 30%, ��� �ż� ���⿡ ���� �ο��մϴ�
                }
                else
                {
                    //�� �Ӽ� ���ݿ� ���� ������ ü���� �ణ ȸ���մϴ�
                }
                break;
            case 27: //element_physical
                if(isFirst)
                {
                    PlayerController.instance.Stat.physicalMultiplier += 0.5f;
                }
                else
                {
                    PlayerController.instance.Stat.physicalMultiplier += 1.0f;
                }
                break;
        }
    }
    private void DisableBuff(int index, bool isFirst)
    {
        if (!inBattle)
        {
            return;
        }
        switch (index)
        {
            case 0: //class_blunt
                if(isFirst)
                {
                    //�б� ������ ���� ��Ĩ�ϴ�
                }
                else
                {
                    PlayerController.instance.Stat.bluntCoolTimeMultiplier += 0.4f;
                    PlayerController.instance.Stat.bluntDamageMultiplier -= 1.0f;
                }
                break;
            case 1: //class_blade
                if(isFirst)
                {
                    PlayerController.instance.Stat.bladeCoolTimeMultiplier -= 0.5f;
                }
                else
                {
                    //������ ���ݿ� ���� ���� ������ ���ݿ� �߰� ���ظ� �޽��ϴ�
                }
                break;
            case 2: //class_gun
                if(isFirst)
                {
                    PlayerController.instance.Stat.gunRangeMultiplier -= 0.50f;
                    PlayerController.instance.Stat.gunAreaMultiplier -= 0.50f;
                }
                else
                {
                    PlayerController.instance.Stat.gunCoolTimeMultiplier -= 0.70f;
                }
                break;
            case 3: //case_magic
                if(isFirst)
                {
                    PlayerController.instance.Stat.magicDamageMultiplier -= 0.50f;
                }
                else
                {
                    //���� ���� ������ ������ ����ϴ�
                }
                break;
            case 4: //class_fight
                if(isFirst)
                {
                    //���� ������ ���� 5�ʸ��� ������ŵ�ϴ�
                }
                else
                {
                    PlayerController.instance.Stat.fightRangeMultiplier -= 1.00f;
                }
                break;
            case 5: //class_tool
                if(isFirst)
                {
                    //���� 25�� Ÿ���� �� �Ҹ�ǰ ��ٿ��� 1ĭ �����մϴ�
                }
                else
                {
                    PlayerController.instance.Stat.toolRangeMultiplier -= 1.00f;
                    PlayerController.instance.Stat.toolAreaMultiplier -= 1.00f;
                }
                break;
            case 6: //class_building
                if(isFirst)
                {
                    PlayerController.instance.Stat.structureDurabilityMultiplier -= 1.0f;
                }
                else
                {
                    //���� �������� �ߺ� ��ġ�� �� �ֽ��ϴ�
                }
                break;
            case 7: //class_machine
                if(isFirst)
                {
                    PlayerController.instance.Stat.moveSpeed /= 1.25f;
                }
                else
                {
                    //��� ���� ������ ����ϴ� ��ȣ�� ȹ��
                }
                break;
            case 8: //class_food
                if(isFirst)
                {
                    //��� ��Ÿ�� 10% ����
                }
                else
                {
                    PlayerController.instance.Stat.foodCoolTimeMultiplier -= 0.5f;
                }
                break;
            case 9: //type_gothic
                if (isFirst)
                {
                    Debug.Log("Gothic Arm should be removed");
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 10: //type_modern
                if(isFirst)
                {
                    Debug.Log("Modern Arm should be removed");
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 11: //type_SF
                if(isFirst)
                {
                    Debug.Log("SF Arm should be removed");
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 12: //type_machine
                if(isFirst)
                {
                    Debug.Log("Machine Arm should be removed");
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 13: //type_holy
                if(isFirst)
                {
                    Debug.Log("Holy Arm should be removed");
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 14: //type_fantasy
                if(isFirst)
                {
                    Debug.Log("Fantasy Arm should be removed");
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 15: //type_military
                if(isFirst)
                {
                    Debug.Log("Military Arm should be removed");
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 16: //type_culture
                if(isFirst)
                {
                    Debug.Log("Culture Arm should be removed");
                    playerManager.RemoveArm();
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 17: //type_alcohol
                if(isFirst)
                {

                }
                else
                {

                }
                break;
            case 18: //type_Buddism
                if(isFirst)
                {
                    Debug.Log("Budda Arm should be removed");
                    playerManager.RemoveArm();
                }
                else
                {

                }
                break;
            case 19: //element_poision
                if(isFirst)
                {
                    PlayerController.instance.Stat.poisionMultiplier -= 0.3f;
                    //�� ������ ���� �ߵ����� ���� ���ظ� �ݴϴ�
                }
                else
                {
                    //�ߵ��� ���� ������ �ֺ��� ���� �۶߸��ϴ�
                }
                break;
            case 20: //element_water
                if(isFirst)
                {
                    PlayerController.instance.Stat.waterMultiplier -= 0.3f;
                    //�� ���� 30%, �� ������ ���� ���� �������� �մϴ�
                }
                else
                {
                    //������ ���� ���� �ӵ��� �������ϴ�
                }
                break;
            case 21: //element_grass
                if(isFirst)
                {
                    PlayerController.instance.Stat.grassMultiplier -= 0.3f;
                    //Ǯ ���� 30%, Ǯ ������ ���� �������� �ൿ�� �����մϴ�
                }
                else
                {
                    //��� ������ �� �� ���˴ϴ�
                }
                break;
            case 22: //element_electric
                if(isFirst)
                {
                    PlayerController.instance.Stat.electricMultiplier -= 0.3f;
                    //���� ���� 20%, ���� ������ ���� �������� �߰� ���ظ� �ݴϴ�
                }
                else
                {
                    //������ ���� ���� ������ ������ �ֺ��� ��� ������ ������ �Ű����ϴ�
                }
                break;
            case 23: //element_metal
                if(isFirst)
                {
                    PlayerController.instance.Stat.metalMultiplier -= 0.3f; 
                    //�ݼ� ���� 30%, ��� ��� ���⿡ �ݼ��� �ο��մϴ�
                }
                else
                {
                    //�ݼ� �Ӽ� ���ݿ� ���� ���� �ݼ� ���ݿ� �߰� ���ظ� �޽��ϴ�
                }
                break;
            case 24: //element_fire
                if(isFirst)
                {
                    PlayerController.instance.Stat.fireMultiplier -= 0.3f;
                    //�� ���� 30%, ��� ������ ���⿡ ���� �ο��մϴ�
                }
                else
                {
                    //�� �Ӽ� ���� ���Ⱑ ���� ������ ����ϴ�
                }
                break;
            case 25: //element_mad
                if(isFirst)
                {
                    PlayerController.instance.Stat.madMultiplier -= 0.3f;
                    //���� ���� 30%, ���� ������ ���� ȥ������ �־����� �մϴ�
                }
                else
                {
                    //ȥ���� ���� ���� �ٸ� ���� �����մϴ�
                }
                break;
            case 26: //element_light
                if(isFirst)
                {
                    PlayerController.instance.Stat.lightMultiplier -= 0.3f;
                    //�� ���� 30%, ��� �ż� ���⿡ ���� �ο��մϴ�
                }
                else
                {
                    //�� �Ӽ� ���ݿ� ���� ������ ü���� �ణ ȸ���մϴ�
                }
                break;
            case 27: //element_physical
                if(isFirst)
                {
                    PlayerController.instance.Stat.physicalMultiplier -= 0.5f;
                }
                else
                {
                    PlayerController.instance.Stat.physicalMultiplier -= 1.0f;
                }
                break;
        }
    }
    public void AddSynergyCount(string name, int value)
    {
        for(int i = 0; i < synergyArray.Length ;i++)
        {
            if (synergyArray[i].name == name)
            {
                synergyArray[i].count += value;
                return;
            }
        }
        Debug.LogError("Cannot find synergy by name; " + name);
    }


    public void AddSynergy(ItemData item)
    {
        Debug.Log(item);
        switch (item.classData)
        {
            case ItemData.Class.Blunt:
                AddSynergyCount("class_blunt", 1);
                break;
            case ItemData.Class.Blade:
                AddSynergyCount("class_blade", 1);
                break;
            case ItemData.Class.Gun:
                AddSynergyCount("class_gun", 1);
                break;
            case ItemData.Class.Magic:
                AddSynergyCount("class_magic", 1);
                break;
            case ItemData.Class.Fight:
                AddSynergyCount("class_fight", 1);
                break;
            case ItemData.Class.Tool:
                AddSynergyCount("class_tool", 1);
                break;
            case ItemData.Class.Buliding:
                AddSynergyCount("class_building", 1);
                break;
            case ItemData.Class.Machine:
                AddSynergyCount("class_machine", 1);
                break;
            case ItemData.Class.Food:
                AddSynergyCount("class_food", 1);
                break;
        }
        switch (item.type)
        {
            case ItemData.Type.Gothic:
                AddSynergyCount("type_gothic", 1);
                break;
            case ItemData.Type.Modern:
                AddSynergyCount("type_modern", 1);
                break;
            case ItemData.Type.SF:
                AddSynergyCount("type_SF", 1);
                break;
            case ItemData.Type.Machine:
                AddSynergyCount("type_machine", 1);
                break;
            case ItemData.Type.Holy:
                AddSynergyCount("type_holy", 1);
                break;
            case ItemData.Type.Military:
                AddSynergyCount("type_military", 1);
                break;
            case ItemData.Type.Culture:
                AddSynergyCount("type_culture", 1);
                break;
            case ItemData.Type.Alcohol:
                AddSynergyCount("type_alcohol", 1);
                break;
            case ItemData.Type.Buddhism:
                AddSynergyCount("type_buddism", 1);
                break;
        }
        switch (item.element)
        {
            case ItemData.Element.Poision:
                AddSynergyCount("element_poision", 1);
                break;
            case ItemData.Element.Water:
                AddSynergyCount("element_water", 1);
                break;
            case ItemData.Element.Grass:
                AddSynergyCount("element_grass", 1);
                break;
            case ItemData.Element.Electric:
                AddSynergyCount("element_electric", 1);
                break;
            case ItemData.Element.Metal:
                AddSynergyCount("element_metal", 1);
                break;
            case ItemData.Element.Fire:
                AddSynergyCount("element_fire", 1);
                break;
            case ItemData.Element.Mad:
                AddSynergyCount("element_mad", 1);
                break;
            case ItemData.Element.Light:
                AddSynergyCount("element_light", 1);
                break;
            case ItemData.Element.Physical:
                AddSynergyCount("element_physical", 1);
                break;
        }


    }
    public void SubtractSynergy(ItemData item)
    {
        Debug.Log(item);
        switch (item.classData)
        {
            case ItemData.Class.Blunt:
                AddSynergyCount("class_blunt", -1);
                break;
            case ItemData.Class.Blade:
                AddSynergyCount("class_blade", -1);
                break;
            case ItemData.Class.Gun:
                AddSynergyCount("class_gun", -1);
                break;
            case ItemData.Class.Magic:
                AddSynergyCount("class_magic", -1);
                break;
            case ItemData.Class.Fight:
                AddSynergyCount("class_fight", -1);
                break;
            case ItemData.Class.Tool:
                AddSynergyCount("class_tool", -1);
                break;
            case ItemData.Class.Buliding:
                AddSynergyCount("class_building", -1);
                break;
            case ItemData.Class.Machine:
                AddSynergyCount("class_machine", -1);
                break;
            case ItemData.Class.Food:
                AddSynergyCount("class_food", -1);
                break;
        }
        switch (item.type)
        {
            case ItemData.Type.Gothic:
                AddSynergyCount("type_gothic", -1);
                break;
            case ItemData.Type.Modern:
                AddSynergyCount("type_modern", -1);
                break;
            case ItemData.Type.SF:
                AddSynergyCount("type_SF", -1);
                break;
            case ItemData.Type.Machine:
                AddSynergyCount("type_machine", -1);
                break;
            case ItemData.Type.Holy:
                AddSynergyCount("type_holy", -1);
                break;
            case ItemData.Type.Military:
                AddSynergyCount("type_military", -1);
                break;
            case ItemData.Type.Culture:
                AddSynergyCount("type_culture", -1);
                break;
            case ItemData.Type.Alcohol:
                AddSynergyCount("type_alcohol", -1);
                break;
            case ItemData.Type.Buddhism:
                AddSynergyCount("type_buddism", -1);
                break;
        }
        switch (item.element)
        {
            case ItemData.Element.Poision:
                AddSynergyCount("element_poision", -1);
                break;
            case ItemData.Element.Water:
                AddSynergyCount("element_water", -1);
                break;
            case ItemData.Element.Grass:
                AddSynergyCount("element_grass", -1);
                break;
            case ItemData.Element.Electric:
                AddSynergyCount("element_electric", -1);
                break;
            case ItemData.Element.Metal:
                AddSynergyCount("element_metal", -1);
                break;
            case ItemData.Element.Fire:
                AddSynergyCount("element_fire", -1);
                break;
            case ItemData.Element.Mad:
                AddSynergyCount("element_mad", -1);
                break;
            case ItemData.Element.Light:
                AddSynergyCount("element_light", -1);
                break;
            case ItemData.Element.Physical:
                AddSynergyCount("element_physical", -1);
                break;
        }

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
