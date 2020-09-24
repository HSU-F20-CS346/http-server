using System;
using System.Collections.Generic;
using System.Text;

namespace http_server.RouteHandlers
{
    public class PostRouteHandler : IRouteHandler
    {
        public void HandleRoute(RequestHeader header, Response response)
        {
            //PA3 TODO: Implement to get POST routes working.  Use GetRouteHandler.cs as a starting example.
            //Note that in order to properly solve this, you will need to modify RequestHeader.cs function
            //FromString() as POST needs additional data fed into it.
            throw new NotImplementedException();
        }
    }
}
