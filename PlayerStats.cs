
namespace Gamez2
{
    class PlayerStats : MultipleUnitBase
    {
        public int PlayersHP { get; set; } 
        public PlayerStats
        (
            double initOriginX,
            double initOriginY,
            int initHP,
            int initDamage,
            double initSpeed,
            double initBulletSpeed
        )
        {
            
        this.CurrentPositionX = initOriginX;
        this.CurrentPositionY = initOriginY;
        this.CurrentVectorX = 0;
        this.CurrentVectorY = 0;
        this.Damage = initDamage;
        this.MovementSpeed = initSpeed;
        this.CurrentAngle = 0;
        this.Widht = 50;
        this.Height = 50;

        }

    }
}
