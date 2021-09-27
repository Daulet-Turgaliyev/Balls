
    using System;
    using Mirror;
    using TMPro;
    using UnityEngine;

    public class PlayerInteraction : NetworkBehaviour
    {
        private BallInteraction _detectedBallInteraction;
        private BallInteraction _ballInHand;

        private UIContainer _uiContainer;

        [SerializeField] 
        private TextMeshProUGUI tipsText;

        [SerializeField] 
        private TextMeshProUGUI ballStatus;

        [SerializeField] 
        private PlayerDate playerDate;


        public void SetUIContainer(UIContainer uiContainer)
        {
            _uiContainer = uiContainer;
            UpdateUiContainer();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out BallInteraction ball))
            {
                _detectedBallInteraction = ball;
                if (_ballInHand == null)
                    tipsText.SetText($"Заряд мяча: {ball.ballDate.GetElectricCharge}.\n<size=\"40%\">Нажмите E чтобы поднять мяч");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.GetComponent<BallInteraction>())
            {
                _detectedBallInteraction = null;
                tipsText.text = null;
            }
        }


        private void TakeBall()
        {
            if (_ballInHand != null) return;
            if(_detectedBallInteraction == null) return;
            _ballInHand = _detectedBallInteraction;
            _detectedBallInteraction.AttachToPlayer(transform, playerDate);
            UpdateBallStatus();
            tipsText.SetText("Нажмите ЛКМ для броска мяча");
        }

        private void DropBall()
        {
            if (_ballInHand == null) return;
            _ballInHand.ClearToPlayer(transform, 170);
            _ballInHand = null;
            _detectedBallInteraction = null;
            tipsText.text = null;
            UpdateBallStatus();
        }
        
        private void OnEnable()
        {
            MainInputController.Instance.OnTapUse += TakeBall;
            MainInputController.Instance.OnClick += DropBall;

            // playerDate.OnDamaged += UpdateStatus;
        }

        private void OnDisable()
        {
            MainInputController.Instance.OnTapUse -= TakeBall;
            MainInputController.Instance.OnClick -= DropBall;

            //playerDate.OnDamaged = null;
        }

        public void UpdateUiContainer()
        {
            if (_uiContainer == null) return;
            _uiContainer.HealthText.SetText(playerDate.GetHealth.ToString());
            _uiContainer.ElectricText.SetText(playerDate.GetElectricCharge.ToString());
            _uiContainer.HealthSlider.value = playerDate.GetHealth;
        }

        private void Update()
        {
            UpdateBallStatus();
            UpdateUiContainer();
        }

        public void UpdateBallStatus()
        {
            if (_ballInHand != null)
            {
                ballStatus.SetText($"Мяч\nЗаряд мяча: {_ballInHand.ballDate.GetElectricCharge}");
            }
            else
            {
                ballStatus.text = null;
            }
        }
    }
