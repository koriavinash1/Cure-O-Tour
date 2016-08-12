

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reasonpage
{
    public class Reason
    {
        public string rea { get; set; }
        public string rea1 { get; set; }
        public string fullreason { get { return string.Format("{0} {1}", rea, rea1); } }
    }




    public static class ReasonSampleDataSource
    {
        private static List<Reason> _reasons = new List<Reason>()
    {
        new Reason() {rea="Heart Surgery",rea1="." },
        new Reason() {rea="AIDs",rea1="." },
        new Reason() {rea="Cancer",rea1="." }
    }.OrderBy(c => c.fullreason).ToList();

        public static List<Reason> Reasons
        {
            get { return _reasons; }
        }

        public static IEnumerable<Reason> GetMatchingReasons(string query)
        {
            return ReasonSampleDataSource.Reasons
                .Where(c => c.rea.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1||
                            c.rea1.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1)
                 .OrderByDescending(c => c.rea.StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
                 .ThenByDescending(c => c.rea1.StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
            


           ;
        }
    }
}