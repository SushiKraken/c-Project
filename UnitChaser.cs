using System;

namespace Gamez2
{ 
    class UnitChaser : MultipleUnitBase
    {
        public double hpPercentLevel { get; set; }

        public UnitChaser
    (
        int currentWaveMultiplification
    )
        {
            int basicDamage = 1;
            int basicHealth = 5;
            double basicMovementSpeed = 1;


            this.Damage = basicDamage + 1 / 5;
            this.MovementSpeed = basicMovementSpeed + 0.2 * currentWaveMultiplification;
            this.MaxHealth = basicHealth + currentWaveMultiplification;
            this.CurrentHealth = base.MaxHealth;
            this.CurrentAngle = 0;
        }

        public void Pathfinding(double playersX, double playersY)
        {
            this.AngleChanges = true;
            double newAngle = SetunitAngle
            (
            SetDiffX(playersX),
            SetDiffY(playersY),
            this.CurrentAngle,
            this.AngleChanges
            );

            this.CurrentAngle = newAngle;

            this.CurrentVectorX = SetVectorX(base.MovementSpeed, CurrentAngle);
            this.CurrentVectorY = SetVectorY(base.MovementSpeed, CurrentAngle);
        }

        private double SetDiffX(double playersX)
        {
            double vectorX;

            vectorX = playersX - CurrentPositionX;

            return vectorX;
        }

        private double SetDiffY(double playersY)
        {
            double vectorY;

            vectorY = playersY - CurrentPositionY;

            return vectorY;
        }


        private double SetVectorX(double UnitSpeed, double angle)
        {
            double point = 0;
            point =  UnitSpeed * Math.Cos(angle);
            return point;
        }

        private double SetVectorY(double UnitSpeed, double angle)
        {
            double point = 0;
            point =  - UnitSpeed * Math.Sin(angle);
            return point;
        }

        private double SetunitAngle(double V_status, double H_status, double Current_Angle, bool angle_changes)
        {
            double newAngle = Current_Angle;
            if (angle_changes)
            {
                if (H_status < 0 && V_status < 0)
                    newAngle = Math.Atan2(-V_status, -H_status) * (180 / Math.PI) + 270;
                else
                    newAngle = Math.Atan2(V_status, H_status) * (180 / Math.PI) + 90;

            }
            return newAngle;
        }


    }
}
