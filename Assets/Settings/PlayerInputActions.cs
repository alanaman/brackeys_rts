//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlaterInputActionMap"",
            ""id"": ""18b4a778-3810-4509-82c3-9d9484d11d2f"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""99fb9f02-113e-4f89-b925-e56eedc0b032"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""2883dd94-1648-4a6e-be33-390619e70fe2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ability"",
                    ""type"": ""Button"",
                    ""id"": ""5f41938b-18f9-4502-940e-377a34e5bf09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""interact"",
                    ""type"": ""Button"",
                    ""id"": ""50a7f05a-de84-4775-be84-2e964ea3a1ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""escape"",
                    ""type"": ""Button"",
                    ""id"": ""10b40eca-9b37-4a9d-a3d2-99b1e4e4afff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wasd"",
                    ""id"": ""35375b1e-e248-4717-bdea-fac86c32d044"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ba15bba5-ba7f-4c4a-ba97-e319b6e0bb08"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d658f9a0-e123-41ad-9d75-235dd1efbbc5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d4198273-8d8e-4499-b9f5-3549abc947ce"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ad56d48e-5540-4d7e-a51a-4d6a7289ef91"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cc9befb8-bc26-44e0-819f-c073d2572e44"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4de29e5-06a5-4285-a141-e6944440d377"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d957d137-8f38-4580-b12a-6d7c77c41b88"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e77c5aa-50b4-4fd1-aec8-e8721de50910"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""650d5b87-7b17-4436-ac31-a125aef3caa0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlaterInputActionMap
        m_PlaterInputActionMap = asset.FindActionMap("PlaterInputActionMap", throwIfNotFound: true);
        m_PlaterInputActionMap_move = m_PlaterInputActionMap.FindAction("move", throwIfNotFound: true);
        m_PlaterInputActionMap_jump = m_PlaterInputActionMap.FindAction("jump", throwIfNotFound: true);
        m_PlaterInputActionMap_ability = m_PlaterInputActionMap.FindAction("ability", throwIfNotFound: true);
        m_PlaterInputActionMap_interact = m_PlaterInputActionMap.FindAction("interact", throwIfNotFound: true);
        m_PlaterInputActionMap_escape = m_PlaterInputActionMap.FindAction("escape", throwIfNotFound: true);
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

    // PlaterInputActionMap
    private readonly InputActionMap m_PlaterInputActionMap;
    private List<IPlaterInputActionMapActions> m_PlaterInputActionMapActionsCallbackInterfaces = new List<IPlaterInputActionMapActions>();
    private readonly InputAction m_PlaterInputActionMap_move;
    private readonly InputAction m_PlaterInputActionMap_jump;
    private readonly InputAction m_PlaterInputActionMap_ability;
    private readonly InputAction m_PlaterInputActionMap_interact;
    private readonly InputAction m_PlaterInputActionMap_escape;
    public struct PlaterInputActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlaterInputActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_PlaterInputActionMap_move;
        public InputAction @jump => m_Wrapper.m_PlaterInputActionMap_jump;
        public InputAction @ability => m_Wrapper.m_PlaterInputActionMap_ability;
        public InputAction @interact => m_Wrapper.m_PlaterInputActionMap_interact;
        public InputAction @escape => m_Wrapper.m_PlaterInputActionMap_escape;
        public InputActionMap Get() { return m_Wrapper.m_PlaterInputActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlaterInputActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlaterInputActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlaterInputActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlaterInputActionMapActionsCallbackInterfaces.Add(instance);
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
            @jump.started += instance.OnJump;
            @jump.performed += instance.OnJump;
            @jump.canceled += instance.OnJump;
            @ability.started += instance.OnAbility;
            @ability.performed += instance.OnAbility;
            @ability.canceled += instance.OnAbility;
            @interact.started += instance.OnInteract;
            @interact.performed += instance.OnInteract;
            @interact.canceled += instance.OnInteract;
            @escape.started += instance.OnEscape;
            @escape.performed += instance.OnEscape;
            @escape.canceled += instance.OnEscape;
        }

        private void UnregisterCallbacks(IPlaterInputActionMapActions instance)
        {
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
            @jump.started -= instance.OnJump;
            @jump.performed -= instance.OnJump;
            @jump.canceled -= instance.OnJump;
            @ability.started -= instance.OnAbility;
            @ability.performed -= instance.OnAbility;
            @ability.canceled -= instance.OnAbility;
            @interact.started -= instance.OnInteract;
            @interact.performed -= instance.OnInteract;
            @interact.canceled -= instance.OnInteract;
            @escape.started -= instance.OnEscape;
            @escape.performed -= instance.OnEscape;
            @escape.canceled -= instance.OnEscape;
        }

        public void RemoveCallbacks(IPlaterInputActionMapActions instance)
        {
            if (m_Wrapper.m_PlaterInputActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlaterInputActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlaterInputActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlaterInputActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlaterInputActionMapActions @PlaterInputActionMap => new PlaterInputActionMapActions(this);
    public interface IPlaterInputActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
