using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelGenerator lvl;

    private void Awake()
    {
        Events.EndlessMode.AddListener(ModeChoose);
    }

    private void ModeChoose(bool isEndless)
    {
        lvl.GenerateLevel(isEndless);
    }

    private void OnDestroy()
    {
        Events.EndlessMode.RemoveListener(ModeChoose);
    }
}
