using System.Collections.Generic;

namespace thewayshop.ViewModel
{
    public class TypeGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<TypeInfo> Types { get; set; }
    }

    public class TypeInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}