namespace Tenant_Configuration_Server_Dotnet.Models
{
    public class Tenant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}