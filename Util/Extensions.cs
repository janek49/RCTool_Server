using System;

namespace RCTool_Server.Util
{
    public static class Extensions
    {
        public static T[] ExtCopyRange<T>(this T[] bytes, long start, long length)
        {
            var tmp = new T[length];
            Array.Copy(bytes, start, tmp, 0, length);
            return tmp;
        }
    }
}
