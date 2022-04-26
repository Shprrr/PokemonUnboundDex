
namespace PokemonUnboundDex
{
    partial class PokemonSummary
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
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tlpAbilities = new System.Windows.Forms.TableLayoutPanel();
            this.lblAbility1 = new System.Windows.Forms.Label();
            this.lblAbility2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panLevelUpMoves = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHiddenAbility = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.tlpAbilities.SuspendLayout();
            this.panLevelUpMoves.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 18);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(291, 246);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Level";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Move";
            this.columnHeader2.Width = 200;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.tlpAbilities, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panLevelUpMoves, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblHiddenAbility, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(300, 300);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // tlpAbilities
            // 
            this.tlpAbilities.AutoSize = true;
            this.tlpAbilities.ColumnCount = 2;
            this.tlpAbilities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAbilities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAbilities.Controls.Add(this.lblAbility1, 0, 0);
            this.tlpAbilities.Controls.Add(this.lblAbility2, 1, 0);
            this.tlpAbilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAbilities.Location = new System.Drawing.Point(89, 0);
            this.tlpAbilities.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAbilities.Name = "tlpAbilities";
            this.tlpAbilities.RowCount = 1;
            this.tlpAbilities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAbilities.Size = new System.Drawing.Size(211, 15);
            this.tlpAbilities.TabIndex = 5;
            // 
            // lblAbility1
            // 
            this.lblAbility1.AutoSize = true;
            this.lblAbility1.Location = new System.Drawing.Point(3, 0);
            this.lblAbility1.Name = "lblAbility1";
            this.lblAbility1.Size = new System.Drawing.Size(47, 15);
            this.lblAbility1.TabIndex = 3;
            this.lblAbility1.Text = "Ability1";
            // 
            // lblAbility2
            // 
            this.lblAbility2.AutoSize = true;
            this.lblAbility2.Location = new System.Drawing.Point(108, 0);
            this.lblAbility2.Name = "lblAbility2";
            this.lblAbility2.Size = new System.Drawing.Size(47, 15);
            this.lblAbility2.TabIndex = 4;
            this.lblAbility2.Text = "Ability2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Abilities";
            // 
            // panLevelUpMoves
            // 
            this.tableLayoutPanel.SetColumnSpan(this.panLevelUpMoves, 2);
            this.panLevelUpMoves.Controls.Add(this.label2);
            this.panLevelUpMoves.Controls.Add(this.listView);
            this.panLevelUpMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLevelUpMoves.Location = new System.Drawing.Point(3, 33);
            this.panLevelUpMoves.Name = "panLevelUpMoves";
            this.panLevelUpMoves.Size = new System.Drawing.Size(294, 264);
            this.panLevelUpMoves.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Moves by level up";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hidden Ability";
            // 
            // lblHiddenAbility
            // 
            this.lblHiddenAbility.AutoSize = true;
            this.lblHiddenAbility.Location = new System.Drawing.Point(92, 15);
            this.lblHiddenAbility.Name = "lblHiddenAbility";
            this.lblHiddenAbility.Size = new System.Drawing.Size(80, 15);
            this.lblHiddenAbility.TabIndex = 7;
            this.lblHiddenAbility.Text = "HiddenAbility";
            // 
            // PokemonSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "PokemonSummary";
            this.Size = new System.Drawing.Size(300, 300);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tlpAbilities.ResumeLayout(false);
            this.tlpAbilities.PerformLayout();
            this.panLevelUpMoves.ResumeLayout(false);
            this.panLevelUpMoves.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panLevelUpMoves;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tlpAbilities;
        private System.Windows.Forms.Label lblAbility1;
        private System.Windows.Forms.Label lblAbility2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHiddenAbility;
    }
}
