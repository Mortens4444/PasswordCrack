using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace PasswordCrack.Utils
{
    public static class ResourceHelper
    {
        public static string ReadEmbeddedResource(string resourceName, Encoding encoding)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return ReadEmbeddedResource(resourceName, assembly, encoding);
        }

        public static string ReadEmbeddedResource(string resourceName, Assembly assembly, Encoding encoding)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new ArgumentException($"Resource '{resourceName}' not found.", nameof(resourceName)))
            using (var reader = new StreamReader(stream, encoding))
                return reader.ReadToEnd();
        }
    }

}
