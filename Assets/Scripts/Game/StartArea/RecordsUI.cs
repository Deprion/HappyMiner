using TMPro;
using UnityEngine;

public class RecordsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text labelTxt, limitedTxt, endlessTxt;

    private void Awake()
    {
        DataManager.TopRecords.AddListener(UpdateRecords, true);
    }

    private void UpdateRecords(long limited, long endless)
    {
        if (limited != 0)
        {
            limitedTxt.text = $"20 S {limited} m";
            limitedTxt.gameObject.SetActive(true);

            labelTxt.gameObject.SetActive(true);
        }
        if (endless != 0)
        {
            endlessTxt.text = $"Endless {limited} m";
            endlessTxt.gameObject.SetActive(true);

            labelTxt.gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        DataManager.TopRecords.RemoveListener(UpdateRecords);
    }
}
