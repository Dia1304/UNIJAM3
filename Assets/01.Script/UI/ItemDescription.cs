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
            explain = "���� �ó��� 3���̻� ������ ȿ���ߵ�\n" + synergyManager.synergydiscription[id];
        }
        else
        {
            explain = "���� �ó��� 1���̻� ������ ȿ���ߵ�\n" + synergyManager.synergydiscription[id];
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
