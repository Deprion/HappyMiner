using UnityEngine;

public class FireLight : MonoBehaviour
{
    [SerializeField] private Light light2D;

    [SerializeField] private float waitForChange, offsetRange, speed;

    private float baseRange, destRange, curTime, leftTimeChange;

    private void Awake()
    {
        baseRange = light2D.range;
    }

    private void Update()
    {
        curTime += Time.deltaTime;

        light2D.range = Mathf.Lerp(light2D.range, destRange, curTime / speed);
        light2D.intensity = light2D.range;

        leftTimeChange -= Time.deltaTime;

        if (leftTimeChange <= 0)
        {
            destRange = baseRange + Random.Range(-offsetRange, offsetRange);
            curTime = 0;

            leftTimeChange = waitForChange;
        }
    }
}
