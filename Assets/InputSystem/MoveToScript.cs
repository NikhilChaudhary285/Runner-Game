using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class MoveToScript : MonoBehaviour
{

    [SerializeField] private float jumpHeight, durationJump;
    [SerializeField] private int numberJumps;
    [SerializeField] private Vector3 endValue;

    Tween player;

    private InputActionSystem inputActionSystem;
    private InputAction touchAndKeyboardPressAction;

    private void Awake()
    {
        inputActionSystem = new InputActionSystem();
        touchAndKeyboardPressAction = inputActionSystem.Player.FirstJump;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        inputActionSystem.Player.FirstJump.Enable();
    }

    private void OnDisable()
    {
        inputActionSystem.Player.FirstJump.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();

        }

        if (touchAndKeyboardPressAction.phase == InputActionPhase.Performed)
        {
            player = transform.DOJump(endValue, jumpHeight, numberJumps, durationJump, false).SetEase(Ease.Linear).OnComplete(() =>
            {
                player.Kill();
                SceneManager.LoadScene("DotWeenRunnerGame");

            });
        }
    }
}

