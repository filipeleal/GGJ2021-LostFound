// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/EscInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @EscInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @EscInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EscInput"",
    ""maps"": [
        {
            ""name"": ""Esc"",
            ""id"": ""fb6e0447-33cd-4fa6-b953-e5cb195ed005"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""398c0099-c0a2-4b56-90a0-9a890dade495"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eb873b7a-eee6-4f5c-bbe7-af07b6a0f69b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Esc
        m_Esc = asset.FindActionMap("Esc", throwIfNotFound: true);
        m_Esc_Newaction = m_Esc.FindAction("New action", throwIfNotFound: true);
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

    // Esc
    private readonly InputActionMap m_Esc;
    private IEscActions m_EscActionsCallbackInterface;
    private readonly InputAction m_Esc_Newaction;
    public struct EscActions
    {
        private @EscInput m_Wrapper;
        public EscActions(@EscInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Esc_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Esc; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EscActions set) { return set.Get(); }
        public void SetCallbacks(IEscActions instance)
        {
            if (m_Wrapper.m_EscActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_EscActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_EscActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_EscActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_EscActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public EscActions @Esc => new EscActions(this);
    public interface IEscActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
