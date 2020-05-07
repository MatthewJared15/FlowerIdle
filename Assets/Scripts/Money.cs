using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    [SerializeField] Text moneyCountText;

    int currentMoney = 0;

    // Start is called before the first frame update
    void Start()
    {
        moneyCountText.text = currentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMoneyChange(int changeAmount) {
        currentMoney = currentMoney + changeAmount;
        moneyCountText.text = currentMoney.ToString();
    }
}
