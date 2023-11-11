using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cobble;
    [SerializeField] private Transform parent;

    [SerializeField] private SpriteManager spr;

    private List<GameObject[]> levelRows = new List<GameObject[]>();

    public void GenerateLevel(bool isEndless)
    { 
        if (isEndless)
            GenerateLevel(new Vector2(10.5f, -3.5f));
        else
            GenerateLevel(new Vector2(-14.5f, -3.5f));
    }

    private void GenerateLevel(Vector2 pos)
    {
        float baseX = pos.x;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            { 
                var obj = Instantiate(cobble, parent, false);
                obj.transform.localPosition = pos;
                obj.GetComponent<SpriteRenderer>().sprite = spr.GetSprite();

                if (j != 1)
                    pos.x += 1;
                else
                    pos.x += 2;
            }

            pos.x = baseX;
            pos.y -= 1;
        }
    }
}
