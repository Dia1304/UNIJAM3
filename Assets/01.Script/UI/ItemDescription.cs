using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemDescription : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image explainDisplay;
    [SerializeField]
    Text explainText;
    private PlayerManager playerManager;
    private SynergyManager synergyManager;
    public int id = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("ItemDisplay");
        explainDisplay = temp.GetComponent<UnityEngine.UI.Image>();
        explainText = temp.GetComponentInChildren<Text>();
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
        synergyManager = playerManager.synergyManager;
    }
    public void OnScreen()
    {
        string explain;
        if (id != 17)
        {
            explain = "동일 시너지 3개이상 수집시 효과발동\n" + synergyManager.synergydiscription[id];
        }
        else
        {
            explain = "동일 시너지 1개이상 수집시 효과발동\n" + synergyManager.synergydiscription[id];
        }

        explain = explain.Replace("\\n", "\n");
        explainText.text = explain;
        explainDisplay.enabled = true;

    }

    public void OffScreen()
    {
        explainDisplay.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
