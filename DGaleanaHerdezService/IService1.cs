using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DGaleanaHerdezService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        DGaleanaHerdezService.Result CambiarDivisas(ML.Producto producto);
    }


    [DataContract]
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public object Object { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
    }
}
