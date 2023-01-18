
namespace Demo4BikeStores
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
            this.DataView = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.CatList = new System.Windows.Forms.ComboBox();
            this.BrandList = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataView
            // 
            this.DataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete});
            this.DataView.Location = new System.Drawing.Point(18, 257);
            this.DataView.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DataView.Name = "DataView";
            this.DataView.RowHeadersVisible = false;
            this.DataView.RowHeadersWidth = 51;
            this.DataView.RowTemplate.Height = 29;
            this.DataView.Size = new System.Drawing.Size(1164, 290);
            this.DataView.TabIndex = 0;
            this.DataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_CellContentClick);
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete";
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Price";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(18, 203);
            this.name.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(370, 30);
            this.name.TabIndex = 3;
            this.name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(442, 203);
            this.price.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(158, 30);
            this.price.TabIndex = 4;
            this.price.Text = "0";
            // 
            // CatList
            // 
            this.CatList.FormattingEnabled = true;
            this.CatList.Location = new System.Drawing.Point(18, 135);
            this.CatList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CatList.Name = "CatList";
            this.CatList.Size = new System.Drawing.Size(369, 33);
            this.CatList.TabIndex = 5;
            // 
            // BrandList
            // 
            this.BrandList.FormattingEnabled = true;
            this.BrandList.Location = new System.Drawing.Point(442, 135);
            this.BrandList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BrandList.Name = "BrandList";
            this.BrandList.Size = new System.Drawing.Size(369, 33);
            this.BrandList.TabIndex = 6;
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Green;
            this.Save.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Save.Location = new System.Drawing.Point(694, 199);
            this.Save.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(118, 36);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Catagories";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Brands";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(327, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(335, 46);
            this.label5.TabIndex = 1;
            this.label5.Text = "Add new product";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 562);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.BrandList);
            this.Controls.Add(this.CatList);
            this.Controls.Add(this.price);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.ComboBox CatList;
        private System.Windows.Forms.ComboBox BrandList;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveAll;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}

