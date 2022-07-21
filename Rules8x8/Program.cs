// See https://aka.ms/new-console-template for more information


RulesEngine rulesEngine = new RulesEngine("SampleData.csv");
var r1 = rulesEngine.FindRule("AAA","BBB","CCC","AAA");
var r2 = rulesEngine.FindRule("AAA", "BBB", "CCC", "DDD");
var r3 = rulesEngine.FindRule("AAA", "AAA", "AAA", "AAA");
var r4 = rulesEngine.FindRule("BBB", "BBB", "BBB", "BBB");
var r5 = rulesEngine.FindRule("BBB", "CCC", "CCC", "CCC");

Console.WriteLine($"{r1.RuleId} {r1.OutputValue}");
Console.WriteLine($"{r2.RuleId} {r2.OutputValue}");
Console.WriteLine($"{r3.RuleId} {r3.OutputValue}");
Console.WriteLine($"{r4.RuleId} {r4.OutputValue}");
Console.WriteLine($"{r5.RuleId} {r5.OutputValue}");

foreach (var item in rulesEngine.Strategies)
{
    //Console.WriteLine($"{item.RuleId} {item.OutputValue}");

}
