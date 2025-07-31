using System;
using UnityEngine;
using UnityEngine.UI;

// based on https://gist.github.com/jmbeach/78c3e46669db89628fce
namespace _ROOT.Utilities
{
    public class BetterToggleGroup : ToggleGroup {

        public Action<Toggle> OnChangeToggle;
        public Action<int> OnChangeIndex;
  
        protected override void Start() {
            base.Start();
            ManageListening(true);
        }

        private void ManageListening(bool listen) {
    
            int count = 0;
            foreach (Transform transformToggle in gameObject.transform) {
                count += 1;
                Toggle toggle = transformToggle.gameObject.GetComponent<Toggle>();
                if (listen) {
                    toggle.onValueChanged.AddListener(OnTog);
                }
                else {
                    toggle.onValueChanged.RemoveListener(OnTog);
                }
            }
            if (count == 0) {
                Debug.LogWarning("No Toggles found in Children. Is your scene set up correctly ?");
            }
        }
  
        private void OnTog(bool isSelected) {
            if (isSelected) {
                OnChangeToggle?.Invoke(FirstActiveToggle());
                OnChangeIndex?.Invoke(FirstActiveToggleIndex());
            }
        }
  
        public Toggle FirstActiveToggle() {
            foreach (Toggle t in ActiveToggles()) {
                return t;
            }
            return null;
        }

        public int FirstActiveToggleIndex()
        {
            return m_Toggles.IndexOf(FirstActiveToggle());
        }
    }
}