using UnityEngine;

public class MemeticKillAgent : MonoBehaviour
{
    private void OnBecameVisible()
    {
        Invoke("TestManager.Instance.GameOver()",1f);
    }
}
