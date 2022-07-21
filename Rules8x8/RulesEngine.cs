// See https://aka.ms/new-console-template for more information
using CsvHelper;
using Rules8x8;
using System.Globalization;

public class RulesEngine
{
    public IEnumerable<StrategyRule> Strategies { get;private set;}
    public RulesEngine(List<StrategyRule> strategies)
    {
        Strategies=strategies;
    }

    public RulesEngine(string strategyFilePath)
    {
        using (var reader = new StreamReader(strategyFilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            Strategies= csv.GetRecords<StrategyRule>().ToList();
        }
    }

    public StrategyRule? FindRule(string val1,string val2, string val3, string val4)
    {
        var s = Strategies.Where(x=> (x.Filter1==val1 || x.Filter1.IsAny())
                && (x.Filter2 == val2 || x.Filter2.IsAny())
                && (x.Filter3 == val3 || x.Filter3.IsAny())
                && (x.Filter4 == val4 || x.Filter4.IsAny())
                ).ToList();
        if (s.Any())
        {
            s.Sort();
            return s.FirstOrDefault();
        }

        return null;
    }
}