namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtCalendarEvents = new Label();
            GetEvents = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.PeachPuff;
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(921, 44);
            label1.TabIndex = 0;
            label1.Text = "Upcoming Events";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCalendarEvents
            // 
            txtCalendarEvents.BackColor = Color.Transparent;
            txtCalendarEvents.Font = new Font("Yu Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtCalendarEvents.ForeColor = Color.White;
            txtCalendarEvents.Location = new Point(12, 103);
            txtCalendarEvents.Name = "txtCalendarEvents";
            txtCalendarEvents.Size = new Size(921, 338);
            txtCalendarEvents.TabIndex = 1;
            txtCalendarEvents.Text = "Upcoming Events";
            txtCalendarEvents.TextAlign = ContentAlignment.TopCenter;
            // 
            // GetEvents
            // 
            GetEvents.Enabled = true;
            GetEvents.Interval = 10000;
            GetEvents.Tick += GetEvents_Tick;
            // 
            // button2
            // 
            button2.Location = new Point(815, 12);
            button2.Name = "button2";
            button2.Size = new Size(118, 23);
            button2.TabIndex = 3;
            button2.Text = "add event form";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Vector_colorful_modern_gradient_background_design;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(945, 450);
            Controls.Add(button2);
            Controls.Add(txtCalendarEvents);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label txtCalendarEvents;
        private System.Windows.Forms.Timer GetEvents;
        private Button button2;
    }
}