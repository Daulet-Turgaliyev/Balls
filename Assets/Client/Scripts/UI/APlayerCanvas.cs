using UnityEngine;

    public class APlayerCanvas : MonoBehaviour
    {
        [SerializeField]
        private UIContainer uiContainer;

        [SerializeField] 
        private PlayerInteraction playerInteraction;
        
        public void Init()
        {
            playerInteraction.SetUIContainer(uiContainer);
        }
    }
