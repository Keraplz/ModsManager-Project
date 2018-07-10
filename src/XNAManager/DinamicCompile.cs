using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class DinamicCompile : Form
    {
        public DinamicCompile()
        {
            InitializeComponent();
        }

        private void button_Compile_Click(object sender, EventArgs e)
        {
            textBox_Status.Clear();
            CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", textBox_Framework.Text } });
            CompilerParameters param = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, textBox_OutDir.Text, true);
            param.GenerateExecutable = true;
            CompilerResults result = csc.CompileAssemblyFromSource(param, textBox_Code.Text);
            if (result.Errors.HasErrors)
                result.Errors.Cast<CompilerError>().ToList().ForEach(error => textBox_Status.Text += error.ErrorText + "\r\n");
            else
            {
                textBox_Status.Text = "Success!";
                Process.Start(Path.Combine(Application.StartupPath, textBox_OutDir.Text));
            }
        }
    }
}