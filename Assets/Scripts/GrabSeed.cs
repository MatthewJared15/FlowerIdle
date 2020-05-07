using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabSeed : MonoBehaviour
{

    int seedCount = 0;
    
    [SerializeField] Text seedCountText;

    // Start is called before the first frame update
    void Start()
    {
        seedCountText.text = seedCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrabSeed() {
        seedCount++;
        seedCountText.text = seedCount.ToString();
    }

    public bool OnRemoveSeed() {
        if (seedCount <= 0) {
            return false;
        } else {   
            seedCount--;
            seedCountText.text = seedCount.ToString();
            return true;
        }
    }
}
