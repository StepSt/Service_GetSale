using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service_GetSale
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetIDprocedure?IDshop={IDshop}&IDuser={IDuser}",
            BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        int GetIDprocedure(int IDshop, int IDuser);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSale?IDproc={IDproc}",
            BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        int GetSale(int IDproc);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PostUserResult?IDproc={IDproc}",
            BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void PostUserResult(int IDproc);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PostShopResult?IDproc={IDproc}",
            BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void PostShopResult(int IDproc);

    }
}
