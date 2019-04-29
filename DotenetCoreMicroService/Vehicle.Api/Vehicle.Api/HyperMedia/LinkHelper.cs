using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.HyperMedia
{
    public class LinkHelper<T> where T : class
    {
        public T Value { get; set; }
        public List<Link> Links { get; set; }

        public LinkHelper()
        {
            Links = new List<Link>();
        }

        public LinkHelper(T item) : base()
        {
            Value = item;
            Links = new List<Link>();
        }

       
    }

    public class Link
    {
        public string Href { get; set; }
        public string Method { get; set; }
    }
}
