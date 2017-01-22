using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 IntersectionRange(this Vector2 vec, Vector2 otherVec)
    {
        int x = (int)Mathf.Max(vec.x, otherVec.x);
        int y = (int)Mathf.Min(vec.y - 1, otherVec.y - 1) - x + 1;
        return new Vector2(x, y);
    }

    public static float ToAngle(this Vector2 dir)
    {
        /*if(dir.x==0){
            if(dir.y>0) return 90;
            else if(dir.y<0) return 270;
            else return 0;
        }
        else if(dir.y==0){
            if(dir.x>0) return 0;
            else if(dir.x<0) return 180;
            else return 0;
        }*/

        float h = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
        float angle = Mathf.Asin(dir.y / h) * Mathf.Rad2Deg;

        if (dir.y > 0) {
            if (dir.x < 0) angle = 180 - angle;
        }
        else {
            if (dir.x > 0) angle = 360 + angle;
            if (dir.x < 0) angle = 180 - angle;
        }

        if (angle == 360) angle = 0;

        while (angle > 360) angle -= 360;
        while (angle < 0) angle += 360;

        return angle;
    }
}
