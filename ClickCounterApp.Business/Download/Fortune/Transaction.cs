using ClickCounterApp.WebModels.Fortune;

namespace ClickCounterApp.Business.Download.Fortune
{
    public class Transaction
    {
        public class Execute : IGenericRequest
        {
            public Messages GetFortune(string previousId)
            {
                return new Transactions.Request().Execute(previousId);
            }
        }
    }
}
