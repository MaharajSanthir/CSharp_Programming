using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Orwell_S_E_FruityMart
{
    static public class SerializationUtility
    {

        /// <summary>
        /// Send your objects to a stream. 
        /// </summary>
        /// <param name="rootObject">The object to save (including all its composited objects)</param>
        /// <returns>A stream with the serialized objects.</returns>
        /// 
        static public Stream SerializeObjectGraphToMemory(object rootObject)
        {
            if (ReferenceEquals(null, rootObject))
                throw new ArgumentNullException("rootObject", "please provide an object to serialize");
            MemoryStream mem = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(mem, rootObject);
            mem.Position = 0;
            return mem;
        }

        /// <summary>
        /// Reconstitute your objects from a stream. 
        /// </summary>
        /// <typeparam name="TRoot">The type of the object exptected</typeparam>
        /// <param name="s">The stream containing the objects.</param>
        /// <returns>The object including all its composited objects.</returns>
        /// 
        static public TRoot DeserializeObjectGraphFromStream<TRoot>(Stream s) where TRoot : class
        {
            if (ReferenceEquals(null, s))
                throw new ArgumentNullException("s", "Please provide a stream to deserialize");
            BinaryFormatter serializer = new BinaryFormatter();
            s.Position = 0;
            object o = serializer.Deserialize(s);
            return o as TRoot;
        }
    }
}
