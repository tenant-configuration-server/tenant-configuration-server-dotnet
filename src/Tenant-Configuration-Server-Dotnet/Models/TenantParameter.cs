using System;

namespace Tenant_Configuration_Server_Dotnet.Models {
    public class TenantParameter<T> where T : ITenantParameter, new () {
        public T GetInstance () {
            return new T ();
        }
    }
}