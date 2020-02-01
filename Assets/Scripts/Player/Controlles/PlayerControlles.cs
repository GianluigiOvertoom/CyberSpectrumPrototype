// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Controlles/PlayerControlles.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlles : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControlles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlles"",
    ""maps"": [
        {
            ""name"": ""Axis"",
            ""id"": ""e7a85b52-a257-45b9-9b18-6c9fc2ca0185"",
            ""actions"": [
                {
                    ""name"": ""XAxisMin"",
                    ""type"": ""Button"",
                    ""id"": ""028ad057-1018-4a00-a809-ddb231ae7fcb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""XAxisPlus"",
                    ""type"": ""Button"",
                    ""id"": ""65de8965-b245-4431-8dd7-4c93ecc47ac1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""YAxisMin"",
                    ""type"": ""Button"",
                    ""id"": ""5a6a4e86-382b-4c7c-9d4a-0726257a5431"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""YAxisPlus"",
                    ""type"": ""Button"",
                    ""id"": ""66f2e71f-480b-4500-b1a1-5b27c6b3a46a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""21bd9629-90ab-4869-8671-a6b15f5f3e6b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxisMin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0894021-eaa5-4cb4-be94-28b28712a883"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxisMin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd211161-29b2-40de-8f31-9332e3bc8eb9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxisMin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98f236ea-81a9-4c07-b336-213c7f6511d2"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxisMin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9013dc1d-7b2f-43a0-8484-aa1de5ac47bf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxisPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b0dceaf-49c9-4d47-b1bd-5ad9e6a9437c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxisPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b2e3fa0-3ee3-41c1-83ba-0e1a5ef59339"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxisPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9225071-03bc-4806-bc83-851e24523479"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxisPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""253a7391-a8e6-4775-b3f5-cf271d3d54d4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxisMin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2769163-0c35-4ed3-88c4-edbe78de28ac"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxisMin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9e308e0-db0f-4de4-bdff-8abfeaa85dbe"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxisMin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7db5c387-6113-4afa-ad4f-8807d91e697a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxisMin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2284f9a-7e87-43d5-9aa8-cc13c55b864f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxisPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63cff02e-34bc-4d2d-8bb6-b25daa38813f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxisPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35475350-58df-4325-b80c-aca9df78f030"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxisPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e35b9f50-396b-4665-8e7d-6600f8616535"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxisPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Button"",
            ""id"": ""f9f31b8e-fa62-4b9a-b8ec-dae671b7a9ce"",
            ""actions"": [
                {
                    ""name"": ""JumpButtton"",
                    ""type"": ""Button"",
                    ""id"": ""17df5a5c-7383-4d26-9caa-5d72b5883495"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MeleeAttackButton"",
                    ""type"": ""Button"",
                    ""id"": ""86b28c62-3f67-4ee9-8638-dcac86d37cec"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangedAttackButton"",
                    ""type"": ""Button"",
                    ""id"": ""d383cfab-0db7-4afb-82ad-921b40aca66e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DashButton"",
                    ""type"": ""Button"",
                    ""id"": ""3fdd1776-9b61-4f90-b0d6-91128f1de9e5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchColor"",
                    ""type"": ""Button"",
                    ""id"": ""b1cf76d6-1b94-48f4-bbd7-e018a313a65d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""6309e3ac-de06-4329-8edf-f6a96d181a75"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""99dad1a2-4f30-4d5b-bf27-3156f13f41f6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangedAttackButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29449f29-f6c3-4c35-9334-8a2c28c5f8ca"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangedAttackButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8524b97-66b0-4c82-b692-69af29c97d50"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleeAttackButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8300fddb-b975-4e6f-b044-5f61b4b2a360"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleeAttackButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59d4bac6-9909-4d70-aeaf-fd290ed26af2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpButtton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aef3957-ee65-4c4e-89f5-858ebe58319f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpButtton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c91131fa-686b-45dd-84b3-92f2acdaba51"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ca19c9a-96bc-4e61-8640-902d56cb20fa"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4128cf9-3629-4b93-bdf6-7214c9f062d0"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchColor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdc754e0-acee-4a02-9d50-fe61db67c2c5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchColor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec37352b-d40a-47c3-9e58-637f9e3bb373"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""128cc2f7-5fcc-48af-bae1-12b5849b0ae6"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Axis
        m_Axis = asset.FindActionMap("Axis", throwIfNotFound: true);
        m_Axis_XAxisMin = m_Axis.FindAction("XAxisMin", throwIfNotFound: true);
        m_Axis_XAxisPlus = m_Axis.FindAction("XAxisPlus", throwIfNotFound: true);
        m_Axis_YAxisMin = m_Axis.FindAction("YAxisMin", throwIfNotFound: true);
        m_Axis_YAxisPlus = m_Axis.FindAction("YAxisPlus", throwIfNotFound: true);
        // Button
        m_Button = asset.FindActionMap("Button", throwIfNotFound: true);
        m_Button_JumpButtton = m_Button.FindAction("JumpButtton", throwIfNotFound: true);
        m_Button_MeleeAttackButton = m_Button.FindAction("MeleeAttackButton", throwIfNotFound: true);
        m_Button_RangedAttackButton = m_Button.FindAction("RangedAttackButton", throwIfNotFound: true);
        m_Button_DashButton = m_Button.FindAction("DashButton", throwIfNotFound: true);
        m_Button_SwitchColor = m_Button.FindAction("SwitchColor", throwIfNotFound: true);
        m_Button_SwitchCharacter = m_Button.FindAction("SwitchCharacter", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Axis
    private readonly InputActionMap m_Axis;
    private IAxisActions m_AxisActionsCallbackInterface;
    private readonly InputAction m_Axis_XAxisMin;
    private readonly InputAction m_Axis_XAxisPlus;
    private readonly InputAction m_Axis_YAxisMin;
    private readonly InputAction m_Axis_YAxisPlus;
    public struct AxisActions
    {
        private @PlayerControlles m_Wrapper;
        public AxisActions(@PlayerControlles wrapper) { m_Wrapper = wrapper; }
        public InputAction @XAxisMin => m_Wrapper.m_Axis_XAxisMin;
        public InputAction @XAxisPlus => m_Wrapper.m_Axis_XAxisPlus;
        public InputAction @YAxisMin => m_Wrapper.m_Axis_YAxisMin;
        public InputAction @YAxisPlus => m_Wrapper.m_Axis_YAxisPlus;
        public InputActionMap Get() { return m_Wrapper.m_Axis; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AxisActions set) { return set.Get(); }
        public void SetCallbacks(IAxisActions instance)
        {
            if (m_Wrapper.m_AxisActionsCallbackInterface != null)
            {
                @XAxisMin.started -= m_Wrapper.m_AxisActionsCallbackInterface.OnXAxisMin;
                @XAxisMin.performed -= m_Wrapper.m_AxisActionsCallbackInterface.OnXAxisMin;
                @XAxisMin.canceled -= m_Wrapper.m_AxisActionsCallbackInterface.OnXAxisMin;
                @XAxisPlus.started -= m_Wrapper.m_AxisActionsCallbackInterface.OnXAxisPlus;
                @XAxisPlus.performed -= m_Wrapper.m_AxisActionsCallbackInterface.OnXAxisPlus;
                @XAxisPlus.canceled -= m_Wrapper.m_AxisActionsCallbackInterface.OnXAxisPlus;
                @YAxisMin.started -= m_Wrapper.m_AxisActionsCallbackInterface.OnYAxisMin;
                @YAxisMin.performed -= m_Wrapper.m_AxisActionsCallbackInterface.OnYAxisMin;
                @YAxisMin.canceled -= m_Wrapper.m_AxisActionsCallbackInterface.OnYAxisMin;
                @YAxisPlus.started -= m_Wrapper.m_AxisActionsCallbackInterface.OnYAxisPlus;
                @YAxisPlus.performed -= m_Wrapper.m_AxisActionsCallbackInterface.OnYAxisPlus;
                @YAxisPlus.canceled -= m_Wrapper.m_AxisActionsCallbackInterface.OnYAxisPlus;
            }
            m_Wrapper.m_AxisActionsCallbackInterface = instance;
            if (instance != null)
            {
                @XAxisMin.started += instance.OnXAxisMin;
                @XAxisMin.performed += instance.OnXAxisMin;
                @XAxisMin.canceled += instance.OnXAxisMin;
                @XAxisPlus.started += instance.OnXAxisPlus;
                @XAxisPlus.performed += instance.OnXAxisPlus;
                @XAxisPlus.canceled += instance.OnXAxisPlus;
                @YAxisMin.started += instance.OnYAxisMin;
                @YAxisMin.performed += instance.OnYAxisMin;
                @YAxisMin.canceled += instance.OnYAxisMin;
                @YAxisPlus.started += instance.OnYAxisPlus;
                @YAxisPlus.performed += instance.OnYAxisPlus;
                @YAxisPlus.canceled += instance.OnYAxisPlus;
            }
        }
    }
    public AxisActions @Axis => new AxisActions(this);

    // Button
    private readonly InputActionMap m_Button;
    private IButtonActions m_ButtonActionsCallbackInterface;
    private readonly InputAction m_Button_JumpButtton;
    private readonly InputAction m_Button_MeleeAttackButton;
    private readonly InputAction m_Button_RangedAttackButton;
    private readonly InputAction m_Button_DashButton;
    private readonly InputAction m_Button_SwitchColor;
    private readonly InputAction m_Button_SwitchCharacter;
    public struct ButtonActions
    {
        private @PlayerControlles m_Wrapper;
        public ButtonActions(@PlayerControlles wrapper) { m_Wrapper = wrapper; }
        public InputAction @JumpButtton => m_Wrapper.m_Button_JumpButtton;
        public InputAction @MeleeAttackButton => m_Wrapper.m_Button_MeleeAttackButton;
        public InputAction @RangedAttackButton => m_Wrapper.m_Button_RangedAttackButton;
        public InputAction @DashButton => m_Wrapper.m_Button_DashButton;
        public InputAction @SwitchColor => m_Wrapper.m_Button_SwitchColor;
        public InputAction @SwitchCharacter => m_Wrapper.m_Button_SwitchCharacter;
        public InputActionMap Get() { return m_Wrapper.m_Button; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ButtonActions set) { return set.Get(); }
        public void SetCallbacks(IButtonActions instance)
        {
            if (m_Wrapper.m_ButtonActionsCallbackInterface != null)
            {
                @JumpButtton.started -= m_Wrapper.m_ButtonActionsCallbackInterface.OnJumpButtton;
                @JumpButtton.performed -= m_Wrapper.m_ButtonActionsCallbackInterface.OnJumpButtton;
                @JumpButtton.canceled -= m_Wrapper.m_ButtonActionsCallbackInterface.OnJumpButtton;
                @MeleeAttackButton.started -= m_Wrapper.m_ButtonActionsCallbackInterface.OnMeleeAttackButton;
                @MeleeAttackButton.performed -= m_Wrapper.m_ButtonActionsCallbackInterface.OnMeleeAttackButton;
                @MeleeAttackButton.canceled -= m_Wrapper.m_ButtonActionsCallbackInterface.OnMeleeAttackButton;
                @RangedAttackButton.started -= m_Wrapper.m_ButtonActionsCallbackInterface.OnRangedAttackButton;
                @RangedAttackButton.performed -= m_Wrapper.m_ButtonActionsCallbackInterface.OnRangedAttackButton;
                @RangedAttackButton.canceled -= m_Wrapper.m_ButtonActionsCallbackInterface.OnRangedAttackButton;
                @DashButton.started -= m_Wrapper.m_ButtonActionsCallbackInterface.OnDashButton;
                @DashButton.performed -= m_Wrapper.m_ButtonActionsCallbackInterface.OnDashButton;
                @DashButton.canceled -= m_Wrapper.m_ButtonActionsCallbackInterface.OnDashButton;
                @SwitchColor.started -= m_Wrapper.m_ButtonActionsCallbackInterface.OnSwitchColor;
                @SwitchColor.performed -= m_Wrapper.m_ButtonActionsCallbackInterface.OnSwitchColor;
                @SwitchColor.canceled -= m_Wrapper.m_ButtonActionsCallbackInterface.OnSwitchColor;
                @SwitchCharacter.started -= m_Wrapper.m_ButtonActionsCallbackInterface.OnSwitchCharacter;
                @SwitchCharacter.performed -= m_Wrapper.m_ButtonActionsCallbackInterface.OnSwitchCharacter;
                @SwitchCharacter.canceled -= m_Wrapper.m_ButtonActionsCallbackInterface.OnSwitchCharacter;
            }
            m_Wrapper.m_ButtonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JumpButtton.started += instance.OnJumpButtton;
                @JumpButtton.performed += instance.OnJumpButtton;
                @JumpButtton.canceled += instance.OnJumpButtton;
                @MeleeAttackButton.started += instance.OnMeleeAttackButton;
                @MeleeAttackButton.performed += instance.OnMeleeAttackButton;
                @MeleeAttackButton.canceled += instance.OnMeleeAttackButton;
                @RangedAttackButton.started += instance.OnRangedAttackButton;
                @RangedAttackButton.performed += instance.OnRangedAttackButton;
                @RangedAttackButton.canceled += instance.OnRangedAttackButton;
                @DashButton.started += instance.OnDashButton;
                @DashButton.performed += instance.OnDashButton;
                @DashButton.canceled += instance.OnDashButton;
                @SwitchColor.started += instance.OnSwitchColor;
                @SwitchColor.performed += instance.OnSwitchColor;
                @SwitchColor.canceled += instance.OnSwitchColor;
                @SwitchCharacter.started += instance.OnSwitchCharacter;
                @SwitchCharacter.performed += instance.OnSwitchCharacter;
                @SwitchCharacter.canceled += instance.OnSwitchCharacter;
            }
        }
    }
    public ButtonActions @Button => new ButtonActions(this);
    public interface IAxisActions
    {
        void OnXAxisMin(InputAction.CallbackContext context);
        void OnXAxisPlus(InputAction.CallbackContext context);
        void OnYAxisMin(InputAction.CallbackContext context);
        void OnYAxisPlus(InputAction.CallbackContext context);
    }
    public interface IButtonActions
    {
        void OnJumpButtton(InputAction.CallbackContext context);
        void OnMeleeAttackButton(InputAction.CallbackContext context);
        void OnRangedAttackButton(InputAction.CallbackContext context);
        void OnDashButton(InputAction.CallbackContext context);
        void OnSwitchColor(InputAction.CallbackContext context);
        void OnSwitchCharacter(InputAction.CallbackContext context);
    }
}
