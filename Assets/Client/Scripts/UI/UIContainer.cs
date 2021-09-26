
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    [Serializable]
    public class UIContainer
    {
        [field:SerializeField] 
        public TextMeshProUGUI HealthText { get; private set; }
        
        [field:SerializeField] 
        public Slider HealthSlider { get; private set; }
        
        [field:SerializeField] 
        public TextMeshProUGUI ElectricText { get; private set; }
    }
