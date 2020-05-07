using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFlower : MonoBehaviour
{

    [SerializeField] int flowerSellPrice;

    SpriteRenderer spriteRenderer;
    Color initialColor;
    GrabSeed grabSeed;
    Money money;
    int flowerGrowthState; //0 - not planted, 1 - planted, 2 - growing, 3 - fully grown

    private IEnumerator growthCycle;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
        grabSeed = FindObjectOfType<GrabSeed>();
        money = FindObjectOfType<Money>();
        flowerGrowthState = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown() {
        if (flowerGrowthState == 0) {
            OnPlantSeed();
        } else if (flowerGrowthState == 3) {
            OnSellFlower();
        }
    }

    void OnPlantSeed() { 
        if (grabSeed.OnRemoveSeed()){
            spriteRenderer.color = Color.blue;
            flowerGrowthState = 1;
            growthCycle = GrowthCycle(2.0f);
            StartCoroutine(growthCycle);
        }
    }

    private IEnumerator GrowthCycle(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        spriteRenderer.color = Color.red;
        flowerGrowthState = 3;
    }

    void OnSellFlower() {
        money.OnMoneyChange(flowerSellPrice);
        flowerGrowthState = 0;
        spriteRenderer.color = initialColor;
    }

}
