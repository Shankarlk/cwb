namespace CWB.Masters.ViewModels.OperationList
{
    public class OperationListVM
    {
        public long OperationId { get; set; }

        public bool IsMultiplePartsOfBOMUsed { get; set; }
        public string Operation { get; set; }

        public int TenantId {  get; set; }  
    }
}
