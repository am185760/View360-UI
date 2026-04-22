using EView360.Data;
using System.Transactions;

namespace EView360.Services
{
    public class TransactionRepository
    {
        public Task<List<Transactions>> GetTransactionAsync()
        {
            List<Transactions> transactions = new List<Transactions>();


            Transactions transactions1 = new Transactions()
            {
                atm = "0000001",
                Location = "001-ATM-LAP",
                Group = "BRCRSC,N200F,C,BRACX",
                Date = DateTime.Now,
                Amount = 200,
                Dispensed1 = "0",
                Dispensed2 = "1",
                Dispensed3 = "1",
                Purged1 = "0",
                Purged2 = "0",
                Purged3 = "3",
                PurgedNotes = "0",
                Remaining1 = "100",
                Remaining2 = "200",
                Remaining3 = "120"

            };

            Transactions transactions2 = new Transactions()
            {
                atm = "0000002",
                Location = "002-ATM-LAP",
                Group = "BRCRSC,N200F,C,BRACX",
                Date = DateTime.Now,
                Amount = 150,
                Dispensed1 = "1",
                Dispensed2 = "1",
                Dispensed3 = "2",
                Purged1 = "0",
                Purged2 = "4",
                Purged3 = "3",
                PurgedNotes = "0",
                Remaining1 = "300",
                Remaining2 = "50",
                Remaining3 = "120"

            };

            Transactions transactions3 = new Transactions()
            {
                atm = "0000003",
                Location = "003-ATM-LAP",
                Group = "BRCRSC,N200F,C,BRACX",
                Date = DateTime.Now,
                Amount = 50,
                Dispensed1 = "0",
                Dispensed2 = "1",
                Dispensed3 = "1",
                Purged1 = "1",
                Purged2 = "0",
                Purged3 = "2",
                PurgedNotes = "4",
                Remaining1 = "50",
                Remaining2 = "300",
                Remaining3 = "120"

            };

            Transactions transactions4 = new Transactions()
            {
                atm = "0000004",
                Location = "004-ATM-LAP",
                Group = "BRCRSC,N200F,C,BRACX",
                Date = DateTime.Now,
                Amount = 500,
                Dispensed1 = "2",
                Dispensed2 = "2",
                Dispensed3 = "1",
                Purged1 = "1",
                Purged2 = "0",
                Purged3 = "2",
                PurgedNotes = "4",
                Remaining1 = "50",
                Remaining2 = "300",
                Remaining3 = "120"

            };

            Transactions transactions5 = new Transactions()
            {
                atm = "0000003",
                Location = "003-ATM-LAP",
                Group = "BRCRSC,N200F,C,BRACX",
                Date = DateTime.Now,
                Amount = 50,
                Dispensed1 = "0",
                Dispensed2 = "1",
                Dispensed3 = "1",
                Purged1 = "1",
                Purged2 = "0",
                Purged3 = "2",
                PurgedNotes = "4",
                Remaining1 = "50",
                Remaining2 = "300",
                Remaining3 = "120"

            };

            Transactions transactions6 = new Transactions()
            {
                atm = "0000003",
                Location = "003-ATM-LAP",
                Group = "BRCRSC,N200F,C,BRACX",
                Date = DateTime.Now,
                Amount = 50,
                Dispensed1 = "0",
                Dispensed2 = "1",
                Dispensed3 = "1",
                Purged1 = "1",
                Purged2 = "0",
                Purged3 = "2",
                PurgedNotes = "4",
                Remaining1 = "500",
                Remaining2 = "300",
                Remaining3 = "120"

            };

            Transactions transactions7 = new Transactions()
            {
                atm = "0000007",
                Location = "007-ATM-LAP",
                Group = "BRCRSC,N200F,C,BRACX",
                Date = DateTime.Now,
                Amount = 50,
                Dispensed1 = "0",
                Dispensed2 = "1",
                Dispensed3 = "1",
                Purged1 = "1",
                Purged2 = "0",
                Purged3 = "2",
                PurgedNotes = "5",
                Remaining1 = "500",
                Remaining2 = "300",
                Remaining3 = "320"

            };

            Transactions transactions8 = new Transactions()
            {
                atm = "0000008",
                Location = "008-ATM-LAP",
                Group = "BRCRSC,N200F,C,BRACX",
                Date = DateTime.Now,
                Amount = 50,
                Dispensed1 = "0",
                Dispensed2 = "1",
                Dispensed3 = "1",
                Purged1 = "1",
                Purged2 = "0",
                Purged3 = "2",
                PurgedNotes = "4",
                Remaining1 = "500",
                Remaining2 = "300",
                Remaining3 = "120"

            };
            transactions.Add(transactions1);
            transactions.Add(transactions2);
            transactions.Add(transactions3);
            transactions.Add(transactions4);
            transactions.Add(transactions5);
            transactions.Add(transactions6);
            transactions.Add(transactions7);
            transactions.Add(transactions8);

            return Task.FromResult(transactions);
        }

        public Task<List<CashPositions>> GetCashPositionAsync()
        {
            List<CashPositions> cashPositions = new List<CashPositions>();

            for(int t= 1; t <= 9; t++)
            {
                CashPositions cash = new CashPositions()
                {
                    atm = $"000000{t}",
                    Location = $"00{t}-ATM-LAP",
                    Group = "BRCRSC,N200F,C,BRACX",
                    Date = DateTime.Now,
                    LastReplenished = DateTime.Now,
                    Type1 = "20",
                    Type2 = "50",
                    Type3 = "100",
                    Purged1 = "0",
                    Purged2 = "0",
                    Purged3 = "3",
                    PurgedNotes = "0",
                    Remaining1 = "100",
                    Remaining2 = "200",
                    Remaining3 = "120",
                    TotalRemaining = "450",
                    Total = "0"
                };
                cashPositions.Add(cash);
            }

            return Task.FromResult(cashPositions);
        }
    }
}
