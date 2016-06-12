using System;

namespace Gamez2
{
    class AngleControler
    {

        // wyznacza zwrot jednostki
        public static double SetPlayerAngle(double V_status, double H_status, double Current_Angle, bool angle_changes)
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
