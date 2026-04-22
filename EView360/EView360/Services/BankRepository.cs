using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Diagnostics;
using EView360.Data;

namespace EView360.Services
{
    public class BankRepository
    {
        
        public Task<List<Item>> GetBanksAsync()
        {
            List<Item> ATMList = new List<Item>();

            for (int i = 1; i < 5; i++)
            {
                Item atm = new Item() { Id = $"atm{i}", Text = $"ATM No. {i}" };
                ATMList.Add(atm);
            }

            List<Item> RegionList = new List<Item>();
            for (int i = 1; i < 3; i++)
            {
                Item region = new Item() { Id = $"region{i}", Text = $"Region No. {i}", Children = ATMList };
                RegionList.Add(region);
            }


            List<Item> ParentRegionList = new List<Item>();
            for (int i = 1; i < 3; i++)
            {
                Item Parentregion = new Item() { Id = $"Parentregion{i}", Text = $"Parent Region No. {i}", Children = RegionList };
                ParentRegionList.Add(Parentregion);
            }

            List<Item> BranchList = new List<Item>();
            for (int i = 1; i < 3; i++)
            {
                Item branch = new Item() { Id = $"branch{i}", Text = $"Branch No. {i}", Children = ParentRegionList };
                BranchList.Add(branch);
            }

            List<Item> BankList = new List<Item>();
            for (int i = 1; i < 3; i++)
            {
                Item Bank = new Item() { Id = $"Bank{i}", Text = $"Bank No. {i}", Children = BranchList };
                BankList.Add(Bank);
            }

            return Task.FromResult(BankList);
        }
    }
}
