using System.ComponentModel;

namespace Contest_CS
{
    partial class ChallengeChildrenData
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
            this.ChildrenDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) (this.ChildrenDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ChildrenDataGridView
            // 
            this.ChildrenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChildrenDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildrenDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ChildrenDataGridView.Name = "ChildrenDataGridView";
            this.ChildrenDataGridView.RowTemplate.Height = 24;
            this.ChildrenDataGridView.Size = new System.Drawing.Size(800, 450);
            this.ChildrenDataGridView.TabIndex = 0;
            // 
            // ChallengeChildrenData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChildrenDataGridView);
            this.Name = "ChallengeChildrenData";
            this.Text = "ChallengeChildrenData";
            ((System.ComponentModel.ISupportInitialize) (this.ChildrenDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView ChildrenDataGridView;

        #endregion
    }
}