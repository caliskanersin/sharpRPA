﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharpRPA.UI.Forms
{
    public partial class frmScriptVariables : UIForm
    {
        public List<Core.Script.ScriptVariable> scriptVariables { get; set; }
        private BindingList<Core.Script.ScriptVariable> ds;
        public frmScriptVariables()
        {
            InitializeComponent();
        }

        private void frmScriptVariables_Load(object sender, EventArgs e)
        {
         
            dgvVariables.AutoGenerateColumns = false;

            ds = new BindingList<Core.Script.ScriptVariable>(scriptVariables);
   
            DataGridViewColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "variableName";
            textColumn.HeaderText = "Variable Name";
            textColumn.Name = "colVariableName";
            textColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVariables.Columns.Add(textColumn);

            DataGridViewColumn valueColumn = new DataGridViewTextBoxColumn();
            valueColumn.DataPropertyName = "variableValue";
            valueColumn.HeaderText = "Value";
            valueColumn.Name = "colVariableValue";
            valueColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVariables.Columns.Add(valueColumn);

            cboVariableView.SelectedIndex = 0;

        }

        private void btnAddVar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;

        }

        private void dgvVariables_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void uiBtnOK_Click(object sender, EventArgs e)
        {
            dgvVariables.EndEdit();
            this.DialogResult = DialogResult.OK;
        }

        private void uiBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboVariableView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVariableView.Text == "User Variables")
            {
                dgvVariables.DataSource = ds;
                dgvVariables.ReadOnly = false;
            }
            else
            {
                Core.AutomationCommands.VariableCommand newVariableCommand = new Core.AutomationCommands.VariableCommand();
                dgvVariables.DataSource = newVariableCommand.GenerateSystemVariables();
                dgvVariables.ReadOnly = true;
            }

        }
    }
}