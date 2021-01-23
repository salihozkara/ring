
namespace VeritabaniProje
{
    partial class FrmKullanıcılar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKullanıcılar));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kullaniciAdiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorselDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.adminDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kullaniciIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSil = new System.Windows.Forms.DataGridViewImageColumn();
            this.kullaniciListeleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ring2DataSet = new VeritabaniProje.ring2DataSet();
            this.kullaniciListeleTableAdapter = new VeritabaniProje.ring2DataSetTableAdapters.KullaniciListeleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciListeleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ring2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kullaniciAdiDataGridViewTextBoxColumn,
            this.gorselDataGridViewImageColumn,
            this.adminDataGridViewCheckBoxColumn,
            this.kullaniciIDDataGridViewTextBoxColumn,
            this.ColumnSil});
            this.dataGridView1.DataSource = this.kullaniciListeleBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(337, 328);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // kullaniciAdiDataGridViewTextBoxColumn
            // 
            this.kullaniciAdiDataGridViewTextBoxColumn.DataPropertyName = "KullaniciAdi";
            this.kullaniciAdiDataGridViewTextBoxColumn.HeaderText = "KullaniciAdi";
            this.kullaniciAdiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kullaniciAdiDataGridViewTextBoxColumn.Name = "kullaniciAdiDataGridViewTextBoxColumn";
            this.kullaniciAdiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gorselDataGridViewImageColumn
            // 
            this.gorselDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.gorselDataGridViewImageColumn.DataPropertyName = "Gorsel";
            this.gorselDataGridViewImageColumn.HeaderText = "Gorsel";
            this.gorselDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.gorselDataGridViewImageColumn.MinimumWidth = 6;
            this.gorselDataGridViewImageColumn.Name = "gorselDataGridViewImageColumn";
            this.gorselDataGridViewImageColumn.ReadOnly = true;
            this.gorselDataGridViewImageColumn.Width = 56;
            // 
            // adminDataGridViewCheckBoxColumn
            // 
            this.adminDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.adminDataGridViewCheckBoxColumn.DataPropertyName = "Admin";
            this.adminDataGridViewCheckBoxColumn.FalseValue = "false";
            this.adminDataGridViewCheckBoxColumn.HeaderText = "Admin";
            this.adminDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.adminDataGridViewCheckBoxColumn.Name = "adminDataGridViewCheckBoxColumn";
            this.adminDataGridViewCheckBoxColumn.TrueValue = "true";
            this.adminDataGridViewCheckBoxColumn.Width = 53;
            // 
            // kullaniciIDDataGridViewTextBoxColumn
            // 
            this.kullaniciIDDataGridViewTextBoxColumn.DataPropertyName = "kullaniciID";
            this.kullaniciIDDataGridViewTextBoxColumn.HeaderText = "kullaniciID";
            this.kullaniciIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kullaniciIDDataGridViewTextBoxColumn.Name = "kullaniciIDDataGridViewTextBoxColumn";
            this.kullaniciIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.kullaniciIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // ColumnSil
            // 
            this.ColumnSil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnSil.HeaderText = "Kullanıcı Sil";
            this.ColumnSil.Image = global::VeritabaniProje.Properties.Resources.trash_alt_solid;
            this.ColumnSil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnSil.MinimumWidth = 6;
            this.ColumnSil.Name = "ColumnSil";
            this.ColumnSil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSil.Width = 85;
            // 
            // kullaniciListeleBindingSource
            // 
            this.kullaniciListeleBindingSource.DataMember = "KullaniciListele";
            this.kullaniciListeleBindingSource.DataSource = this.ring2DataSet;
            // 
            // ring2DataSet
            // 
            this.ring2DataSet.DataSetName = "ring2DataSet";
            this.ring2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kullaniciListeleTableAdapter
            // 
            this.kullaniciListeleTableAdapter.ClearBeforeFill = true;
            // 
            // FrmKullanıcılar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(337, 328);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKullanıcılar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcılar";
            this.Load += new System.EventHandler(this.FrmKullanıcılar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciListeleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ring2DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ring2DataSet ring2DataSet;
        private System.Windows.Forms.BindingSource kullaniciListeleBindingSource;
        private ring2DataSetTableAdapters.KullaniciListeleTableAdapter kullaniciListeleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciAdiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn gorselDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn adminDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn ColumnSil;
    }
}