using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Account1
    {
        public Account1()
        {
            AccountStatements = new HashSet<AccountStatement>();
            B2bTransactionCreditAccounts = new HashSet<B2bTransaction>();
            B2bTransactionDebitAccounts = new HashSet<B2bTransaction>();
            B2pTransactions = new HashSet<B2pTransaction>();
            TransferOrders = new HashSet<TransferOrder>();
        }

        public int AccountId { get; set; }
        public int? BankId { get; set; }
        public int? AccountTypeId { get; set; }
        public string AccountCode { get; set; }
        public string Currency { get; set; }
        public string Iban { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual ICollection<AccountStatement> AccountStatements { get; set; }
        public virtual ICollection<B2bTransaction> B2bTransactionCreditAccounts { get; set; }
        public virtual ICollection<B2bTransaction> B2bTransactionDebitAccounts { get; set; }
        public virtual ICollection<B2pTransaction> B2pTransactions { get; set; }
        public virtual ICollection<TransferOrder> TransferOrders { get; set; }
    }
}
