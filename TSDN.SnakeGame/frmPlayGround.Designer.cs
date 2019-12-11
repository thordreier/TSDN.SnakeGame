namespace TSDN.SnakeGame
{
    partial class frmPlayGround
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
            this.SuspendLayout();
            // 
            // frmPlayGround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(148, 41);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPlayGround";
            this.Text = "PlayGround";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPlayGround_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPlayGround_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayGround_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion



    }
}