using System;

namespace Gamez2
{
    class BulletsObject : MultipleUnitBase
    {
        
        public BulletsObject
        (
          double playerCurrentPositionX,
          double playerCurrentPositionY,
          int playerCurrentDamage,
          double playerCurrentBulletSpeed,
          double playersWidth,
          double playersHeight,
          double playersAngle
        )
        {
            this.CurrentPositionX = SetOriginX
            (
                playerCurrentPositionX,
                playersWidth,
                playersAngle
            );

            this.CurrentPositionY = SetOriginY
            (
                playerCurrentPositionY,
                playersHeight,
                playersAngle
            );
            this.createdInArea = false;

            this.CurrentVectorX = SetVectorX(playerCurrentBulletSpeed, playersAngle);
            this.CurrentVectorY = SetVectorY(playerCurrentBulletSpeed, playersAngle);
        }





        public double SetOriginX(double playersX, double playersWidth, double angle)
        {
            double point = 0;
            point = playersX + playersWidth / 4;
            return point;
        }

        public double SetOriginY(double playersY, double playersHeight, double angle)
        {
            double point = 0;
            point = playersY + playersHeight / 4;
            return point;
        }

        public double SetVectorX(double bulletSpeed, double angle)
        {
            double point = 0;
            point = bulletSpeed * Math.Cos(angle);
            return point;
        }

        public double SetVectorY(double bulletSpeed, double angle)
        {
            double point = 0;
            point = bulletSpeed * Math.Sin(angle);
            return point;
        }

    }
}
