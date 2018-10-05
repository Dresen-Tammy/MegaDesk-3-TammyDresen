namespace MegaDesk_3_TammyDresen
{
    partial class DisplayQuote
    {
        /// <summary>
        /// This form view displays the current quote information after a successful quote add.
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
            this.btnDisplayCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDisplayCancel
            // 
            this.btnDisplayCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplayCancel.Location = new System.Drawing.Point(263, 379);
            this.btnDisplayCancel.Name = "btnDisplayCancel";
            this.btnDisplayCancel.Size = new System.Drawing.Size(130, 30);
            this.btnDisplayCancel.TabIndex = 0;
            this.btnDisplayCancel.Text = "Main Menu";
            this.btnDisplayCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDisplayCancel.UseVisualStyleBackColor = true;
            this.btnDisplayCancel.Click += new System.EventHandler(this.btnDisplayCancel_Click);
            // 
            // DisplayQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.btnDisplayCancel);
            this.Name = "DisplayQuote";
            this.Text = "DisplayQuote";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDisplayCancel;
    }
}