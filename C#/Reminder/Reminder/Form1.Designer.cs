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
            this.tbReminderDescription = new System.Windows.Forms.TextBox();
            this.dtpReminderDate = new System.Windows.Forms.DateTimePicker();
            this.lblReminderDescription = new System.Windows.Forms.Label();
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
            this.lblReminderUpdatePeriodHelp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxContactPreferences.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbReminderDescription
            // 
            this.tbReminderDescription.Location = new System.Drawing.Point(206, 70);
            this.tbReminderDescription.Name = "tbReminderDescription";
            this.tbReminderDescription.Size = new System.Drawing.Size(200, 22);
            this.tbReminderDescription.TabIndex = 0;
            // 
            // dtpReminderDate
            // 
            this.dtpReminderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReminderDate.Location = new System.Drawing.Point(206, 98);
            this.dtpReminderDate.Name = "dtpReminderDate";
            this.dtpReminderDate.Size = new System.Drawing.Size(200, 22);
            this.dtpReminderDate.TabIndex = 1;
            this.dtpReminderDate.Value = new System.DateTime(2017, 1, 26, 13, 4, 22, 927);
            // 
            // lblReminderDescription
            // 
            this.lblReminderDescription.AutoSize = true;
            this.lblReminderDescription.Location = new System.Drawing.Point(52, 73);
            this.lblReminderDescription.Name = "lblReminderDescription";
            this.lblReminderDescription.Size = new System.Drawing.Size(148, 17);
            this.lblReminderDescription.TabIndex = 2;
            this.lblReminderDescription.Text = "Reminder Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reminder Date:";
            // 
            // btnAddReminder
            // 
            this.btnAddReminder.Location = new System.Drawing.Point(292, 369);
            this.btnAddReminder.Name = "btnAddReminder";
            this.btnAddReminder.Size = new System.Drawing.Size(114, 30);
            this.btnAddReminder.TabIndex = 6;
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
            this.cbStopExit.Location = new System.Drawing.Point(12, 408);
            this.cbStopExit.Name = "cbStopExit";
            this.cbStopExit.Size = new System.Drawing.Size(185, 21);
            this.cbStopExit.TabIndex = 7;
            this.cbStopExit.Text = "Stop Auto Exit ( Ctrl + q )";
            this.cbStopExit.UseVisualStyleBackColor = true;
            this.cbStopExit.CheckedChanged += new System.EventHandler(this.cbStopExit_CheckedChanged);
            // 
            // gbxContactPreferences
            // 
            this.gbxContactPreferences.Controls.Add(this.cbTexting);
            this.gbxContactPreferences.Controls.Add(this.cbEmail);
            this.gbxContactPreferences.Location = new System.Drawing.Point(206, 258);
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
            this.cbTexting.TabIndex = 4;
            this.cbTexting.Text = "Text";
            this.cbTexting.UseVisualStyleBackColor = true;
            // 
            // cbEmail
            // 
            this.cbEmail.AutoSize = true;
            this.cbEmail.Location = new System.Drawing.Point(114, 36);
            this.cbEmail.Name = "cbEmail";
            this.cbEmail.Size = new System.Drawing.Size(64, 21);
            this.cbEmail.TabIndex = 5;
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
            this.tbReminderPeriods.TabIndex = 2;
            this.tltpReminderPeriods.SetToolTip(this.tbReminderPeriods, "This specifies how many days, before the due date, that you want a reminder to be" +
        " sent to you.\r\n");
            // 
            // lblReminderPeriodTip
            // 
            this.lblReminderPeriodTip.AutoSize = true;
            this.lblReminderPeriodTip.ForeColor = System.Drawing.Color.Red;
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
            this.tbReminderUpdatePeriod.TabIndex = 3;
            // 
            // lblReminderUpdatePeriodHelp
            // 
            this.lblReminderUpdatePeriodHelp.AutoSize = true;
            this.lblReminderUpdatePeriodHelp.ForeColor = System.Drawing.Color.Red;
            this.lblReminderUpdatePeriodHelp.Location = new System.Drawing.Point(94, 211);
            this.lblReminderUpdatePeriodHelp.Name = "lblReminderUpdatePeriodHelp";
            this.lblReminderUpdatePeriodHelp.Size = new System.Drawing.Size(405, 17);
            this.lblReminderUpdatePeriodHelp.TabIndex = 12;
            this.lblReminderUpdatePeriodHelp.Text = "( Specify every month or day or year. e.g. 1 month or 23 days )";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(171, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "( Leave blank if it is a one time reminder )";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReminderUpdatePeriodHelp);
            this.Controls.Add(this.lblReminderUpdatePeriod);
            this.Controls.Add(this.tbReminderUpdatePeriod);
            this.Controls.Add(this.lblReminderPeriodTip);
            this.Controls.Add(this.lblReminderPeriods);
            this.Controls.Add(this.tbReminderPeriods);
            this.Controls.Add(this.gbxContactPreferences);
            this.Controls.Add(this.cbStopExit);
            this.Controls.Add(this.btnAddReminder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblReminderDescription);
            this.Controls.Add(this.dtpReminderDate);
            this.Controls.Add(this.tbReminderDescription);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reminders";
            this.gbxContactPreferences.ResumeLayout(false);
            this.gbxContactPreferences.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbReminderDescription;
        private System.Windows.Forms.DateTimePicker dtpReminderDate;
        private System.Windows.Forms.Label lblReminderDescription;
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
        private System.Windows.Forms.Label lblReminderUpdatePeriodHelp;
        private System.Windows.Forms.Label label1;
    }
}

