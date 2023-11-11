using UnityEngine;

public class SpriteAnim : MonoBehaviour
{
    [SerializeField] protected Sprite[] sprites;
    [SerializeField] protected float timer;
    protected float leftTime;
    protected int index = 0;

    protected SpriteRenderer sprite;

    protected virtual void Start()
    {
        SetUp();
    }

    protected virtual void Update()
    {
        Anim();
    }

    protected virtual void SetUp()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = sprites[index];
        leftTime = timer;
    }

    protected virtual void Anim()
    {
        leftTime -= Time.deltaTime;

        if (leftTime <= 0)
        {
            leftTime = timer;

            index = index + 1 >= sprites.Length ? 0 : index + 1;

            sprite.sprite = sprites[index];
        }
    }
}
