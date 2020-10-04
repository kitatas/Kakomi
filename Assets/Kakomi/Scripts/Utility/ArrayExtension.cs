namespace Kakomi.Utility
{
    public static class ArrayExtension
    {
        public static int GetMaxIndex<T>(this T[] array)
        {
            return array.Length - 1;
        }

        public static T GetLastParam<T>(this T[] array)
        {
            return array[array.GetMaxIndex()];
        }
    }
}