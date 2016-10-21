using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageOfID
{
    public class StorageOfID
    {
        Dictionary<Type, Dictionary<Guid, Object>> storageOfGuid = new Dictionary<Type, Dictionary<Guid, Object>>();

        public T Create<T>()
            where T : new()
        {
            T obj = new T();
            if (!storageOfGuid.ContainsKey(typeof(T)))
                storageOfGuid[typeof(T)] = new Dictionary<Guid, Object>();

            storageOfGuid[typeof(T)][Guid.NewGuid()] = obj;

            return obj;
        }

        public Dictionary<Guid, Object> GetPairsByType<T>()
        {
            if (storageOfGuid.ContainsKey(typeof(T)))
                return storageOfGuid[typeof(T)];
            else
                return null;
        }

        public T GetObjectByGuid<T>(Guid guid)
        {
            if (storageOfGuid.ContainsKey(typeof(T)))
                if (storageOfGuid[typeof(T)].ContainsKey(guid))
                    return (T)storageOfGuid[typeof(T)][guid];

            return default(T);
        }

    }
}
