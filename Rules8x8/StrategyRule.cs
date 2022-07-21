using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules8x8
{
    public static class RulesExtension
    {
        public static bool IsAny(this object s)
        {
            if(s==null)
                return false;

            return s.ToString().Equals("<ANY>", StringComparison.OrdinalIgnoreCase);
        }

    }
    public class StrategyRule :IStrategyRule<string,string,string,string>,IComparable<StrategyRule>
    {
        public int RuleId   {get;set; }
        public int Priority {get;set;}
        public string Filter1{get;set; }
        public string Filter2{get;set; }
        public string Filter3{get;set;}
        public string Filter4{get;set;}
        public int? OutputValue { get;set; }

        public int CompareTo(StrategyRule? other)
        {
            if(other == null) return 1;
            else
            {
                if(Priority> other.Priority )
                    return -1;
                else if(Priority==other.Priority) 
                    return 0;
                else
                    return 1;
            }
        }
    }


}
