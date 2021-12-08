using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Thi
{
    public partial class uscTimer : UserControl
    {
        int mm, ss;
        int _mmBegin, _ssBegin;

        public delegate void uscTimer_ExitHandle();
        public event uscTimer_ExitHandle uscTimer_Exit;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ss > 0)
            {
                ss--;
            }
            else
            {
                ss = 59;
                mm--;
            }
            SetNumber();

            if (mm == 0 && ss == 0)
                uscTimer_Exit();
        }

        private void SetNumber()
        {
            mm1Label.Text = (mm / 10).ToString();
            mm2Label.Text = (mm % 10).ToString();
            ss1Label.Text = (ss / 10).ToString();
            ss2Label.Text = (ss % 10).ToString();
        }

        public uscTimer()
        {
            InitializeComponent();
            SetNumber();
        }

        public int _mm
        {
            get { return _mmBegin; }
            set
            {
                if (value < 0)
                    _mmBegin = 0;
                else if (value > 99)
                    _mmBegin = 99;
                else _mmBegin = value;
                mm1Label.Text = (_mmBegin / 10).ToString();
                mm2Label.Text = (_mmBegin % 10).ToString();
            }
        }

        public int _ss
        {
            get { return _ssBegin; }
            set
            {
                if (value < 0)
                    _ssBegin = 0;
                else if (value > 60)
                    _ssBegin = 99;
                else _ssBegin = value;
                ss1Label.Text = (_ssBegin / 10).ToString();
                ss2Label.Text = (_ssBegin % 10).ToString();
            }
        }

        public void Start()
        {
            timer.Enabled = true;
            if (_mmBegin != 0)
            {
                mm = _mmBegin;
            }
            if (_ssBegin != 0)
            {
                ss = _ssBegin;
            }
        }
    }
}
