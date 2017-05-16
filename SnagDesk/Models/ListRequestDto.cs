using SnagDesk.Validation;

namespace SnagDesk.Models
{
    public abstract class ListRequestDto
    {
        protected ListRequestDto()
        {
            PageSize = 20;
            PageNumber = 1;
        }

        [IntValue(IntValueEquation.Greater, 0, ErrorMessage = "Page size must be greater than zero.")]
        public int PageSize { get; set; }

        [IntValue(IntValueEquation.Greater, 0, ErrorMessage = "Page number must be greater than zero.")]
        public int PageNumber { get; set; }
    }
}