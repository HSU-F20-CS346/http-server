using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace http_server.RouteHandlers
{
    public class GetRouteHandler : IRouteHandler
    {
        /// <summary>
        /// Sets the MIME type in the response header based on the file requested.  See
        /// <see cref="https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types "/> for 
        /// a list of MIME types
        /// </summary>
        /// <param name="file"></param>
        /// <param name="header"></param>
        private void SetMimeType(string file, ResponseHeader header)
        {
            //PA3 TODO: Set mime type based on file extension
            header.ContentType = ContentType.HTML;
        }

        /// <summary>
        /// Constructs the appropriate response based on the supplied RequestHeader
        /// </summary>
        /// <param name="header"></param>
        /// <param name="response"></param>
        public void HandleRoute(RequestHeader header, Response response)
        {
            //predefined routes
            if (header.Route == "/echo")
            {
                //for debugging
                response.SetBody(header.ToString());
            }
            else if (header.Route == "/")
            {
                response.SetBody(File.ReadAllText(Constants.DEFAULT_ROUTE));
            }
            else
            {
                if (header.Route.Length > 0)
                {
                    //PA 3 TODO: fetch the file from the file system and attach it
                    //in either TEXT or BINIARY form depending on file type.  Text-based
                    //files will be TEXT (e.g. HTML, CSS, JavaScript, etc.) whereas everything
                    //else would be BINARY.  
                    //Functions that you might find helpful:
                    //Path.Join for locating the file on your file system (NO HARD CODING!)
                    //File.ReadAllBytes for reading BINARY files
                    //File.ReadAllText for reading TEXT files
                    //SetMimeType (see above) for correctly setting the MIME type of your response
                }
                else
                {
                    //404 not found
                    response.Header.ResponseCode = 404;
                    response.SetBody(File.ReadAllText(Constants.ERROR_404));
                }
            }
        }
    }
}
