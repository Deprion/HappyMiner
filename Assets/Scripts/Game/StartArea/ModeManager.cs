using System.Collections;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private ClickSign endless, limited;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Events.EndlessMode.AddListener(ModeChoose);
    }

    private void ModeChoose(bool isEndless)
    {
        StopAllCoroutines();
        StartCoroutine(MoveChar(isEndless));
    }

    private IEnumerator MoveChar(bool isRight)
    {
        Camera.main.gameObject.AddComponent<CameraMovement>();

        for (int i = 0; i < 60; i++)
        {
            if (isRight)
            {
                player.transform.localPosition = Vector2.Lerp
                    (player.transform.localPosition, new Vector2(12.5f, -2.5f), i / 60f);
            }
            else
            {
                player.transform.localPosition = Vector2.Lerp
                    (player.transform.localPosition, new Vector2(-12.5f, -2.5f), i / 60f);
            }

            yield return new WaitForSeconds(0.03f);
        }
    }

    private void OnDestroy()
    {
        Events.EndlessMode.RemoveListener(ModeChoose);
    }
}
