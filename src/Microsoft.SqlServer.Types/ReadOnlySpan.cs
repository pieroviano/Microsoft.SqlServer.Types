using System.Linq;
using System.Threading;

#if NET35 || NET40

namespace System
{
    internal class ReadOnlySpan<T> : List<T>
    {

        public ReadOnlySpan(IEnumerable<T> collection) : base(collection)
        {
        }

        public int Length => Count;

        public ReadOnlySpan<T> Slice(int start, int index)
        {
            return new ReadOnlySpan<T>(this.Skip(start - 1).Take(index));
        }

        public static implicit operator ReadOnlySpan<T>(T[] c)
        {
            return new ReadOnlySpan<T>(c);
        }
    }
}

#endif