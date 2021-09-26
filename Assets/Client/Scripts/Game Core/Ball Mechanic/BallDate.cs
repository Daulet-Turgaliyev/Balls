    using Mirror;
    using UnityEngine;

    public class BallDate: NetworkBehaviour, IElectricDate
    {
        [SyncVar] 
        private int _electricCharge;
        public int GetElectricCharge => _electricCharge;

        private void Awake()
        {
            var randElectricCharge = Random.Range(-100, 100);
            SetElectricCharge(randElectricCharge);
        }

        public void SetElectricCharge(int electricCharge)
        {
            _electricCharge = electricCharge;
        }

        public void ChangingCharge(int changes)
        {
            _electricCharge -= changes;
            var newElectricCharge = Mathf.Clamp(_electricCharge, -200, 200);
            _electricCharge = newElectricCharge;
        }
    }
