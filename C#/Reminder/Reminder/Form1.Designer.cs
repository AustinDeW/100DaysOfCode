namespace Reminder
{
    partial class Form1
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
            this.tbReminderName = new System.Windows.Forms.TextBox();
            this.dtpRenewalDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddReminder = new System.Windows.Forms.Button();
            this.timerExit = new System.Windows.Forms.Timer(this.components);
            this.cbStopExit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbReminderName
            // 
            this.tbReminderName.Location = new System.Drawing.Point(146, 31);
            this.tbReminderName.Name = "tbReminderName";
            this.tbReminderName.Size = new System.Drawing.Size(200, 22);
            this.tbReminderName.TabIndex = 0;
            // 
            // dtpRenewalDate
            // 
            this.dtpRenewalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRenewalDate.Location = new System.Drawing.Point(146, 59);
            this.dtpRenewalDate.Name = "dtpRenewalDate";
            this.dtpRenewalDate.Size = new System.Drawing.Size(200, 22);
            this.dtpRenewalDate.TabIndex = 1;
            this.dtpRenewalDate.Value = new System.DateTime(2016, 12, 9, 12, 14, 14, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reminder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Renewal Date:";
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.Location = new System.Drawing.Point(156, 102);
            this.btnAddReminder.Name = "btnAddReminder";
            this.btnAddReminder.Size = new System.Drawing.Size(114, 30);
            this.btnAddReminder.TabIndex = 4;
            this.btnAddReminder.Text = "Add Reminder";
            this.btnAddReminder.UseVisualStyleBackColor = true;
            this.btnAddReminder.Click += new System.EventHandler(this.btnAddReminder_Click);
            // 
            // timerExit
            // 
            this.timerExit.Interval = 1000;
            this.timerExit.Tick += new System.EventHandler(this.timerExit_Tick);
            // 
            // cbStopExit
            // 
            this.cbStopExit.AutoSize = true;
            this.cbStopExit.Location = new System.Drawing.Point(13, 110);
            this.cbStopExit.Name = "cbStopExit";
            this.cbStopExit.Size = new System.Drawing.Size(118, 21);
            this.cbStopExit.TabIndex = 5;
            this.cbStopExit.Text = "Stop Auto Exit";
            this.cbStopExit.UseVisualStyleBackColor = true;
            this.cbStopExit.CheckedChanged += new System.EventHandler(this.cbStopExit_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 150);
            this.Controls.Add(this.cbStopExit);
            this.Controls.Add(this.btnAddReminder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpRenewalDate);
            this.Controls.Add(this.tbReminderName);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renewal Reminder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbReminderName;
        private System.Windows.Forms.DateTimePicker dtpRenewalDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddReminder;
        private System.Windows.Forms.Timer timerExit;
        private System.Windows.Forms.CheckBox cbStopExit;
    }
}

