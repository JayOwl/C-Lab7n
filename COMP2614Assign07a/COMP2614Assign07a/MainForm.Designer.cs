namespace COMP2614Assign07a
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.buttonEditRecord = new System.Windows.Forms.Button();
            this.labelCreditHoldCountOW = new System.Windows.Forms.Label();
            this.labelTotalYTDSalesOW = new System.Windows.Forms.Label();
            this.labelCustomerCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.customerViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(25, 12);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.Size = new System.Drawing.Size(925, 354);
            this.dataGridViewCustomers.TabIndex = 0;
            this.dataGridViewCustomers.SelectionChanged += new System.EventHandler(this.dataGridViewCustomers_SelectionChanged);
            // 
            // buttonEditRecord
            // 
            this.buttonEditRecord.Location = new System.Drawing.Point(875, 395);
            this.buttonEditRecord.Name = "buttonEditRecord";
            this.buttonEditRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonEditRecord.TabIndex = 1;
            this.buttonEditRecord.Text = "&Edit Record";
            this.buttonEditRecord.UseVisualStyleBackColor = true;
            this.buttonEditRecord.Click += new System.EventHandler(this.buttonEditRecord_Click);
            // 
            // labelCreditHoldCountOW
            // 
            this.labelCreditHoldCountOW.AutoSize = true;
            this.labelCreditHoldCountOW.Location = new System.Drawing.Point(485, 413);
            this.labelCreditHoldCountOW.Name = "labelCreditHoldCountOW";
            this.labelCreditHoldCountOW.Size = new System.Drawing.Size(35, 13);
            this.labelCreditHoldCountOW.TabIndex = 2;
            this.labelCreditHoldCountOW.Text = "label1";
            // 
            // labelTotalYTDSalesOW
            // 
            this.labelTotalYTDSalesOW.AutoSize = true;
            this.labelTotalYTDSalesOW.Location = new System.Drawing.Point(485, 387);
            this.labelTotalYTDSalesOW.Name = "labelTotalYTDSalesOW";
            this.labelTotalYTDSalesOW.Size = new System.Drawing.Size(35, 13);
            this.labelTotalYTDSalesOW.TabIndex = 3;
            this.labelTotalYTDSalesOW.Text = "label2";
            // 
            // labelCustomerCount
            // 
            this.labelCustomerCount.AutoSize = true;
            this.labelCustomerCount.Location = new System.Drawing.Point(485, 400);
            this.labelCustomerCount.Name = "labelCustomerCount";
            this.labelCustomerCount.Size = new System.Drawing.Size(35, 13);
            this.labelCustomerCount.TabIndex = 4;
            this.labelCustomerCount.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total on CH:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Sales:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Customer Count:";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Location = new System.Drawing.Point(763, 400);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(106, 17);
            this.checkBoxDelete.TabIndex = 8;
            this.checkBoxDelete.Text = "Confirm Deletion:";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(791, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // customerViewModelBindingSource
            // 
            this.customerViewModelBindingSource.DataSource = typeof(COMP2614Assign07a.CustomerViewModel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 444);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCustomerCount);
            this.Controls.Add(this.labelTotalYTDSalesOW);
            this.Controls.Add(this.labelCreditHoldCountOW);
            this.Controls.Add(this.buttonEditRecord);
            this.Controls.Add(this.dataGridViewCustomers);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Company Information";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.Button buttonEditRecord;
        private System.Windows.Forms.Label labelCreditHoldCountOW;
        private System.Windows.Forms.Label labelTotalYTDSalesOW;
        private System.Windows.Forms.Label labelCustomerCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxDelete;
        private System.Windows.Forms.BindingSource customerViewModelBindingSource;
        private System.Windows.Forms.Label label4;
    }
}

