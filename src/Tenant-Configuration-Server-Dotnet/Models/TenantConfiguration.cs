using System;

namespace Tenant_Configuration_Server_Dotnet.Models {
    public class TenantConfiguration {

         private readonly Tenant tenant = null;

        public TenantConfiguration (Tenant tenant) {
            if (tenant == null) {
                throw new ArgumentException ("tenant must not be null");
            }

            this.tenant = tenant;
        }
        
        public Tenant GetTenant { get { return tenant;}  }

    }
}