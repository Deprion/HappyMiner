using UnityEngine;

public class ClickSign : MonoBehaviour
{
    [SerializeField] private bool isEndless;

    private void OnMouseDown()
    {
        Events.EndlessMode.Invoke(isEndless);
    }
}
