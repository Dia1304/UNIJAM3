using UnityEngine;

public class RewardMapChange : MonoBehaviour
{
    public ArmManager armManager;
    public ItemReward itemReward;
    public GameObject move;
    public GameObject map;
    public GameObject itemChange;
    public bool startMove = false;
    public void PushYesButton()
    {
        itemReward.ChangeItem();
        armManager.rewardState = 1;
        startMove = true;

    }

    public void PushNoButton()
    {
        armManager.rewardState = 1;
        startMove = true;
    }

    private void Update()
    {
        if(startMove)
        {
            move.transform.position =
            Vector3.MoveTowards(move.transform.position, Vector3.zero, 1f);
            if(Vector3.MoveTowards(move.transform.position, Vector3.zero, 1).x <= 0.1f)
            {
                move.transform.position = Vector3.zero;
                startMove = false;
                map.SetActive(true);    
                itemChange.SetActive(false);
            }
        }
    }
}
