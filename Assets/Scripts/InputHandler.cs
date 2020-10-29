// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputHandler.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputHandler : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputHandler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputHandler"",
    ""maps"": [
        {
            ""name"": ""Standard"",
            ""id"": ""7b1d7e6f-d195-47cd-936c-ba9c39c3766d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0cef3893-5096-4fcf-bbbc-43badc482f6a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""4517691d-9255-4517-9f6d-e0d2db0dbb52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""e6f42536-8f62-4d4f-9e5d-7e3cfa96d1ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FreeCam"",
                    ""type"": ""Value"",
                    ""id"": ""4af6c156-3d6e-46f1-a27d-01b704cfb212"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""97ec6baf-1dbc-444b-ac28-6dc896bf83dc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""deada2b5-2130-4de5-8855-24295954a1f8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d38d88cd-e843-4232-a1a0-d3edb1202403"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""41322e48-8f8c-4cca-b7db-8caff02ab120"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f00ddf25-b664-4eb4-950d-ddb6411fc5bf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e872d5b-127e-4f0e-bab1-7e96047536b9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cd97186-7fa8-4f64-a387-1bed4178b3fd"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2388674f-fbee-4412-9c6d-a145843d62e7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8243e0c-0e1f-45f3-9dae-d4369a417191"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5825190d-9306-4fbc-9a27-89944abfab36"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6eb75e98-3495-4941-85ee-6045b63dacdf"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""FreeCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0903d15-154e-44bc-9bfe-e60b2fb037a3"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.9,max=0.9)"",
                    ""groups"": ""Keyboard"",
                    ""action"": ""FreeCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // Standard
        m_Standard = asset.FindActionMap("Standard", throwIfNotFound: true);
        m_Standard_Movement = m_Standard.FindAction("Movement", throwIfNotFound: true);
        m_Standard_Attack = m_Standard.FindAction("Attack", throwIfNotFound: true);
        m_Standard_Target = m_Standard.FindAction("Target", throwIfNotFound: true);
        m_Standard_FreeCam = m_Standard.FindAction("FreeCam", throwIfNotFound: true);
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

    // Standard
    private readonly InputActionMap m_Standard;
    private IStandardActions m_StandardActionsCallbackInterface;
    private readonly InputAction m_Standard_Movement;
    private readonly InputAction m_Standard_Attack;
    private readonly InputAction m_Standard_Target;
    private readonly InputAction m_Standard_FreeCam;
    public struct StandardActions
    {
        private @InputHandler m_Wrapper;
        public StandardActions(@InputHandler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Standard_Movement;
        public InputAction @Attack => m_Wrapper.m_Standard_Attack;
        public InputAction @Target => m_Wrapper.m_Standard_Target;
        public InputAction @FreeCam => m_Wrapper.m_Standard_FreeCam;
        public InputActionMap Get() { return m_Wrapper.m_Standard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandardActions set) { return set.Get(); }
        public void SetCallbacks(IStandardActions instance)
        {
            if (m_Wrapper.m_StandardActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_StandardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_StandardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_StandardActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_StandardActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_StandardActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_StandardActionsCallbackInterface.OnAttack;
                @Target.started -= m_Wrapper.m_StandardActionsCallbackInterface.OnTarget;
                @Target.performed -= m_Wrapper.m_StandardActionsCallbackInterface.OnTarget;
                @Target.canceled -= m_Wrapper.m_StandardActionsCallbackInterface.OnTarget;
                @FreeCam.started -= m_Wrapper.m_StandardActionsCallbackInterface.OnFreeCam;
                @FreeCam.performed -= m_Wrapper.m_StandardActionsCallbackInterface.OnFreeCam;
                @FreeCam.canceled -= m_Wrapper.m_StandardActionsCallbackInterface.OnFreeCam;
            }
            m_Wrapper.m_StandardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
                @FreeCam.started += instance.OnFreeCam;
                @FreeCam.performed += instance.OnFreeCam;
                @FreeCam.canceled += instance.OnFreeCam;
            }
        }
    }
    public StandardActions @Standard => new StandardActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IStandardActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnTarget(InputAction.CallbackContext context);
        void OnFreeCam(InputAction.CallbackContext context);
    }
}