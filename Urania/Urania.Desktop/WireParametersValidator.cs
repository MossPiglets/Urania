using FluentValidation;

namespace Urania.Desktop {
    public class WireParametersValidator: AbstractValidator<WireParameters> {
        public WireParametersValidator() {
            When(a => a.Ar != null, () => {
                RuleFor(a => a.Ar)
                    .GreaterThan(0)
                    .WithMessage("AR musi być większy od 0");
            }).Otherwise(() => {
                RuleFor(a => a.Ar).Null();
            });
            When(a => a.Id != null, () => {
                RuleFor(a => a.Id)
                    .GreaterThan(0)
                    .WithMessage("ID musi być większy od 0");
                RuleFor(a => a.Od)
                    .GreaterThan(a => a.Id)
                    .WithMessage("OD musi byc większe niż ID");
            });
            When(a => a.Od != null, () => {
                RuleFor(a => a.Od)
                    .GreaterThan(0)
                    .WithMessage("OD musi być większy od 0");
                RuleFor(a => a.Id)
                    .LessThan(a => a.Od)
                    .WithMessage("ID musi być mniejsze niż OD");
            });
            When(a => a.Wd != null, () => {
                RuleFor(a => a.Wd)
                    .GreaterThan(0)
                    .WithMessage("WD musi być większy od 0");
                RuleFor(a => a.Od)
                    .GreaterThan(a => a.Wd * 2)
                    .WithMessage("OD musi być większe niż dwukrotność WD");
            });
        }
    }
}