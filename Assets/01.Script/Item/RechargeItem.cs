using UnityEngine;

public class RechargeItem : Item
{
    int NowChargeCnt = 0;
    int MaxChargeCnt = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Charge()
    {
        if (NowChargeCnt < MaxChargeCnt)
        {
            NowChargeCnt++;
        }
    }

    void ResetCharge()
    {
        NowChargeCnt = 0;
    }

}
