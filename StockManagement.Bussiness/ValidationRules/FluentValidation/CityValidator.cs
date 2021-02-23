using FluentValidation;
using StockManagement.Entities.Dto;

namespace StockManagement.Business.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<CityDto>
    {
        /// <summary>
        /// Burada City İle ilgili Validation Kuralları yazılır.
        /// Sehir adı boş olamaz. En az 2 karakter olmalıdır..
        /// </summary>
        public CityValidator()
        {
            RuleFor(c => c.CityName).NotEmpty();
            RuleFor(c => c.CityName).MinimumLength(2);

        }
    }
}
