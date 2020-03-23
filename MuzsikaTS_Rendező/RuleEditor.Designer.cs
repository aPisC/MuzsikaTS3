namespace MuzsikaTS_Rendező
{
    partial class RuleEditor
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
            this.cbRuleMode = new System.Windows.Forms.ComboBox();
            this.cbRuleTarget = new System.Windows.Forms.ComboBox();
            this.tbRuleValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbRuleMode
            // 
            this.cbRuleMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRuleMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRuleMode.FormattingEnabled = true;
            this.cbRuleMode.Location = new System.Drawing.Point(12, 12);
            this.cbRuleMode.Name = "cbRuleMode";
            this.cbRuleMode.Size = new System.Drawing.Size(127, 21);
            this.cbRuleMode.TabIndex = 0;
            this.cbRuleMode.SelectedIndexChanged += new System.EventHandler(this.cbRuleMode_SelectedIndexChanged);
            // 
            // cbRuleTarget
            // 
            this.cbRuleTarget.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRuleTarget.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRuleTarget.FormattingEnabled = true;
            this.cbRuleTarget.Location = new System.Drawing.Point(145, 12);
            this.cbRuleTarget.Name = "cbRuleTarget";
            this.cbRuleTarget.Size = new System.Drawing.Size(127, 21);
            this.cbRuleTarget.TabIndex = 1;
            this.cbRuleTarget.SelectedIndexChanged += new System.EventHandler(this.cbRuleTarget_SelectedIndexChanged);
            // 
            // tbRuleValue
            // 
            this.tbRuleValue.Location = new System.Drawing.Point(12, 39);
            this.tbRuleValue.Name = "tbRuleValue";
            this.tbRuleValue.Size = new System.Drawing.Size(260, 20);
            this.tbRuleValue.TabIndex = 2;
            this.tbRuleValue.TextChanged += new System.EventHandler(this.tbRuleValue_TextChanged);
            this.tbRuleValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRuleValue_KeyPress);
            // 
            // RuleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 66);
            this.Controls.Add(this.tbRuleValue);
            this.Controls.Add(this.cbRuleTarget);
            this.Controls.Add(this.cbRuleMode);
            this.Name = "RuleEditor";
            this.Text = "RuleEditor";
            this.Load += new System.EventHandler(this.RuleEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRuleMode;
        private System.Windows.Forms.ComboBox cbRuleTarget;
        private System.Windows.Forms.TextBox tbRuleValue;
    }
}