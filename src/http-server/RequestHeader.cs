using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace http_server
{
    
    public class RequestHeader
    {
        public RequestMethod Method { get; set; }
        public string Route { get; set; }

        public RequestHeader()
        {
            Method = RequestMethod.Unknown;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Method.ToString(), Route);
        }

        public static RequestHeader FromString(string rawHeader)
        {
            RequestHeader header = new RequestHeader();

            //https://regexr.com/ is a great site for testing new REGEX
            Regex methodPattern = new Regex(@"GET ([\/\w\d.]*)", RegexOptions.Compiled);
            var methodMatch = methodPattern.Match(rawHeader);
            if(methodMatch.Success == true)
            {
                header.Method = RequestMethod.GET;
                header.Route = methodMatch.Groups[1].Value;
            }

            //PA3 TODO: implement POST handling.  You can use Wireshark to reverse-engineer 
            //POST parameters (this is what I did for GET).  Alternatively, use the debugger
            //and inspect the variable "requestHeaderString" inside HttpServer.cs

            return header;
        }
    }
}
