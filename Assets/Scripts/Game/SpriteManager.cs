using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] private Sprite cobble, goldOre;

    public Sprite GetSprite()
    { 
        return Random.Range(0, 2) == 1 ? cobble : goldOre;
    }
}
