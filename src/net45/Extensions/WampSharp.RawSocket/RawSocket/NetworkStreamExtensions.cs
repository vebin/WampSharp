using System;
using System.IO;
using System.Threading.Tasks;

namespace WampSharp.RawSocket
{
    internal static class NetworkStreamExtensions
    {
        public static Task ReadExactAsync(this Stream networkStream, byte[] buffer, int position = 0)
        {
            return networkStream.ReadExactAsync(buffer, position, buffer.Length);
        }

        public async static Task ReadExactAsync(this Stream networkStream, byte[] buffer, int position, int length)
        {
            int currentPosition = position;
            int readBytes = 0;

            while (readBytes != length)
            {
                int currentlyRead = await networkStream.ReadAsync(buffer, currentPosition, length - readBytes).ConfigureAwait(false);

                // If we read 0 bytes, we have reached the end of the stream.
                if (currentlyRead == 0)
                {
                    throw new EndOfStreamException();
                }

                readBytes += currentlyRead;
                currentPosition += currentlyRead;
            }
        }

#if NETSTANDARD1_4

        // TODO: Move to a different class
        public static byte[] GetBuffer(this MemoryStream stream)
        {
            ArraySegment<byte> result;
            stream.TryGetBuffer(out result);
            return result.Array;
        }

#endif
    }
}