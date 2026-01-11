using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCloudMigration
{
    [SugarTable("Record")]
    public class Record_Old
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int RowID { get; set; }
       
        public long GroupID { get; set; }
       
        public long QQID { get; set; }
       
        public string Message { get; set; }
       
        public DateTime DateTime { get; set; }
    }
}
