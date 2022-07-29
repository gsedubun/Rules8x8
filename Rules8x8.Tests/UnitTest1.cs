using Xunit;

namespace Rules8x8.Tests
{
    public class Tests
    {
        private RulesEngine re;
        public Tests()
        {
            //re = new RulesEngine("SampleData.csv");

            List<StrategyRule> rules = new List<StrategyRule>()
            {
                new StrategyRule(){ RuleId=4, Priority=100, Filter1="AAA", Filter2="BBB",
                Filter3="CCC", Filter4="<ANY>", OutputValue=10 },
                new StrategyRule(){ RuleId=2, Priority=10, Filter1="<ANY>", Filter2="<ANY>",
                Filter3="AAA", Filter4="<ANY>", OutputValue=1 },
                new StrategyRule(){ RuleId=3, Priority=70, Filter1="BBB", Filter2="<ANY>",
                Filter3="CCC", Filter4="<ANY>", OutputValue=7 },
            };
            re= new RulesEngine(rules);
        }

        [Theory]
        [InlineData("AAA","BBB","CCC","AAA")]
        [InlineData("AAA", "BBB", "CCC", "DDD")]
        public void FindRuleTest(string val1, string val2, string val3, string val4)
        {
            var res = re.FindRule(val1,val2,val3,val4);
            

            Assert.Equal(4,res.RuleId);
            Assert.Equal(10,res.OutputValue);

        }

        [Theory]
        [InlineData("BBB", "CCC", "CCC", "CCC")]
        public void FindRuleTest2(string val1, string val2, string val3, string val4)
        {
            var res = re.FindRule(val1, val2, val3, val4);


            Assert.Equal(3, res.RuleId);
            Assert.Equal(7, res.OutputValue);

        }

        [Fact]
        public void ShouldFail(string val1, string val2, string val3, string val4){
            
        }
    }
}