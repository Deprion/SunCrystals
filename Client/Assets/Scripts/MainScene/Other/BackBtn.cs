using UnityEngine;

public class BackBtn : MonoBehaviour
{
    public void SwitchBtn()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
