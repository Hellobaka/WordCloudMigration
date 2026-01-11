using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCloudMigration
{
    [SplitTable(SplitType.Year)]
    [SugarTable("Record_{year}{month}{day}")]
    [SugarIndex("index_{split_table}_groupid_datetime", nameof(GroupID), OrderByType.Asc, nameof(DateTime), OrderByType.Desc)]
    public class Record_New
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }

        public long GroupID { get; set; }

        public long QQID { get; set; }

        public string Message { get; set; }

        [SplitField]
        public DateTime DateTime { get; set; }
    }
}
