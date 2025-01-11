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
        synergyArray[17] = new Synergy("type_alcohol", 0, 1, 9999999); //예외값
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
                    //둔기 공격이 적을 밀칩니다
                }
                break;
            case 1: //class_blade
                if(isFirst)
                {
                    PlayerController.instance.Stat.bladeCoolTimeMultiplier += 0.5f;
                }
                else
                {
                    //날붙이 공격에 당한 적은 날붙이 공격에 추가 피해를 받습니다
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
                    //마법 범위 공격이 장판을 남깁니다
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
                    //격투 공격이 적을 5초마다 기절시킵니다
                }
                break;
            case 5: //class_tool
                if(isFirst)
                {
                    //적을 25번 타격할 시 소모품 쿨다운이 1칸 감소합니다
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
                    //같은 구조물을 중복 설치할 수 있습니다
                }
                break;
            case 7: //class_machine
                if(isFirst)
                {
                    PlayerController.instance.Stat.moveSpeed *= 1.25f;
                }
                else
                {
                    //기계 무기 개수에 비례하는 보호막 획득
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
                    //독 공격이 적을 중독시켜 지속 피해를 줍니다
                }
                else
                {
                    //중독된 적이 죽으면 주변에 독을 퍼뜨립니다
                }
                break;
            case 20: //element_water
                if(isFirst)
                {
                    PlayerController.instance.Stat.waterMultiplier += 0.3f;
                    //물 증폭 30%, 물 공격이 적을 적셔 느려지게 합니다
                }
                else
                {
                    //적셔진 적은 공격 속도도 느려집니다
                }
                break;
            case 21: //element_grass
                if(isFirst)
                {
                    PlayerController.instance.Stat.grassMultiplier += 0.3f;
                    //풀 증폭 30%, 풀 공격이 적을 기절시켜 행동을 방해합니다
                }
                else
                {
                    //모든 음식이 두 번 사용됩니다
                }
                break;
            case 22: //element_electric
                if(isFirst)
                {
                    PlayerController.instance.Stat.electricMultiplier += 0.3f;
                    //전기 증폭 20%, 전기 공격이 적을 감전시켜 추가 피해를 줍니다
                }
                else
                {
                    //감전된 적이 전기 공격을 받으면 주변의 모든 감전된 적에게 옮겨집니다
                }
                break;
            case 23: //element_metal
                if(isFirst)
                {
                    PlayerController.instance.Stat.metalMultiplier += 0.3f; 
                    //금속 증폭 30%, 모든 기계 무기에 금속을 부여합니다
                }
                else
                {
                    //금속 속성 공격에 당한 적은 금속 공격에 추가 피해를 받습니다
                }
                break;
            case 24: //element_fire
                if(isFirst)
                {
                    PlayerController.instance.Stat.fireMultiplier += 0.3f;
                    //불 증폭 30%, 모든 날붙이 무기에 불을 부여합니다
                }
                else
                {
                    //불 속성 범위 무기가 불의 장판을 남깁니다
                }
                break;
            case 25: //element_mad
                if(isFirst)
                {
                    PlayerController.instance.Stat.madMultiplier += 0.3f;
                    //광기 증폭 30%, 광기 공격이 적을 혼란시켜 멀어지게 합니다
                }
                else
                {
                    //혼란에 빠진 적이 다른 적을 공격합니다
                }
                break;
            case 26: //element_light
                if(isFirst)
                {
                    PlayerController.instance.Stat.lightMultiplier += 0.3f;
                    //빛 증폭 30%, 모든 신성 무기에 빛을 부여합니다
                }
                else
                {
                    //빛 속성 공격에 적이 죽으면 체력을 약간 회복합니다
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
                    //둔기 공격이 적을 밀칩니다
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
                    //날붙이 공격에 당한 적은 날붙이 공격에 추가 피해를 받습니다
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
                    //마법 범위 공격이 장판을 남깁니다
                }
                break;
            case 4: //class_fight
                if(isFirst)
                {
                    //격투 공격이 적을 5초마다 기절시킵니다
                }
                else
                {
                    PlayerController.instance.Stat.fightRangeMultiplier -= 1.00f;
                }
                break;
            case 5: //class_tool
                if(isFirst)
                {
                    //적을 25번 타격할 시 소모품 쿨다운이 1칸 감소합니다
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
                    //같은 구조물을 중복 설치할 수 있습니다
                }
                break;
            case 7: //class_machine
                if(isFirst)
                {
                    PlayerController.instance.Stat.moveSpeed /= 1.25f;
                }
                else
                {
                    //기계 무기 개수에 비례하는 보호막 획득
                }
                break;
            case 8: //class_food
                if(isFirst)
                {
                    //모든 쿨타임 10% 감소
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
                    //독 공격이 적을 중독시켜 지속 피해를 줍니다
                }
                else
                {
                    //중독된 적이 죽으면 주변에 독을 퍼뜨립니다
                }
                break;
            case 20: //element_water
                if(isFirst)
                {
                    PlayerController.instance.Stat.waterMultiplier -= 0.3f;
                    //물 증폭 30%, 물 공격이 적을 적셔 느려지게 합니다
                }
                else
                {
                    //적셔진 적은 공격 속도도 느려집니다
                }
                break;
            case 21: //element_grass
                if(isFirst)
                {
                    PlayerController.instance.Stat.grassMultiplier -= 0.3f;
                    //풀 증폭 30%, 풀 공격이 적을 기절시켜 행동을 방해합니다
                }
                else
                {
                    //모든 음식이 두 번 사용됩니다
                }
                break;
            case 22: //element_electric
                if(isFirst)
                {
                    PlayerController.instance.Stat.electricMultiplier -= 0.3f;
                    //전기 증폭 20%, 전기 공격이 적을 감전시켜 추가 피해를 줍니다
                }
                else
                {
                    //감전된 적이 전기 공격을 받으면 주변의 모든 감전된 적에게 옮겨집니다
                }
                break;
            case 23: //element_metal
                if(isFirst)
                {
                    PlayerController.instance.Stat.metalMultiplier -= 0.3f; 
                    //금속 증폭 30%, 모든 기계 무기에 금속을 부여합니다
                }
                else
                {
                    //금속 속성 공격에 당한 적은 금속 공격에 추가 피해를 받습니다
                }
                break;
            case 24: //element_fire
                if(isFirst)
                {
                    PlayerController.instance.Stat.fireMultiplier -= 0.3f;
                    //불 증폭 30%, 모든 날붙이 무기에 불을 부여합니다
                }
                else
                {
                    //불 속성 범위 무기가 불의 장판을 남깁니다
                }
                break;
            case 25: //element_mad
                if(isFirst)
                {
                    PlayerController.instance.Stat.madMultiplier -= 0.3f;
                    //광기 증폭 30%, 광기 공격이 적을 혼란시켜 멀어지게 합니다
                }
                else
                {
                    //혼란에 빠진 적이 다른 적을 공격합니다
                }
                break;
            case 26: //element_light
                if(isFirst)
                {
                    PlayerController.instance.Stat.lightMultiplier -= 0.3f;
                    //빛 증폭 30%, 모든 신성 무기에 빛을 부여합니다
                }
                else
                {
                    //빛 속성 공격에 적이 죽으면 체력을 약간 회복합니다
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
