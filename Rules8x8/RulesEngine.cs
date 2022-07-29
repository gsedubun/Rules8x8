// See https://aka.ms/new-console-template for more information
using CsvHelper;
using Rules8x8;
using Serilog;
using System.Globalization;
using System.Reflection;

public class RulesEngine 
{
    public IEnumerable<StrategyRule> Strategies { get;private set;}
    private ILogger logger;
    public RulesEngine(List<StrategyRule> strategies)
    {
        Strategies=strategies;
        logger = Log.ForContext<RulesEngine>();
    }

    public RulesEngine(string strategyFileName)
    {
        logger = Log.ForContext<RulesEngine>();
        try{
            using (var reader = new StreamReader(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)??"", strategyFileName))){
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    Strategies= csv.GetRecords<StrategyRule>().ToList();
                }
            }
        } 
        catch(Exception ex){
            logger.Error(ex,"Error :");
            throw;

        }
       
    }

    public virtual StrategyRule? FindRule(dynamic val1,object val2, object val3, object val4)
    {
        var s = Strategies.Where(x=> (x.Filter1.Equals(val1) || x.Filter1.IsAny())
                && (x.Filter2.Equals(val2) || x.Filter2.IsAny())
                && (x.Filter3.Equals(val3) || x.Filter3.IsAny())
                && (x.Filter4.Equals(val4) || x.Filter4.IsAny())
                ).ToList();
        if (s.Any())
        {
            s.Sort();
            return s.FirstOrDefault();
        }

        return null;
    }

  
}