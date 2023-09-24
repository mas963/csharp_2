namespace WinFormsApp1
{
    partial class Form2
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
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            dateTimeEnd = new DateTimePicker();
            dateTimeStart = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.LightSalmon;
            label1.Location = new Point(21, 37);
            label1.Name = "label1";
            label1.Size = new Size(62, 31);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Yu Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitle.Location = new Point(125, 30);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(344, 38);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Yu Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.LightSalmon;
            label2.Location = new Point(21, 106);
            label2.Name = "label2";
            label2.Size = new Size(67, 31);
            label2.TabIndex = 2;
            label2.Text = "Start";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Yu Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.LightSalmon;
            label3.Location = new Point(21, 176);
            label3.Name = "label3";
            label3.Size = new Size(57, 31);
            label3.TabIndex = 4;
            label3.Text = "End";
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(21, 388);
            button1.Name = "button1";
            button1.Size = new Size(448, 50);
            button1.TabIndex = 6;
            button1.Text = "Add Event";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimeEnd
            // 
            dateTimeEnd.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dateTimeEnd.Font = new Font("Yu Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeEnd.Format = DateTimePickerFormat.Custom;
            dateTimeEnd.Location = new Point(125, 172);
            dateTimeEnd.Name = "dateTimeEnd";
            dateTimeEnd.Size = new Size(344, 38);
            dateTimeEnd.TabIndex = 7;
            // 
            // dateTimeStart
            // 
            dateTimeStart.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dateTimeStart.Font = new Font("Yu Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeStart.Format = DateTimePickerFormat.Custom;
            dateTimeStart.Location = new Point(125, 102);
            dateTimeStart.Name = "dateTimeStart";
            dateTimeStart.Size = new Size(344, 38);
            dateTimeStart.TabIndex = 8;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Vector_colorful_modern_gradient_background_design;
            ClientSize = new Size(481, 450);
            Controls.Add(dateTimeStart);
            Controls.Add(dateTimeEnd);
            Controls.Add(button1);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private Label label3;
        private Button button1;
        private DateTimePicker dateTimeEnd;
        private DateTimePicker dateTimeStart;
    }
}