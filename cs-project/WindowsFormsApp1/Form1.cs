using tk.crazylab.csstoxpath;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Conversor conversor = Conversor.getInstance();
            conversor.javascriptError += delegate (object sender, JavascriptErrorEventArgs args) {
                MessageBox.Show(args.e.ToString(), "Error converting css to xpath");
            };
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            Conversor conversor = Conversor.getInstance(true);
            textBox2.Text = conversor.cssToXpath(textBox1.Text);
        }
    }
}
