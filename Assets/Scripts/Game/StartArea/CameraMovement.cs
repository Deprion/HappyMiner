using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float speed = 20;

    private float index;

    private Vector3 pos;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(Cor());
    }

    private IEnumerator Cor()
    {
        while (index < speed)
        {
            index++;
            Camera.main.orthographicSize = Mathf.Lerp(9, 4, index / speed);

            ChangePos();

            yield return new WaitForSeconds(0.04f);
        }
    }

    private void ChangePos()
    {
        pos = Vector2.Lerp
            (transform.localPosition, player.transform.localPosition, index / speed);

        pos.z = -10;

        transform.localPosition = pos;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
