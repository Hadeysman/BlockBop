using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    public GameObject blockPrefab;
    public float spawnTime = 1.0f;
    public float spawnDelay = 1.0f;
    private bool stopSpawning = false;

    private int sortingOrder = 1;


    RectTransform rectTransform;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        InvokeRepeating("spawnBlock", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void spawnBlock()
    {
        sortingOrder = (sortingOrder + GameObject.FindGameObjectsWithTag("BlockToBop").Length) * 3;
        //We want to create a block on the screen given certain parameters:
        //-The block will spawn randomly in one area in the given camera area.
        //Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        blockPrefab.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        blockPrefab.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder - 1;
        print("We have found multiuple blocks : " + blockPrefab.GetComponent<SpriteRenderer>().sortingOrder);
        Vector2 screenBounds = rectTransform.sizeDelta;
        float x;
        float y;
        Vector2 pos;
        print(screenBounds.x / 2);
        print(screenBounds.y / 2);
        x = Random.Range((screenBounds.x * -1) / 2 , screenBounds.x / 2);
        y = Random.Range((screenBounds.y * -1) / 2 , (screenBounds.y / 2) - 1);
        
        
        pos = new Vector2(x, y);
        
        //print("Block Spawned");
        Instantiate(blockPrefab, pos, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("spawnBlock");
        }
        //-The block has a specific color associated with it

        //-The block is not overlapping another block
        //-Once the block is hit, determine if player gets scores a point or is deducted a point based on the called color needed
        //Block dissapears after some time

    }
    
}
