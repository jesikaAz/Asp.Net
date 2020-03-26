using System;

namespace OgameLikeTPClassLibrary.Utils
{
    public static class MathUtil
    {
        public static int? FactorialExpression(Func<int?, int?> expression, int? level)
        {
            int? result = null;

            for (int i = 1; i < level + 1; i++)
            {
                result += expression.Invoke(i);
            }

            return result;
        }
    }
}