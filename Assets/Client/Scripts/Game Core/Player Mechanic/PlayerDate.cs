using Mirror;
using UnityEngine;

public class PlayerDate: NetworkBehaviour, IElectricDate
{
    [SyncVar, SerializeField]
    private int _health;
    public int GetHealth => _health;

    //public Action OnDamaged = () => { };
    
    [SyncVar]
    private int _electricCharge;
    public int GetElectricCharge => _electricCharge;

    private PlayerInteraction _playerInteraction;
    
    public void Awake()
    {
        _playerInteraction = GetComponent<PlayerInteraction>();
        _health = 100;
        _electricCharge = 0;
    }

    [Command(requiresAuthority = false)]
    public void ToDamage(int ballElectricCharge, BallInteraction ball)
    {
        //if(ball.IsFree) return;
        int beforeCollision = _electricCharge + ballElectricCharge;
        int afterCollision = beforeCollision / 2;
        int roundAfterCollision = Mathf.RoundToInt(afterCollision);
        
        int dmg = roundAfterCollision - _electricCharge;
        
        ball.ballDate.SetElectricCharge(roundAfterCollision);
        SetElectricCharge(roundAfterCollision);
        
        _health -= Mathf.Abs(dmg);
        
        _playerInteraction.UpdateUiContainer();
        //OnDamaged();
    }
    
    public void SetElectricCharge(int electricCharge)
    {
        _electricCharge = electricCharge;
    }
}