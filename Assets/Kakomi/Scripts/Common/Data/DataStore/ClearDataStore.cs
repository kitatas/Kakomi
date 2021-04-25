using Kakomi.Common.Application;

namespace Kakomi.Common.Data.DataStore
{
    public sealed class ClearDataStore
    {
        public static bool[] GetDefaultData()
        {
            var clearData = new bool[GameData.STAGE_DATA_COUNT];
            for (int i = 0; i < clearData.Length; i++)
            {
                clearData[i] = false;
            }

            return clearData;
        }
    }
}