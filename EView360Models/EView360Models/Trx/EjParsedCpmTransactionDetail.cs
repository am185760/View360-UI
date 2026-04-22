using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class EjParsedCpmTransactionDetail
{
    public long EjParsedCpmTransactionDetailId { get; set; }

    public long EjParsedCpmTransactionId { get; set; }

    public decimal CheckAmount { get; set; }
}
