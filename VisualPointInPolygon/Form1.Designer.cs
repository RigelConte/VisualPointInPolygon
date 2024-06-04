namespace VisualPointInPolygon
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Point pointToCheck;

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
            cbbAlgorithms = new ComboBox();
            lblStatus = new Label();
            pnlCanvas = new Panel();
            lblEnunciate_01 = new Label();
            btnGeneratePolygon = new Button();
            SuspendLayout();
            // 
            // cbbAlgorithms
            // 
            cbbAlgorithms.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbAlgorithms.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbAlgorithms.FormattingEnabled = true;
            cbbAlgorithms.ImeMode = ImeMode.Disable;
            cbbAlgorithms.Items.AddRange(new object[] { "Ray Casting", "Winding Number", "Angle Summation" });
            cbbAlgorithms.Location = new Point(631, 74);
            cbbAlgorithms.Name = "cbbAlgorithms";
            cbbAlgorithms.Size = new Size(217, 23);
            cbbAlgorithms.TabIndex = 2;
            cbbAlgorithms.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblStatus.Location = new Point(631, 131);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 36);
            lblStatus.TabIndex = 0;
            // 
            // pnlCanvas
            // 
            pnlCanvas.BackColor = SystemColors.ActiveCaptionText;
            pnlCanvas.Location = new Point(12, 47);
            pnlCanvas.Name = "pnlCanvas";
            pnlCanvas.Size = new Size(595, 480);
            pnlCanvas.TabIndex = 1;
            pnlCanvas.Paint += panel1_Paint;
            pnlCanvas.MouseClick += panel1_MouseClick;
            // 
            // lblEnunciate_01
            // 
            lblEnunciate_01.AutoSize = true;
            lblEnunciate_01.Location = new Point(631, 47);
            lblEnunciate_01.Name = "lblEnunciate_01";
            lblEnunciate_01.Size = new Size(161, 15);
            lblEnunciate_01.TabIndex = 3;
            lblEnunciate_01.Text = "Choose the algorithm to test:";
            // 
            // btnGeneratePolygon
            // 
            btnGeneratePolygon.Location = new Point(631, 105);
            btnGeneratePolygon.Name = "btnGeneratePolygon";
            btnGeneratePolygon.Size = new Size(217, 23);
            btnGeneratePolygon.TabIndex = 4;
            btnGeneratePolygon.Text = "Generate New Polygon";
            btnGeneratePolygon.UseVisualStyleBackColor = true;
            btnGeneratePolygon.Click += btnRegeneratePolygon_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 550);
            Controls.Add(btnGeneratePolygon);
            Controls.Add(lblEnunciate_01);
            Controls.Add(cbbAlgorithms);
            Controls.Add(pnlCanvas);
            Controls.Add(lblStatus);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Point in Polygon Example";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Panel pnlCanvas;
        private ComboBox cbbAlgorithms;
        private Label lblEnunciate_01;
        private Button btnGeneratePolygon;
    }
}
