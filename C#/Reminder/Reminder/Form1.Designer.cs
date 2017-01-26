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
            this.gbxContactPreferences = new System.Windows.Forms.GroupBox();
            this.cbTexting = new System.Windows.Forms.CheckBox();
            this.cbEmail = new System.Windows.Forms.CheckBox();
            this.lblReminderPeriods = new System.Windows.Forms.Label();
            this.tbReminderPeriods = new System.Windows.Forms.TextBox();
            this.lblReminderPeriodTip = new System.Windows.Forms.Label();
            this.tltpReminderPeriods = new System.Windows.Forms.ToolTip(this.components);
            this.lblReminderUpdatePeriod = new System.Windows.Forms.Label();
            this.tbReminderUpdatePeriod = new System.Windows.Forms.TextBox();
            this.gbxContactPreferences.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbReminderName
            // 
            this.tbReminderName.Location = new System.Drawing.Point(206, 70);
            this.tbReminderName.Name = "tbReminderName";
            this.tbReminderName.Size = new System.Drawing.Size(200, 22);
            this.tbReminderName.TabIndex = 0;
            // 
            // dtpRenewalDate
            // 
            this.dtpRenewalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRenewalDate.Location = new System.Drawing.Point(206, 98);
            this.dtpRenewalDate.Name = "dtpRenewalDate";
            this.dtpRenewalDate.Size = new System.Drawing.Size(200, 22);
            this.dtpRenewalDate.TabIndex = 1;
            this.dtpRenewalDate.Value = new System.DateTime(2016, 12, 9, 12, 14, 14, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reminder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Renewal Date:";
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.Location = new System.Drawing.Point(292, 349);
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
            this.cbStopExit.Location = new System.Drawing.Point(35, 274);
            this.cbStopExit.Name = "cbStopExit";
            this.cbStopExit.Size = new System.Drawing.Size(148, 21);
            this.cbStopExit.TabIndex = 5;
            this.cbStopExit.Text = "Stop Auto Exit (F1)";
            this.cbStopExit.UseVisualStyleBackColor = true;
            this.cbStopExit.CheckedChanged += new System.EventHandler(this.cbStopExit_CheckedChanged);
            // 
            // gbxContactPreferences
            // 
            this.gbxContactPreferences.Controls.Add(this.cbTexting);
            this.gbxContactPreferences.Controls.Add(this.cbEmail);
            this.gbxContactPreferences.Location = new System.Drawing.Point(206, 238);
            this.gbxContactPreferences.Name = "gbxContactPreferences";
            this.gbxContactPreferences.Size = new System.Drawing.Size(200, 84);
            this.gbxContactPreferences.TabIndex = 6;
            this.gbxContactPreferences.TabStop = false;
            this.gbxContactPreferences.Text = "Contact Preferences";
            // 
            // cbTexting
            // 
            this.cbTexting.AutoSize = true;
            this.cbTexting.Location = new System.Drawing.Point(22, 36);
            this.cbTexting.Name = "cbTexting";
            this.cbTexting.Size = new System.Drawing.Size(57, 21);
            this.cbTexting.TabIndex = 1;
            this.cbTexting.Text = "Text";
            this.cbTexting.UseVisualStyleBackColor = true;
            // 
            // cbEmail
            // 
            this.cbEmail.AutoSize = true;
            this.cbEmail.Location = new System.Drawing.Point(114, 36);
            this.cbEmail.Name = "cbEmail";
            this.cbEmail.Size = new System.Drawing.Size(64, 21);
            this.cbEmail.TabIndex = 0;
            this.cbEmail.Text = "Email";
            this.cbEmail.UseVisualStyleBackColor = true;
            // 
            // lblReminderPeriods
            // 
            this.lblReminderPeriods.AutoSize = true;
            this.lblReminderPeriods.Location = new System.Drawing.Point(75, 129);
            this.lblReminderPeriods.Name = "lblReminderPeriods";
            this.lblReminderPeriods.Size = new System.Drawing.Size(125, 17);
            this.lblReminderPeriods.TabIndex = 8;
            this.lblReminderPeriods.Text = "Reminder Periods:";
            this.tltpReminderPeriods.SetToolTip(this.lblReminderPeriods, "This specifies how many days, before the due date, that you want a reminder to be" +
        " sent to you.\r\n");
            // 
            // tbReminderPeriods
            // 
            this.tbReminderPeriods.Location = new System.Drawing.Point(206, 126);
            this.tbReminderPeriods.Name = "tbReminderPeriods";
            this.tbReminderPeriods.Size = new System.Drawing.Size(200, 22);
            this.tbReminderPeriods.TabIndex = 7;
            this.tltpReminderPeriods.SetToolTip(this.tbReminderPeriods, "This specifies how many days, before the due date, that you want a reminder to be" +
        " sent to you.\r\n");
            // 
            // lblReminderPeriodTip
            // 
            this.lblReminderPeriodTip.AutoSize = true;
            this.lblReminderPeriodTip.Location = new System.Drawing.Point(136, 151);
            this.lblReminderPeriodTip.Name = "lblReminderPeriodTip";
            this.lblReminderPeriodTip.Size = new System.Drawing.Size(324, 17);
            this.lblReminderPeriodTip.TabIndex = 9;
            this.lblReminderPeriodTip.Text = "( To add multiple values, serperate values with \',\' )";
            // 
            // lblReminderUpdatePeriod
            // 
            this.lblReminderUpdatePeriod.AutoSize = true;
            this.lblReminderUpdatePeriod.Location = new System.Drawing.Point(32, 189);
            this.lblReminderUpdatePeriod.Name = "lblReminderUpdatePeriod";
            this.lblReminderUpdatePeriod.Size = new System.Drawing.Size(168, 17);
            this.lblReminderUpdatePeriod.TabIndex = 11;
            this.lblReminderUpdatePeriod.Text = "Reminder Update Period:";
            // 
            // tbReminderUpdatePeriod
            // 
            this.tbReminderUpdatePeriod.Location = new System.Drawing.Point(206, 186);
            this.tbReminderUpdatePeriod.Name = "tbReminderUpdatePeriod";
            this.tbReminderUpdatePeriod.Size = new System.Drawing.Size(200, 22);
            this.tbReminderUpdatePeriod.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 441);
            this.Controls.Add(this.lblReminderUpdatePeriod);
            this.Controls.Add(this.tbReminderUpdatePeriod);
            this.Controls.Add(this.lblReminderPeriodTip);
            this.Controls.Add(this.lblReminderPeriods);
            this.Controls.Add(this.tbReminderPeriods);
            this.Controls.Add(this.gbxContactPreferences);
            this.Controls.Add(this.cbStopExit);
            this.Controls.Add(this.btnAddReminder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpRenewalDate);
            this.Controls.Add(this.tbReminderName);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reminders";
            this.gbxContactPreferences.ResumeLayout(false);
            this.gbxContactPreferences.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbxContactPreferences;
        private System.Windows.Forms.CheckBox cbTexting;
        private System.Windows.Forms.CheckBox cbEmail;
        private System.Windows.Forms.Label lblReminderPeriods;
        private System.Windows.Forms.ToolTip tltpReminderPeriods;
        private System.Windows.Forms.TextBox tbReminderPeriods;
        private System.Windows.Forms.Label lblReminderPeriodTip;
        private System.Windows.Forms.Label lblReminderUpdatePeriod;
        private System.Windows.Forms.TextBox tbReminderUpdatePeriod;
    }
}

