using System.Collections.Generic;
using Newtonsoft.Json;

namespace IntegrityVerification
{
    class TrackedObject
    {
        [JsonProperty]
        public string path { get; private set; }

        public List<string> hashes { get; set; } = new List<string>();

        public TrackedObject(string path)
        {
            this.path = path;
        }

        public TrackedObject(string path, string hash)
        {
            this.path = path;
            this.hashes.Add(hash);
        }

        [JsonConstructor]
        public TrackedObject(string path, List<string> hahes)
        {
            this.path = path;
            this.hashes = hahes;
        }
    }
}
