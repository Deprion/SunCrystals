using UnityEngine;
using UnityEngine.UI;

public class DeleteData : MonoBehaviour
{
    [SerializeField] private Button delDataBtn;
    [SerializeField] private GameObject delPanel;
    private void Awake()
    {
        delDataBtn.onClick.AddListener(DeleteSave);
    }
    private void DeleteSave()
    {
        DataManagerSO.inst.DeleteData();
        Application.Quit();
    }
    public void SwitchDelPanel()
    {
        delPanel.SetActive(!delPanel.activeSelf);
    }
}
