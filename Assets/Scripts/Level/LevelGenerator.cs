using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D Map;

    public GameObject LevelBlock;

    public GameObject[] Blocks;//Blocks
    public GameObject[] Items;//PowerUps
    public GameObject[] Enemies;//Enemies


    // Use this for initialization
    void Start () {
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate()
    {
        int w = Map.width;
        int h = Map.height;
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                Color32 color = Map.GetPixel(x, y);

                if(color == Color.black)
                {
                    Instantiate(LevelBlock, new Vector3(x, y), Quaternion.identity);
                }

                if (color.r == 255)
                {
                    if (color.r < Enemies.Length)
                        Instantiate(Enemies[(int)color.g], new Vector3(x, y), Quaternion.identity);
                }

                if (color.g == 255)
                {
                    if (color.r < Items.Length)
                        Instantiate(Items[(int)color.b], new Vector3(x, y), Quaternion.identity);
                }

                if (color.b == 255)
                {
                    if(color.r < Blocks.Length)
                        Instantiate(Blocks[(int)color.r], new Vector3(x, y), Quaternion.identity);
                }
            }
        }
    }
}
