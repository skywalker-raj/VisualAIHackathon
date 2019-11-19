namespace HackathonRockstar.PageObject
{
    public class DashboardPageObject
    {
        #region Elements

        public const string CompareExpenseCssSelector = "a#showExpensesChart";
        public const string AmountLabelCssSelector = "th#amount";
        public const string RowValueCssSelector = "table#transactionsTable tbody tr";
        public const string StatusValueCssSelector = "table#transactionsTable tbody tr:nth-child({0}) td.nowrap span:nth-child(2)";
        public const string DateValueCssSelector = "table#transactionsTable tbody tr:nth-child({0}) td:nth-child(2) span";
        public const string AmountValueCssSelector = "table#transactionsTable tbody tr:nth-child({0}) td.bolder span";
        public const string CategoryValueCssSelector = "table#transactionsTable tbody tr:nth-child({0}) td:nth-child(4) a";
        public const string DescriptionValueCssSelector = "table#transactionsTable tbody tr:nth-child({0}) td:nth-child(3) span";
        //Chart Element
        public const string ShowDataForNextYearXPath = "//button[text()='Show data for next year']";
        //Element for Add
        public const string FlashSalesCssSelector = "div.hidden-mobile:nth-child({0}) > img";

        #endregion
    }
}
