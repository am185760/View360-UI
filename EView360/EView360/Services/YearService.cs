namespace EView360.Services
{
    public class YearService
    {
        public List<int> GetLastNYears(int N)
        {
            List<int> yearList = new();
            int year = DateTime.Now.Year;
            while (N > 0)
            {
                year--;
                yearList.Add(year);
                N--;
            }
            return yearList;
        }
    }
}
