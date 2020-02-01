using System.Collections;
using UnityEngine;

public class InputControlles : MonoBehaviour
{
    private PlayerControlles m_PlayerControlles;

    public float m_HorizontalAxis { get; set; }
    public float m_VerticalAxis { get; set; }

    public int m_YAxisUp { get; set; }
    public int m_XAxisRight { get; set; }
    public int m_YAxisDown { get; set; }
    public int m_XAxisLeft { get; set; }

    public bool m_JumpButton { get; set; }
    public bool m_JumpButtonDown { get; set; }

    public bool m_MeleeAttackButton { get; set; }
    public bool m_MeleeAttackButtonDown { get; set; }

    public bool m_RangedAttackButton { get; set; }
    public bool m_RangedAttackButtonDown { get; set; }

    public bool m_DashButton { get; set; }
    public bool m_DashButtonDown { get; set; }

    public bool m_UtillityButton { get; set; }
    public bool m_UtillityButtonDown { get; set; }

    public bool m_SwitchButton { get; set; }
    public bool m_SwitchButtonDown { get; set; }

    public bool m_PauseButton { get; set; }
    public bool m_PauseButtonDown { get; set; }

    public bool m_SelectButton { get; set; }
    public bool m_SelectButtonDown { get; set; }

    private void Awake()
    {
        m_PlayerControlles = new PlayerControlles();

        //.started = GetButtonDown()
        //.canceled = GetButtonUp()

        //Axes
        m_PlayerControlles.Axis.YAxisPlus.started += moveUp => GetUpAxisDown();
        m_PlayerControlles.Axis.YAxisPlus.canceled += moveUp => GetUpAxisUp();

        m_PlayerControlles.Axis.XAxisPlus.started += moveRight => GetRightAxisDown();
        m_PlayerControlles.Axis.XAxisPlus.canceled += moveRight => GetRightAxisUp();

        m_PlayerControlles.Axis.YAxisMin.started += moveDown => GetDownAxisDown();
        m_PlayerControlles.Axis.YAxisMin.canceled += moveDown => GetDownAxisUp();

        m_PlayerControlles.Axis.XAxisMin.started += moveLeft => GetLeftAxisDown();
        m_PlayerControlles.Axis.XAxisMin.canceled += moveLeft => GetLeftAxisUp();

        //Buttons
        m_PlayerControlles.Button.JumpButtton.started += jump => GetJumpButton();
        m_PlayerControlles.Button.JumpButtton.canceled += jump => GetJumpButtonUp();

        m_PlayerControlles.Button.MeleeAttackButton.started += attack => GetMeleeAttackButton();
        m_PlayerControlles.Button.MeleeAttackButton.canceled += attack => GetMeleeAttackButtonUp();

        m_PlayerControlles.Button.RangedAttackButton.started += attack => GetRangedAttackButton();
        m_PlayerControlles.Button.RangedAttackButton.canceled += attack => GetRangedAttackButtonUp();

        m_PlayerControlles.Button.DashButton.started += dash => GetDashButton();
        m_PlayerControlles.Button.DashButton.canceled += dash => GetDashButtonUp();

        m_PlayerControlles.Button.SwitchColor.started += utillity => GetUtillityButton();
        m_PlayerControlles.Button.SwitchColor.canceled += utillity => GetUtillityButtonUp();

        m_PlayerControlles.Button.SwitchCharacter.started += switchChar => GetSwitchButton();
        m_PlayerControlles.Button.SwitchCharacter.started += switchChar => GetSwitchButtonUp();
    }

    private void Update()
    {
        if (m_XAxisRight != 0)
        {
            m_HorizontalAxis = 1f;
        }
        else if (m_XAxisLeft != 0)
        {
            m_HorizontalAxis = -1f;
        }
        else
        {
            m_HorizontalAxis = 0f;
        }

        if (m_YAxisUp != 0)
        {
            m_VerticalAxis = 1f;
        }
        else if (m_YAxisDown != 0)
        {
            m_VerticalAxis = -1f;
        }
        else
        {
            m_VerticalAxis = 0f;
        }
    }

    private void OnEnable()
    {
        m_PlayerControlles.Axis.Enable();
        m_PlayerControlles.Button.Enable();
    }
    private void OnDisable()
    {
        m_PlayerControlles.Axis.Disable();
        m_PlayerControlles.Button.Disable();
    }

