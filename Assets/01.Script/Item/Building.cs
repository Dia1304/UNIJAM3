using UnityEngine;

public class Building : ConsumableItem
{
    public GameObject building;
    public BuildingData buildingData;
    public BuildingData data;

    void Start()
    {
        buildingData = Instantiate(data);
        ResetCount();
    }

    public override void UseItem()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject _building = Instantiate(building, mousePos, Quaternion.identity);

        _building.GetComponent<Structure>().durability = buildingData.durability * PlayerController.instance.Stat.structureDurabilityMultiplier;
    }
}
