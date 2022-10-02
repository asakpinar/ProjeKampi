using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifre boş geçemezsiniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar mail boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmını  boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
        }
    }
}
