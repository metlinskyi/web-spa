namespace TranslationManagement.Api.Domain.Translator;

using Data.Access;
using Data.Management;

internal class TranslatorRepository : Repository<TranslatorRecord>, ITranslatorRepository
{
    public TranslatorRepository(AppDbContext context) : base(context)
    {
    }
}