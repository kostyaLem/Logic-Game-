using System.Linq;

namespace NightmareV2
{
    public static class Extenstions
    {
        public static bool IsNot(this int value, params int[] notValues)
        {
            return (notValues.Contains(value)) ? false : true;
        }
    }
}
