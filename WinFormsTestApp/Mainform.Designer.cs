namespace WinFormsTestApp
{
    partial class Mainform
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
            CallWcfService = new Button();
            CallWcfGetComposite = new Button();
            CallApiGetData = new Button();
            SuspendLayout();
            // 
            // CallWcfService
            // 
            CallWcfService.Location = new Point(49, 38);
            CallWcfService.Name = "CallWcfService";
            CallWcfService.Size = new Size(299, 55);
            CallWcfService.TabIndex = 0;
            CallWcfService.Text = "Call Wcf Service -get data";
            CallWcfService.UseMnemonic = false;
            CallWcfService.UseVisualStyleBackColor = true;
            CallWcfService.Click += CallWcfService_Click;
            // 
            // CallWcfGetComposite
            // 
            CallWcfGetComposite.Location = new Point(56, 124);
            CallWcfGetComposite.Name = "CallWcfGetComposite";
            CallWcfGetComposite.Size = new Size(292, 48);
            CallWcfGetComposite.TabIndex = 1;
            CallWcfGetComposite.Text = "Call Wcf Service - get composite";
            CallWcfGetComposite.UseVisualStyleBackColor = true;
            CallWcfGetComposite.Click += CallWcfGetComposite_Click;
            // 
            // CallApiGetData
            // 
            CallApiGetData.Location = new Point(426, 121);
            CallApiGetData.Name = "CallApiGetData";
            CallApiGetData.Size = new Size(299, 55);
            CallApiGetData.TabIndex = 2;
            CallApiGetData.Text = "Call Api ";
            CallApiGetData.UseMnemonic = false;
            CallApiGetData.UseVisualStyleBackColor = true;
            CallApiGetData.Click += CallApiGetData_Click;
            // 
            // Mainform
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 649);
            Controls.Add(CallApiGetData);
            Controls.Add(CallWcfGetComposite);
            Controls.Add(CallWcfService);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "Mainform";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button CallWcfService;
        private Button CallWcfGetComposite;
        private Button CallApiGetData;
    }
}
