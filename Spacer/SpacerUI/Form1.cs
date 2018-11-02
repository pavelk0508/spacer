using SpacerLibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpacerUI
{
    public partial class MainForm : Form
    {
        private KompasConnector _kompasConnector = new KompasConnector();
        private Parametrs _parametrs;
        private Builder _builder;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartKompasButton_Click(object sender, EventArgs e)
        {
            try
            {
                _kompasConnector.StartKompas();
                ButtonDraw.Enabled = true;
                StartKompasButton.Enabled = false;
                CloseKompasButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseKompasButton_Click(object sender, EventArgs e)
        {
            try
            {
                _kompasConnector.CloseKompas();
                ButtonDraw.Enabled = false;
                StartKompasButton.Enabled = true;
                CloseKompasButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FieldInnerDiametr_ValueChanged(object sender, EventArgs e)
        {
            FieldOuterDiametr.Minimum = FieldInnerDiametr.Value + 80;
            FieldDistance.Minimum = FieldInnerDiametr.Value + 10;
            FieldDistance.Maximum = FieldOuterDiametr.Value - 10;
        }

        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            try
            {
                _parametrs = new Parametrs((float)FieldWidth.Value, (float)FieldInnerDiametr.Value, (float)FieldOuterDiametr.Value, (int)FieldCountHoles.Value, (float)FieldDistance.Value);
                _builder = new Builder(_kompasConnector);
                _builder.CreateDetail(_parametrs);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
