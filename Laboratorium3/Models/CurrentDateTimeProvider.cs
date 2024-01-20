using Laboratorium3.Models;

namespace Laboratorium3.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }



    }
}
