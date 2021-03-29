namespace Elcom.Models.Spec
{
    public enum DelayedPositionStatus {Post, Update}
    
    public class DelayedPositions
    {
        public DelayedPositionStatus Status; // 1
        public string OrderNumber; // 3
        public int LineNumber; // 4
        public string DelayedDaysQty; // 12
        public string SupplementaryText5; // 15
        public bool Active = true; // 19

        public DelayedPositions(DelayedPositionStatus status, string orderNumber, int lineNumber, string delayedDaysQty, string supplementaryText5)
        {
            Status = status;
            OrderNumber = orderNumber;
            LineNumber = lineNumber;
            DelayedDaysQty = delayedDaysQty;
            SupplementaryText5 = supplementaryText5;
        }
        
        public bool IsRowUpdated()
        {
            var command = new TextCommand(string.Format(@" select 1 from orderline where ordernumber = {0} and linenumber= {1} and supplementarytext5 like '%{2}%'", OrderNumber, LineNumber, "LETTER"));
            var caller = new DbCaller(command);
            caller.DoWork();
            return !(caller.GetResult() is null);
        }
    }
}