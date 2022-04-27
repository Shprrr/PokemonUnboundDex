using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PokemonUnboundDex.Resources
{
    static class ResourceReader
    {
        public static string[] ReadResourcePerLine(string resourceName)
        {
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            using StreamReader streamReader = new(resourceStream);

            List<string> resourcePerLine = new();
            while (!streamReader.EndOfStream)
            {
                resourcePerLine.Add(streamReader.ReadLine());
            }

            return resourcePerLine.ToArray();
        }
    }
}
