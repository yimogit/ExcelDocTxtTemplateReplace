using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Configuration;

namespace ExcelDocTxtTemplateReplace
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;//窗体居中显示  
            this.MaximizeBox = false;//不显示最大化按钮 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;//禁止放大缩小 
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Control_ControlAdded);
            InitializeComponent();
        }
        private void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            //使“未来”生效
            e.Control.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Control_ControlAdded);
            //使“子孙”生效
            foreach (Control c in e.Control.Controls)
            {
                Control_ControlAdded(sender, new ControlEventArgs(c));
            }
            //使“过去”生效
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.KeyPress += TextBox_KeyPress;
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null)
                return;
            if (e.KeyChar == (char)1)
            {
                textBox.SelectAll();
                e.Handled = true;
            }
        }
        private string GetSavePath(string name)
        {
            var newFilePath = Path.Combine(Application.StartupPath, ConfigurationManager.AppSettings.Get("生成文件保存目录") ?? "result");

            if (!Directory.Exists(newFilePath))
            {
                Directory.CreateDirectory(newFilePath);
            }
            return Path.Combine(newFilePath, name);
        }
        private string GetKeywordPath()
        {
            var str = ConfigurationManager.AppSettings.Get("关键字保存文本路径");
            return string.IsNullOrWhiteSpace(str) ? "keywords.txt" : str;
        }
        /// <summary>
        /// 路径分隔符
        /// </summary>
        /// <returns></returns>
        private string GetFilePathSplitSymbol()
        {
            var str = ConfigurationManager.AppSettings.Get("路径分隔符");
            return string.IsNullOrWhiteSpace(str) ? Environment.NewLine : str;
        }
        /// <summary>
        /// 替换关键字分隔符
        /// </summary>
        /// <returns></returns>
        private string GetReplaceKeywordSymbol()
        {
            var str = ConfigurationManager.AppSettings.Get("替换关键字分隔符");
            return string.IsNullOrWhiteSpace(str) ? "==" : str;
        }
        /// <summary>
        /// 支持的文件扩展
        /// </summary>
        /// <returns></returns>
        private string GetSupportExts()
        {
            return ConfigurationManager.AppSettings.Get("支持的文件扩展") ?? "*.*";
        }
        /// <summary>
        /// 加载关键字
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> LoadKeywords()
        {
            Dictionary<string, string> container = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();
            var splitStr = GetReplaceKeywordSymbol();
            var list = this.txtKeywords.Lines.Where(s => string.IsNullOrWhiteSpace(s) == false && s.Contains(splitStr));
            foreach (var item in list)
            {
                var key = item.Split(new String[] { splitStr }, StringSplitOptions.RemoveEmptyEntries)[0];
                var value = item.Substring(key.Length + splitStr.Length);
                if (key == "{DateTimeNow}")
                {
                    container.Add(key, DateTime.Now.ToString(value));
                }
                else if (!container.ContainsKey(key))
                {
                    container.Add(key, value);
                }
                else
                {
                    container[key] = value;
                }
            }

            return container;

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            var paths = txtPaths.Text.Split(new[] { GetFilePathSplitSymbol() }, StringSplitOptions.RemoveEmptyEntries);
            if (paths.Length <= 0)
            {
                MessageBox.Show("请选择需要替换的文件");
                return;
            }
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Stopwatch ts = new Stopwatch();
                DocHelper docHelper = new DocHelper();
                ts.Start();
                var dics = LoadKeywords();
                AppendLogMsg("关键字个数：" + dics.Count);
                AppendLogMsg("待生成文件：" + paths.Length);
                foreach (var path in paths)
                {
                    if (!File.Exists(path))
                    {
                        AppendLogMsg("【{0}】文件不存在", path);
                        return;
                    }
                    var ext = Path.GetExtension(path);
                    var savePath = GetSavePath(Path.GetFileName(path));
                    try
                    {
                        if (ext == ".xls" || ext == ".xlsx")
                        {
                            docHelper.ExcelReplace(path, savePath, dics);

                        }
                        else if (ext == ".docx" || ext == ".doc")
                        {
                            docHelper.WordReplace(path, savePath, dics);
                        }
                        else
                        {
                            docHelper.TxtReplace(path, savePath, dics);
                        }
                        AppendLogMsg("【{0}】生成成功", savePath);
                    }
                    catch (Exception ex)
                    {
                        AppendLogMsg("【{0}】生成异常", path);
                        AppendLogMsg("异常信息：{0}，{1}", ex.Message, ex.StackTrace);
                    }
                }
                ts.Stop();
                AppendLogMsg("生成完完毕,用时：" + ts.Elapsed);
            });
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "支持的文件类型|" + GetSupportExts();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPaths.Clear();
                foreach (var name in ofd.FileNames)
                {
                    txtPaths.AppendText(name);
                    txtPaths.AppendText(GetFilePathSplitSymbol());
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.txtLogMsg.Multiline = true;//多选， 一般在界面中就设置了
            this.txtLogMsg.ScrollBars = ScrollBars.Vertical;//日志输出显示纵向滚动条
            this.txtLogMsg.ReadOnly = true; //输出日志只读
            this.txtLogMsg.WordWrap = false;
            this.txtLogMsg.TextChanged += txtLogMsg_TextChanged;//注册改变事件
            this.lblFileRemark.Text = string.Format("{0},支持格式({1})", this.lblFileRemark.Text, GetSupportExts(), GetFilePathSplitSymbol());
            this.lblKeywordRule.Text = string.Format("规则：关键字{0}替换值", GetReplaceKeywordSymbol());
            if (File.Exists(GetKeywordPath()))
            {
                using (StreamReader sr = new StreamReader(GetKeywordPath()))
                {
                    while (sr.Peek() >= 0)
                    {
                        var item = sr.ReadLine();
                        this.txtKeywords.AppendText(item);
                        this.txtKeywords.AppendText(Environment.NewLine);
                    }
                }
                AppendLogMsg("加载关键字成功");
            }
        }
        //文本框事件 使追加日志后滚动光标到末尾
        void txtLogMsg_TextChanged(object sender, EventArgs e)
        {
            txtLogMsg.SelectionStart = txtLogMsg.Text.Length + 10;//设置选中文字的开始位置为文本框的文字的长度，如果超过了文本长度，则默认为文本的最后。
            txtLogMsg.SelectionLength = 0;//设置被选中文字的长度为0（将光标移动到文字最后）
            txtLogMsg.ScrollToCaret();//将滚动条移动到光标位置
        }
        //追加日志方法 在非UI线程中直接AppendText调试会异常
        private void AppendLogMsg(string msg, params Object[] args)
        {
            //在UI线程中执行
            txtLogMsg.BeginInvoke(new Action(() =>
            {
                txtLogMsg.AppendText(string.Format(msg, args));
                txtLogMsg.AppendText(Environment.NewLine);//追加换行符
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppendLogMsg("开始保存关键字");
            Task.Factory.StartNew(() =>
            {
                File.WriteAllText(GetKeywordPath(), this.txtKeywords.Text);
                AppendLogMsg("保存关键字成功");
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppendLogMsg("打开目录：{0}", GetSavePath(string.Empty));
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + GetSavePath(string.Empty);
            System.Diagnostics.Process.Start(psi);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.txtLogMsg.Clear();
        }
    }
}