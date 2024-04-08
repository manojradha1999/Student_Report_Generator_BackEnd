namespace StudentMarks.BusinessLogic
{
    public class ResultCalculation
    {
        private static readonly int passMark = 35;

        // Calculation for Pass/Fail
        public static string GetResult(int mark)
        {
            return mark > passMark ? "Pass" : "Fail";
        }
    }
}
