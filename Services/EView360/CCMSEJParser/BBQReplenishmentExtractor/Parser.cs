using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace NCR.CCMS.Parser
{

    public class Parser
    {

        public static bool CardCaptureExtracted = false;
        public static string CardCaptureDateTimeFormat
        {
            get { return "dd/MM/yyyy HH:mm"; }
        }
        static Regex captureCardRegEx = new Regex(@"(\d{2}/\d{2}/\d{2}[ ]+(?<Time>\d{2}:\d{2}:\d{2})\r[\n]?PAN: (?<PAN>[\d]*)\r?[\n]?\r(\n)?\*[\d]+\*(?<Date>\d{2}/\d{2}/\d{4})\*\d{2}:\d{2}\*\r(\n)?[ ]*\*\r[\n]?[ ]*\*\r[\n]?[ ]*\*(?<Reason>CARD CAPTURED A/C))|(DATE: (?<Date>\d{2}/\d{2}/\d{4})[ ]+TIME: (?<Time>\d{2}:\d{2}:\d{2})\r[\n]?PAN: (?<PAN>[\d]+)[ ]+\r[\n]?TXN: (?<TXN>[\w ]*)[ ]+SEQ: (?<Seq>[\d]+)\r[\n]?STAN:[ ]+(?<Stan>[\d]+)\r[\n]?([ ]*AMOUNT: (?<CurrencyCode>[\w]+)[ ]+(?<Amount>[\d.]*)[ *]*\r[\n]?)?STATUS: (?<Reason>(CARD CAPTURED)|(HOT[ ]CARD)|(CARD[ ]EXPIRED[ ]OR[ ]HAS[ ]BAD[ ]DATE[ ]*)|(PIN EXHAUSTED: CARD DEACTIVATED\r(\n)?\r?[\n]?\r(\n)?\*[\d]+\*(?<Date>\d{2}/\d{2}/\d{4})\*\d{2}:\d{2}\*\r(\n)?[ ]*\*\r[\n]?[ ]*\*\r[\n]?[ ]*\*CARD CAPTURED A/C)))");
        string[] dateFormats = { "dd/MM/yy HH:mm:ss", "MM/dd/yy HH:mm:ss" };

        private int allowableTimeDiff = 2;
        public void SetAllowableTimeDiff(int diff)
        {
            allowableTimeDiff = diff;
        } 
        private string[] allowableMonths = null;
        public void SetAllowableMonths(string months)
        {
            allowableMonths = months.Split(',');
        }
        public void ParseAndSaveEJ(ref string ejData, Task downloadTask, LogableTask task, SqlTransaction dbTrx)
        {



        }



    }
}