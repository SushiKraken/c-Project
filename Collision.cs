
namespace Gamez2
{

    
    class WallCollision
    {
        public static bool heroCanMove(double unitLocation, double Loc_object, double unitLineVector, double unitSize, double objectSize)
        {
            bool detect = false;

            if (unitLineVector < 0 && Loc_object < unitLocation) detect = true;
            if (unitLineVector > 0 &&
                (Loc_object + objectSize) > unitLocation + unitSize) detect = true; 
            return detect;
        }

    }
}
