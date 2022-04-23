using UnityEngine;

public class OnCrystalClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        CrystalManager.s_inst.ChangeActiveCrystal();
    }
}
