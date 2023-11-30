using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    private InputAction _pressAnyKeyAction =
            new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>", interactions: "Press");

    private void OnEnable() => _pressAnyKeyAction.Enable();
    private void OnDisable() => _pressAnyKeyAction.Disable();

    void Update()
    {
        if (_pressAnyKeyAction.triggered)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}