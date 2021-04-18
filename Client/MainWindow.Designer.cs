using System.ComponentModel;

namespace Contest_CS
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ChallengesDataGridView = new System.Windows.Forms.DataGridView();
            this.ChildrenDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SecondChallengeBox = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.SecondChallengeComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteSecondChallengeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.AddSecondChallengeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.FirstChallengeComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AgeTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ChallengesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ChildrenDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SecondChallengeBox.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.ChallengesDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ChildrenDataGridView, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.784661F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.21534F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 753);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ChallengesDataGridView
            // 
            this.ChallengesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChallengesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChallengesDataGridView.Location = new System.Drawing.Point(3, 49);
            this.ChallengesDataGridView.Name = "ChallengesDataGridView";
            this.ChallengesDataGridView.RowTemplate.Height = 24;
            this.ChallengesDataGridView.Size = new System.Drawing.Size(329, 626);
            this.ChallengesDataGridView.TabIndex = 0;
            this.ChallengesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChallengesDataGridView_CellDoubleClick);
            // 
            // ChildrenDataGridView
            // 
            this.ChildrenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChildrenDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildrenDataGridView.Location = new System.Drawing.Point(673, 49);
            this.ChildrenDataGridView.Name = "ChildrenDataGridView";
            this.ChildrenDataGridView.RowTemplate.Height = 24;
            this.ChildrenDataGridView.Size = new System.Drawing.Size(330, 626);
            this.ChildrenDataGridView.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel7);
            this.panel1.Controls.Add(this.SecondChallengeBox);
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(338, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 626);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.ErrorLabel, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 431);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(329, 53);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.ErrorLabel.Location = new System.Drawing.Point(3, 17);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(323, 18);
            this.ErrorLabel.TabIndex = 0;
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SecondChallengeBox
            // 
            this.SecondChallengeBox.ColumnCount = 2;
            this.SecondChallengeBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SecondChallengeBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SecondChallengeBox.Controls.Add(this.label6, 0, 0);
            this.SecondChallengeBox.Controls.Add(this.SecondChallengeComboBox, 1, 0);
            this.SecondChallengeBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SecondChallengeBox.Location = new System.Drawing.Point(0, 349);
            this.SecondChallengeBox.Name = "SecondChallengeBox";
            this.SecondChallengeBox.RowCount = 1;
            this.SecondChallengeBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SecondChallengeBox.Size = new System.Drawing.Size(329, 82);
            this.SecondChallengeBox.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(3, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = " Proba 2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SecondChallengeComboBox
            // 
            this.SecondChallengeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondChallengeComboBox.FormattingEnabled = true;
            this.SecondChallengeComboBox.Location = new System.Drawing.Point(167, 29);
            this.SecondChallengeComboBox.Name = "SecondChallengeComboBox";
            this.SecondChallengeComboBox.Size = new System.Drawing.Size(159, 24);
            this.SecondChallengeComboBox.TabIndex = 1;
            this.SecondChallengeComboBox.Text = "Alege a doua proba";
            this.SecondChallengeComboBox.DropDown += new System.EventHandler(this.SecondChallengeComboBox_DropDown);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.DeleteSecondChallengeLabel, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 291);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(329, 58);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // DeleteSecondChallengeLabel
            // 
            this.DeleteSecondChallengeLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteSecondChallengeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteSecondChallengeLabel.ForeColor = System.Drawing.Color.Red;
            this.DeleteSecondChallengeLabel.Location = new System.Drawing.Point(3, 18);
            this.DeleteSecondChallengeLabel.Name = "DeleteSecondChallengeLabel";
            this.DeleteSecondChallengeLabel.Size = new System.Drawing.Size(323, 21);
            this.DeleteSecondChallengeLabel.TabIndex = 0;
            this.DeleteSecondChallengeLabel.Text = "- sterge a doua proba\r\n";
            this.DeleteSecondChallengeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeleteSecondChallengeLabel.Click += new System.EventHandler(this.DeleteSecondChallengeLabel_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.AddSecondChallengeLabel, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 231);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(329, 60);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // AddSecondChallengeLabel
            // 
            this.AddSecondChallengeLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AddSecondChallengeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddSecondChallengeLabel.ForeColor = System.Drawing.Color.Lime;
            this.AddSecondChallengeLabel.Location = new System.Drawing.Point(3, 18);
            this.AddSecondChallengeLabel.Name = "AddSecondChallengeLabel";
            this.AddSecondChallengeLabel.Size = new System.Drawing.Size(323, 23);
            this.AddSecondChallengeLabel.TabIndex = 0;
            this.AddSecondChallengeLabel.Text = "+ adauga o proba noua";
            this.AddSecondChallengeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddSecondChallengeLabel.Click += new System.EventHandler(this.AddSecondChallengeLabel_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.FirstChallengeComboBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 146);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(329, 85);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Proba 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstChallengeComboBox
            // 
            this.FirstChallengeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstChallengeComboBox.FormattingEnabled = true;
            this.FirstChallengeComboBox.Location = new System.Drawing.Point(167, 30);
            this.FirstChallengeComboBox.Name = "FirstChallengeComboBox";
            this.FirstChallengeComboBox.Size = new System.Drawing.Size(159, 24);
            this.FirstChallengeComboBox.TabIndex = 1;
            this.FirstChallengeComboBox.Text = "Alege prima proba";
            this.FirstChallengeComboBox.DropDown += new System.EventHandler(this.FirstChallengeComboBox_DropDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.43465F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.56535F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.AgeTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.NameTextBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(329, 146);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 73);
            this.label2.TabIndex = 1;
            this.label2.Text = "Varsta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AgeTextBox
            // 
            this.AgeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AgeTextBox.Location = new System.Drawing.Point(113, 98);
            this.AgeTextBox.Name = "AgeTextBox";
            this.AgeTextBox.Size = new System.Drawing.Size(213, 22);
            this.AgeTextBox.TabIndex = 3;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(113, 25);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(213, 22);
            this.NameTextBox.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(338, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(329, 40);
            this.tableLayoutPanel8.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(323, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Athletics Competition";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Controls.Add(this.RegisterButton, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(338, 681);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(329, 69);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterButton.Location = new System.Drawing.Point(112, 16);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(103, 36);
            this.RegisterButton.TabIndex = 0;
            this.RegisterButton.Text = "Inscrie";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 753);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Main";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.ChallengesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ChildrenDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.SecondChallengeBox.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button RegisterButton;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;

        private System.Windows.Forms.Label ErrorLabel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;

        private System.Windows.Forms.ComboBox SecondChallengeComboBox;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.TableLayoutPanel SecondChallengeBox;

        private System.Windows.Forms.Label DeleteSecondChallengeLabel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;

        private System.Windows.Forms.Label AddSecondChallengeLabel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

        private System.Windows.Forms.ComboBox FirstChallengeComboBox;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

        private System.Windows.Forms.TextBox AgeTextBox;

        private System.Windows.Forms.TextBox NameTextBox;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.DataGridView ChildrenDataGridView;

        private System.Windows.Forms.DataGridView ChallengesDataGridView;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}