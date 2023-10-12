using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight, durationJump;
    [SerializeField] private int numberJumps;
    [SerializeField] private Vector3 endValue;
    private bool isGrounded = true;

    public GameObject gameOver;
    [HideInInspector]
    public bool isgameOver = false;
    public Tween playertweener;

    // Gettting Input with New Input System
    private InputActionSystem inputActionSystem;
    private InputAction touchPressAction;
    private void Awake()
    {
        inputActionSystem = new InputActionSystem();
        touchPressAction = inputActionSystem.Player.Jump;

    }

    private void OnEnable()
    {
        inputActionSystem.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        inputActionSystem.Player.Jump.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (touchPressAction.phase == InputActionPhase.Performed && isGrounded)
        {
            isGrounded = false;
            playertweener = transform.DOJump(endValue, jumpHeight, numberJumps, durationJump, false).SetEase(Ease.Linear).OnComplete(() => isGrounded = true);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playertweener.Kill();
            Time.timeScale = 0;
            isgameOver = true;
            gameOver.SetActive(true);
        }
    }
    
}
