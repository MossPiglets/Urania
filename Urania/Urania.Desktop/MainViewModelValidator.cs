using FluentValidation;

namespace Urania.Desktop {
    public class MainViewModelValidator: AbstractValidator<MainViewModel> {
        public MainViewModelValidator() {
            RuleFor(a => a.WireParameters.Ar)
                .GreaterThan(0)
                .WithMessage("Ar musi być większy od 0");
            RuleFor(a => a.WireParameters.Id)
                .GreaterThan(0)
                .WithMessage("Id musi być większy od 0");
            RuleFor(a => a.WireParameters.Od)
                .GreaterThan(0)
                .WithMessage("Od musi być większy od 0");
            RuleFor(a => a.WireParameters.Wd)
                .GreaterThan(0)
                .WithMessage("Wd musi być większy od 0");
            RuleFor(a => a.WireParameters.Od)
                .GreaterThan(a => a.WireParameters.Wd * 2)
                .WithMessage("Od musi być większe niż 2*Wd");
            RuleFor(a => a.WireParameters.Wd)
                .LessThan(a => a.WireParameters.Od / 2)
                .WithMessage("Wd musi być mniejsze niż połowa Od");
            RuleFor(a => a.WireParameters.Od)
                .GreaterThan(a => a.WireParameters.Id)
                .WithMessage("Od musi byc większe niż Id");
            RuleFor(a => a.WireParameters.Id)
                .LessThan(a => a.WireParameters.Od)
                .WithMessage("Id musi być mniejsze niż Od");
        }
    }
}