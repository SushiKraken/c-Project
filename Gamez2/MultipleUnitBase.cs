
namespace Gamez2
{
    //-- ustawia początkowe położenie pocisku
   abstract class MultipleUnitBase
    {
        public double CurrentPositionX { get; set; }
        public double CurrentPositionY { get; set; }
        public double CurrentVectorX { get; set; }
        public double CurrentVectorY { get; set; }
        public int Damage { get; set; }
        public double MovementSpeed { get; set; }
        public double Height { get; set; }
        public double Widht { get; set; }
        public double BulletSpeed { get; set; }
        public double BulletRatio { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public double CurrentAngle { get; set; }
        public bool AngleChanges { get; set; }
        public bool createdInArea { get; set; }
        public bool SettoRemove { get; set; }

    }
}
