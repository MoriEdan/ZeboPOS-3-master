using Zebo.Domain.Models.Accounts;

namespace Zebo.Modules.AccountModule
{
    class DocumentCreationData
    {
        public DocumentCreationData(Account account,AccountTransactionDocumentType documentType)
        {
            Account = account;
            DocumentType = documentType;
        }

        public Account Account { get; set; }
        public AccountTransactionDocumentType DocumentType { get; set; }
    }
}
