using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private Button settings, profile, compas, anvil, top, back;
    [SerializeField] private GameObject settingsPanel, profilePanel, compasPanel,
        anvilPanel, topPanel;
    private void Awake()
    {
        back.gameObject.SetActive(false);
        settings.onClick.AddListener(delegate { SwitchPanel(settingsPanel); });
        profile.onClick.AddListener(delegate { SwitchPanel(profilePanel); });
        compas.onClick.AddListener(delegate { SwitchPanel(compasPanel); });
        anvil.onClick.AddListener(delegate { SwitchPanel(anvilPanel); });
        top.onClick.AddListener(delegate { SwitchPanel(topPanel); });
    }

    private void SwitchPanel(GameObject go)
    {
        go.SetActive(!go.activeSelf);
        if (go.activeSelf)
        {
            back.gameObject.transform.SetParent(go.transform, false);
            back.gameObject.transform.SetSiblingIndex(0);
            back.gameObject.SetActive(true);
            back.onClick.AddListener(delegate { ClosePanel(go); });
        }
    }
    private void ClosePanel(GameObject go)
    {
        go.SetActive(false);
        back.gameObject.SetActive(false);
        back.onClick.RemoveAllListeners();
    }
}
