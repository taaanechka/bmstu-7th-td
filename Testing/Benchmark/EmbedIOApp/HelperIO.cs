using System.Text;

namespace EmbedIOApp
{
    public class HelperIO
    {
        public static byte[] GetDataBytes(string filename = @"Data\text_heavy.txt")
        {
            string content = File.ReadAllText(filename);

            return Encoding.UTF8.GetBytes(content);
        }
    }
}