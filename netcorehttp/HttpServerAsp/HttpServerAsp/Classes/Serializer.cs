using HttpServerAsp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HttpServerAsp.Classes
{
	public class Serializer : ISerializer
    {
        public string SerializeJson<T>(T disk)
        {
            return JsonConvert.SerializeObject(disk);
        }

        public T DeserializeJson<T>(string disk)
        {
            return JsonConvert.DeserializeObject<T>(disk);
        }

        private static readonly XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = true
        };

        private static readonly ConcurrentDictionary<Type, XmlSerializer> serializers
            = new ConcurrentDictionary<Type, XmlSerializer>();

        private static readonly XmlSerializerNamespaces ns =
            new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

        public string SerializeXml<T>(T disk)
        {
            using var stream = new StringWriter();
            using var writer = XmlWriter.Create(stream, settings);

            var serializer = serializers.GetOrAdd(typeof(T), CreateSerializer);

            serializer.Serialize(writer, disk, ns);
            return stream.ToString();
        }

        private static XmlSerializer CreateSerializer(Type type) => new XmlSerializer(type);

        public T DeserializeXml<T>(string disk)
        {
            var serializer = serializers.GetOrAdd(typeof(T), CreateSerializer);

            using var reader = new StringReader(disk);
            return (T)serializer.Deserialize(reader);
        }
    }
}
