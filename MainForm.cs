using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCloudMigration
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private DateTime StartTime { get; set; }

        private void BroswerButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "数据库文件|*.db|所有文件|*.*";
            dialog.Title = "选择数据库文件";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FilePathDisplay.Text = dialog.FileName;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePathDisplay.Text)
                || !File.Exists(FilePathDisplay.Text))
            {
                MessageBox.Show("请选择数据库文件路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StartButton.Enabled = false;
            BroswerButton.Enabled = false;
            Text = "正在迁移数据，请稍候...";
            Task.Run(() =>
            {
                try
                {
                    string newDB = Path.Combine(
                        Path.GetDirectoryName(FilePathDisplay.Text),
                        $"{Path.GetFileNameWithoutExtension(FilePathDisplay.Text)}_Migration_{DateTime.Now:yyyyMMddHHmmss}.db");

                    using SqlSugarClient db_old = new SqlSugarClient(new ConnectionConfig
                    {
                        ConnectionString = $"data source={FilePathDisplay.Text};Cache Size=10000;Page Size=4096;Journal Mode=WAL;Synchronous=Normal;",
                        DbType = DbType.Sqlite,
                        IsAutoCloseConnection = true,
                        InitKeyType = InitKeyType.Attribute,
                    });

                    using SqlSugarClient db_new = new SqlSugarClient(new ConnectionConfig
                    {
                        ConnectionString = $"data source={newDB};Cache Size=10000;Page Size=4096;Journal Mode=WAL;Synchronous=Normal;",
                        DbType = DbType.Sqlite,
                        IsAutoCloseConnection = true,
                        InitKeyType = InitKeyType.Attribute,
                    });

                    db_new.DbMaintenance.CreateDatabase(newDB);
                    db_new.CodeFirst
                        .SplitTables() 
                        .InitTables(typeof(Record_New));
                    int total = db_old.Queryable<Record_Old>().Count();
                    int currentIndex = 0;
                    StartTime = DateTime.Now;
                    SwitchTimer(true);
                    var pageList = new List<Record_New>();

                    var pageSize = 200000;
                    db_old.Queryable<object>().AS("Record_Old").Select<Record_New>().ForEach(it => {
                        it.Id = SnowFlakeSingle.Instance.NextId();
                        pageList.Add(it);
                        if (pageList.Count == pageSize)
                        {
                            currentIndex += pageSize;
                            db_new.Fastest<Record_New>().SplitTable().BulkCopy(pageList);
                            pageList = new List<Record_New>();
                            DisplayProgress($"已迁移 {currentIndex} / {total} 条记录...", (int)((currentIndex / (total * 1.0)) * 100));
                        }
                    }, pageSize);
                    db_new.Fastest<Record_New>().SplitTable().BulkCopy(pageList);
                    currentIndex += pageList.Count;
                    DisplayProgress($"已迁移 {currentIndex} / {total} 条记录...", (int)((currentIndex / (total * 1.0)) * 100));
                    SwitchTimer(false);
                    MessageBox.Show("数据迁移完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"数据迁移失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SwitchTimer(false);
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        StartButton.Enabled = true;
                        BroswerButton.Enabled = true;
                        Text = "数据库迁移";
                    }));
                }
            });
        }

        private void SwitchTimer(bool enable)
        {
            Invoke(new MethodInvoker(() =>
            {
                if (enable)
                {
                    TimeConsumeTimer.Start();
                }
                else
                {
                    TimeConsumeTimer.Stop();
                }
            }));
        }

        public void DisplayProgress(string message, int progress = 0)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                ProgressStatus.Text = message;
                MigrationProgress.Value = progress;
            }));
        }

        private void TimeConsumeTimer_Tick(object sender, EventArgs e)
        {
            TimeConsume.Text = $"已用时：{(DateTime.Now - StartTime).TotalSeconds:f1} 秒";
        }
    }
}
