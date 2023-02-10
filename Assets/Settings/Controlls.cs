//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Settings/Controlls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controlls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controlls"",
    ""maps"": [
        {
            ""name"": ""CharacterControl"",
            ""id"": ""9537291a-e861-4646-bf87-0058c18f678d"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""51cf259c-40bf-4865-b2e1-fa5a85035ddf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Cam_Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""1e5ffe56-0638-471c-8053-8646f9f2d335"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Action_Button"",
                    ""type"": ""Button"",
                    ""id"": ""ba7ba1ea-819d-422f-9184-07e0af81bc2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu_Button"",
                    ""type"": ""Button"",
                    ""id"": ""9f063dd1-a26b-45c8-9638-82bd08ee4a5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""55b57e35-7f0a-4614-9147-7fb3a8562afa"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2d9bd2e7-e013-4432-9fb8-da0207438d64"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c01f2e16-ffc9-4f88-ae0f-57553deaf6b3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bd9a41a3-a6dd-4a70-8f5b-3885523430f3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c18118a2-8fa1-4122-b940-37ae3347b028"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c2bc11aa-0169-4a8e-bfe2-bfdd71f91103"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6bb447b4-ceaf-4705-94df-5517681c2476"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=2,y=2)"",
                    ""groups"": """",
                    ""action"": ""Cam_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""a1ab2b8d-9c2c-4b0d-89a3-3efa669480c3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=4,y=4)"",
                    ""groups"": """",
                    ""action"": ""Cam_Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a95c6dd6-d8a8-4244-894b-3df5c780b054"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b3f971d2-ff1f-41c1-b609-d695d42d95d8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4c617453-f97f-418e-a2cd-c8101ccaa431"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8b793dd5-6646-4260-a902-6d274dca2d06"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dad21279-d540-4127-9fe8-666a3df0e1d5"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3de5702c-3a9d-49a0-b268-af8e46054b22"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74f2b9a5-e5ca-42b7-aa9c-0b8ef3099bee"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c4c78de-e060-4797-a78a-9bc2696ea802"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f20eb49d-3cb5-49ac-9b09-7d0b3941fd7c"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControl
        m_CharacterControl = asset.FindActionMap("CharacterControl", throwIfNotFound: true);
        m_CharacterControl_Walk = m_CharacterControl.FindAction("Walk", throwIfNotFound: true);
        m_CharacterControl_Cam_Rotation = m_CharacterControl.FindAction("Cam_Rotation", throwIfNotFound: true);
        m_CharacterControl_Action_Button = m_CharacterControl.FindAction("Action_Button", throwIfNotFound: true);
        m_CharacterControl_Menu_Button = m_CharacterControl.FindAction("Menu_Button", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CharacterControl
    private readonly InputActionMap m_CharacterControl;
    private ICharacterControlActions m_CharacterControlActionsCallbackInterface;
    private readonly InputAction m_CharacterControl_Walk;
    private readonly InputAction m_CharacterControl_Cam_Rotation;
    private readonly InputAction m_CharacterControl_Action_Button;
    private readonly InputAction m_CharacterControl_Menu_Button;
    public struct CharacterControlActions
    {
        private @Controlls m_Wrapper;
        public CharacterControlActions(@Controlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_CharacterControl_Walk;
        public InputAction @Cam_Rotation => m_Wrapper.m_CharacterControl_Cam_Rotation;
        public InputAction @Action_Button => m_Wrapper.m_CharacterControl_Action_Button;
        public InputAction @Menu_Button => m_Wrapper.m_CharacterControl_Menu_Button;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlActions instance)
        {
            if (m_Wrapper.m_CharacterControlActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnWalk;
                @Cam_Rotation.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnCam_Rotation;
                @Cam_Rotation.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnCam_Rotation;
                @Cam_Rotation.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnCam_Rotation;
                @Action_Button.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnAction_Button;
                @Action_Button.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnAction_Button;
                @Action_Button.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnAction_Button;
                @Menu_Button.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMenu_Button;
                @Menu_Button.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMenu_Button;
                @Menu_Button.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMenu_Button;
            }
            m_Wrapper.m_CharacterControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Cam_Rotation.started += instance.OnCam_Rotation;
                @Cam_Rotation.performed += instance.OnCam_Rotation;
                @Cam_Rotation.canceled += instance.OnCam_Rotation;
                @Action_Button.started += instance.OnAction_Button;
                @Action_Button.performed += instance.OnAction_Button;
                @Action_Button.canceled += instance.OnAction_Button;
                @Menu_Button.started += instance.OnMenu_Button;
                @Menu_Button.performed += instance.OnMenu_Button;
                @Menu_Button.canceled += instance.OnMenu_Button;
            }
        }
    }
    public CharacterControlActions @CharacterControl => new CharacterControlActions(this);
    public interface ICharacterControlActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnCam_Rotation(InputAction.CallbackContext context);
        void OnAction_Button(InputAction.CallbackContext context);
        void OnMenu_Button(InputAction.CallbackContext context);
    }
}