    //Axes
    private void GetRightAxisDown()
    {
        m_XAxisRight = 1;
    }
    private void GetRightAxisUp()
    {
        m_XAxisRight = 0;
    }
    private void GetLeftAxisDown()
    {
        m_XAxisLeft = 1;
    }
    private void GetLeftAxisUp()
    {
        m_XAxisLeft = 0;
    }

    private void GetUpAxisDown()
    {
        m_YAxisUp = 1;
    }
    private void GetUpAxisUp()
    {
        m_YAxisUp = 0;
    }
    private void GetDownAxisDown()
    {
        m_YAxisDown = 1;
    }
    private void GetDownAxisUp()
    {
        m_YAxisDown = 0;
    }

    //Buttons
    private void GetJumpButton()
    {
        m_JumpButton = true;
        StartCoroutine(GetButtonJumpButtonDown());
    }
    private IEnumerator GetButtonJumpButtonDown()
    {
        m_JumpButtonDown = true;
        yield return new WaitForEndOfFrame();
        m_JumpButtonDown = false;
    }
    private void GetJumpButtonUp()
    {
        m_JumpButton = false;
    }

    private void GetMeleeAttackButton()
    {
        m_MeleeAttackButton = true;
        StartCoroutine(GetButtonMeleeAttackButtonDown());
    }
    private IEnumerator GetButtonMeleeAttackButtonDown()
    {
        m_MeleeAttackButtonDown = true;
        yield return new WaitForEndOfFrame();
        m_MeleeAttackButtonDown = false;
    }
    private void GetMeleeAttackButtonUp()
    {
        m_MeleeAttackButton = false;
    }

    private void GetRangedAttackButton()
    {
        m_RangedAttackButton = true;
        StartCoroutine(GetButtonRangedAttackButtonDown());
    }
    private IEnumerator GetButtonRangedAttackButtonDown()
    {
        m_RangedAttackButtonDown = true;
        yield return new WaitForEndOfFrame();
        m_RangedAttackButtonDown = false;
    }
    private void GetRangedAttackButtonUp()
    {
        m_RangedAttackButton = false;
    }

    private void GetDashButton()
    {
        m_DashButton = true;
        StartCoroutine(GetButtonDashButtonDown());
    }
    private IEnumerator GetButtonDashButtonDown()
    {
        m_DashButtonDown = true;
        yield return new WaitForEndOfFrame();
        m_DashButtonDown = false;
    }
    private void GetDashButtonUp()
    {
        m_DashButton = false;
    }

    private void GetUtillityButton()
    {
        m_UtillityButton = true;
        StartCoroutine(GetButtonUtillityButtonDown());
    }
    private IEnumerator GetButtonUtillityButtonDown()
    {
        m_UtillityButtonDown = true;
        yield return new WaitForEndOfFrame();
        m_UtillityButtonDown = false;
    }
    private void GetUtillityButtonUp()
    {
        m_UtillityButton = false;
    }

    private void GetSwitchButton()
    {
        m_SwitchButton = true;
        StartCoroutine(GetButtonSwitchButtonDown());
    }
    private IEnumerator GetButtonSwitchButtonDown()
    {
        m_SwitchButtonDown = true;
        yield return new WaitForEndOfFrame();
        m_SwitchButtonDown = false;
    }
    private void GetSwitchButtonUp()
    {
        m_SwitchButton = false;
    }

    private void GetPauseButton()
    {
        m_PauseButton = true;
        StartCoroutine(GetButtonPauseButtonDown());
    }
    private IEnumerator GetButtonPauseButtonDown()
    {
        m_PauseButtonDown = true;
        yield return new WaitForEndOfFrame();
        m_PauseButtonDown = false;
    }
    private void GetPauseButtonUp()
    {
        m_PauseButton = false;
    }

    private void GetSelectButton()
    {
        m_SelectButton = true;
        StartCoroutine(GetButtonSelectButtonDown());
    }
    private IEnumerator GetButtonSelectButtonDown()
    {
        m_SelectButtonDown = true;
        yield return new WaitForEndOfFrame();
        m_SelectButtonDown = false;
    }
    private void GetSelectButtonUp()
    {
        m_SelectButton = false;
    }
}
