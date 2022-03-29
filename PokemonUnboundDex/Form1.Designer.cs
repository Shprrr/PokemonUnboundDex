
namespace PokemonUnboundDex
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
            this.flpSearchType = new System.Windows.Forms.FlowLayoutPanel();
            this.rbSearchPokemon = new System.Windows.Forms.RadioButton();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.panSearch = new System.Windows.Forms.Panel();
            this.flpSearchType.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpSearchType
            // 
            this.flpSearchType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpSearchType.AutoSize = true;
            this.flpSearchType.Controls.Add(this.rbSearchPokemon);
            this.flpSearchType.Location = new System.Drawing.Point(12, 12);
            this.flpSearchType.Name = "flpSearchType";
            this.flpSearchType.Size = new System.Drawing.Size(776, 25);
            this.flpSearchType.TabIndex = 0;
            // 
            // rbSearchPokemon
            // 
            this.rbSearchPokemon.AutoSize = true;
            this.rbSearchPokemon.Location = new System.Drawing.Point(3, 3);
            this.rbSearchPokemon.Name = "rbSearchPokemon";
            this.rbSearchPokemon.Size = new System.Drawing.Size(76, 19);
            this.rbSearchPokemon.TabIndex = 0;
            this.rbSearchPokemon.TabStop = true;
            this.rbSearchPokemon.Text = "Pokémon";
            this.rbSearchPokemon.UseVisualStyleBackColor = true;
            this.rbSearchPokemon.CheckedChanged += new System.EventHandler(this.rbSearchPokemon_CheckedChanged);
            // 
            // cboSearch
            // 
            this.cboSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(12, 43);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(776, 23);
            this.cboSearch.TabIndex = 1;
            this.cboSearch.SelectedIndexChanged += new System.EventHandler(this.cboSearch_SelectedIndexChanged);
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.Location = new System.Drawing.Point(12, 72);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(776, 366);
            this.panSearch.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panSearch);
            this.Controls.Add(this.cboSearch);
            this.Controls.Add(this.flpSearchType);
            this.Name = "Form1";
            this.Text = "Pokémon Unbound Dex";
            this.flpSearchType.ResumeLayout(false);
            this.flpSearchType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSearchType;
        private System.Windows.Forms.RadioButton rbSearchPokemon;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.Panel panSearch;
    }
}

