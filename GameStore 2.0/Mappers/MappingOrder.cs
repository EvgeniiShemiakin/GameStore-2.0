using System.Text;
using GameStore_2._0.Models;

namespace GameStore_2._0.Mappers
{
    public class MappingOrder
    {
        public static string SerializeToString(Dictionary<Guid, GameVM> activationKeys)
        {
            var serializedString = new StringBuilder();
            foreach (var game in activationKeys)
            {
                serializedString.Append($"{game.Key}:{game.Value.Id}|");
            }
            return serializedString.ToString().TrimEnd('|');
        }
        public static Dictionary<Guid, int> DeserializeToInt(string activationKeys)
        {
            var keys = new Dictionary<Guid, int>();
            var keyPairs = activationKeys.Split('|');
            foreach (var keyPair in keyPairs)
            {
                var key = Guid.Parse(keyPair.Split(':')[0]);
                var game = int.Parse(keyPair.Split(':')[1]);
                keys[key] = game;
            }
            return keys;
        }
    }
}
