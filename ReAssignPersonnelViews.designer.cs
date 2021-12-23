
namespace Sdmsols.XTB.ReAssignPersonnelViews
{
    partial class ReAssignPersonnelViews
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tslAbout = new System.Windows.Forms.ToolStripLabel();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.cmbSourceUsers = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chlSourceViewList = new System.Windows.Forms.CheckedListBox();
            this.btnRetrieveViews = new System.Windows.Forms.Button();
            this.cmbDestinationUsers = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTransferViews = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslAbout,
            this.tsbClose,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(2192, 52);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tslAbout
            // 
            this.tslAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslAbout.IsLink = true;
            this.tslAbout.Name = "tslAbout";
            this.tslAbout.Size = new System.Drawing.Size(180, 55);
            this.tslAbout.Text = "by MayankP";
            this.tslAbout.Click += new System.EventHandler(this.tslAbout_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(211, 55);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 62);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(28, 842);
            this.progressBar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(2129, 52);
            this.progressBar.TabIndex = 26;
            this.progressBar.Visible = false;
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.Location = new System.Drawing.Point(28, 921);
            this.StatusText.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.StatusText.Size = new System.Drawing.Size(2137, 749);
            this.StatusText.TabIndex = 27;
            // 
            // cmbSourceUsers
            // 
            this.cmbSourceUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceUsers.Enabled = false;
            this.cmbSourceUsers.FormattingEnabled = true;
            this.cmbSourceUsers.Location = new System.Drawing.Point(338, 89);
            this.cmbSourceUsers.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cmbSourceUsers.Name = "cmbSourceUsers";
            this.cmbSourceUsers.Size = new System.Drawing.Size(934, 39);
            this.cmbSourceUsers.TabIndex = 28;
            this.cmbSourceUsers.SelectedIndexChanged += new System.EventHandler(this.cmbSourceUsers_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 32);
            this.label8.TabIndex = 29;
            this.label8.Text = "Source User Or Team";
            // 
            // chlSourceViewList
            // 
            this.chlSourceViewList.FormattingEnabled = true;
            this.chlSourceViewList.Location = new System.Drawing.Point(28, 170);
            this.chlSourceViewList.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chlSourceViewList.Name = "chlSourceViewList";
            this.chlSourceViewList.Size = new System.Drawing.Size(2129, 564);
            this.chlSourceViewList.TabIndex = 38;
            // 
            // btnRetrieveViews
            // 
            this.btnRetrieveViews.Location = new System.Drawing.Point(1311, 89);
            this.btnRetrieveViews.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRetrieveViews.Name = "btnRetrieveViews";
            this.btnRetrieveViews.Size = new System.Drawing.Size(846, 55);
            this.btnRetrieveViews.TabIndex = 39;
            this.btnRetrieveViews.Text = "Refresh List of Views";
            this.btnRetrieveViews.UseVisualStyleBackColor = true;
            this.btnRetrieveViews.Click += new System.EventHandler(this.btnRetrieveViews_Click);
            // 
            // cmbDestinationUsers
            // 
            this.cmbDestinationUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinationUsers.FormattingEnabled = true;
            this.cmbDestinationUsers.Location = new System.Drawing.Point(377, 769);
            this.cmbDestinationUsers.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cmbDestinationUsers.Name = "cmbDestinationUsers";
            this.cmbDestinationUsers.Size = new System.Drawing.Size(913, 39);
            this.cmbDestinationUsers.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 772);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(342, 32);
            this.label4.TabIndex = 40;
            this.label4.Text = "Destination User Or Team";
            // 
            // btnTransferViews
            // 
            this.btnTransferViews.Location = new System.Drawing.Point(1322, 769);
            this.btnTransferViews.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnTransferViews.Name = "btnTransferViews";
            this.btnTransferViews.Size = new System.Drawing.Size(835, 55);
            this.btnTransferViews.TabIndex = 42;
            this.btnTransferViews.Text = "Transfer Selected Views to Destination User Or Team";
            this.btnTransferViews.UseVisualStyleBackColor = true;
            this.btnTransferViews.Click += new System.EventHandler(this.btnTransferViews_Click);
            // 
            // ReAssignPersonnelViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTransferViews);
            this.Controls.Add(this.cmbDestinationUsers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRetrieveViews);
            this.Controls.Add(this.chlSourceViewList);
            this.Controls.Add(this.cmbSourceUsers);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ReAssignPersonnelViews";
            this.Size = new System.Drawing.Size(2192, 1677);
            this.ConnectionUpdated += new XrmToolBox.Extensibility.PluginControlBase.ConnectionUpdatedHandler(this.ReAssignPersonnelViews_ConnectionUpdated);
            this.Load += new System.EventHandler(this.ReAssignPersonnelViews_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.ComboBox cmbSourceUsers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripLabel tslAbout;
        private System.Windows.Forms.CheckedListBox chlSourceViewList;
        private System.Windows.Forms.Button btnRetrieveViews;
        private System.Windows.Forms.ComboBox cmbDestinationUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTransferViews;
    }
}
