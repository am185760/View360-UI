using System;

class Replenishment
{
    public int cashAdded1;
    public int cashAdded2;
    public int cashAdded3;
    public int cashAdded4;
    public int cashAdded5;
    public int cashAdded6;
    public int cashAdded7;
    int totalAmount;
    bool isSwap;
    
    public int GetTotalAmount()
    {
        return totalAmount;
    }
    
    public Replenishment(int CashAdded1, int CashAdded2, int CashAdded3, int CashAdded4,
                         int CashAdded5, int CashAdded6, int CashAdded7,
                         int Denomination1, int Denomination2, int Denomination3, int Denomination4,
                         int Denomination5, int Denomination6, int Denomination7, bool isSwap)
    {
        cashAdded1 = CashAdded1;
        cashAdded2 = CashAdded2;
        cashAdded3 = CashAdded3;
        cashAdded4 = CashAdded4;
        cashAdded5 = CashAdded5;
        cashAdded6 = CashAdded6;
        cashAdded7 = CashAdded7;

        this.isSwap = isSwap;
        totalAmount = CashAdded1 * Denomination1 + CashAdded2 * Denomination2 + CashAdded3 * Denomination3 +
                CashAdded4 * Denomination4 + CashAdded5 * Denomination5 + CashAdded6 * Denomination6 + CashAdded7 * Denomination7;
    }
}
