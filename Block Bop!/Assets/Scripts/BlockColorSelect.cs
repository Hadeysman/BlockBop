using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class BlockColorSelect : MonoBehaviour
{
    Dictionary<string, Color32> colorDict = new Dictionary<string, Color32>();

    [SerializeField]
    private GameObject ourBlock;
    

    // Start is called before the first frame update
    void Start()
    {
        colorDict.Add("Red", new Color32(255, 0, 0, 255));
        colorDict.Add("Blue", new Color32(0, 0, 255, 255));
        colorDict.Add("Green", new Color32(0, 255, 0, 255));
        
        KeyValuePair<string, Color32> randomColor = colorDict.ElementAt(Random.Range(0, colorDict.Count));
        ourBlock.GetComponent<SpriteRenderer>().color = randomColor.Value;
    }



    
}
