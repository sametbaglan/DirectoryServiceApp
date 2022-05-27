using System;

namespace Directory.Core.Exceptions
{
    public class ClientSideException:Exception
    {
        public ClientSideException(string message):base(message)
        {

        }
    }
}
