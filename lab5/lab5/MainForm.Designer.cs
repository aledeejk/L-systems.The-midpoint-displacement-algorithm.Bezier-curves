namespace LSystemApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLSystem = new System.Windows.Forms.TabPage();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.numRandom = new System.Windows.Forms.NumericUpDown();
            this.lblRandom = new System.Windows.Forms.Label();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.lblIterations = new System.Windows.Forms.Label();
            this.cmbPresets = new System.Windows.Forms.ComboBox();
            this.lblPreset = new System.Windows.Forms.Label();
            this.tabPageMidpoint = new System.Windows.Forms.TabPage();
            this.tabPageBezier = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPageLSystem.SuspendLayout();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageLSystem);
            this.tabControl.Controls.Add(this.tabPageMidpoint);
            this.tabControl.Controls.Add(this.tabPageBezier);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 750);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageLSystem
            // 
            this.tabPageLSystem.Controls.Add(this.panelCanvas);
            this.tabPageLSystem.Controls.Add(this.panelControls);
            this.tabPageLSystem.Location = new System.Drawing.Point(4, 25);
            this.tabPageLSystem.Name = "tabPageLSystem";
            this.tabPageLSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLSystem.Size = new System.Drawing.Size(992, 721);
            this.tabPageLSystem.TabIndex = 0;
            this.tabPageLSystem.Text = "L-системы";
            this.tabPageLSystem.UseVisualStyleBackColor = true;
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCanvas.Location = new System.Drawing.Point(3, 63);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(986, 655);
            this.panelCanvas.TabIndex = 1;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.lblInfo);
            this.panelControls.Controls.Add(this.btnRedraw);
            this.panelControls.Controls.Add(this.btnLoad);
            this.panelControls.Controls.Add(this.numRandom);
            this.panelControls.Controls.Add(this.lblRandom);
            this.panelControls.Controls.Add(this.chkRandom);
            this.panelControls.Controls.Add(this.numIterations);
            this.panelControls.Controls.Add(this.lblIterations);
            this.panelControls.Controls.Add(this.cmbPresets);
            this.panelControls.Controls.Add(this.lblPreset);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(3, 3);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(986, 60);
            this.panelControls.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(850, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(55, 16);
            this.lblInfo.TabIndex = 9;
            this.lblInfo.Text = "Готово";
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(720, 15);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(120, 30);
            this.btnRedraw.TabIndex = 8;
            this.btnRedraw.Text = "Перерисовать";
            this.btnRedraw.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(560, 15);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(150, 30);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Загрузить из файла...";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // numRandom
            // 
            this.numRandom.Enabled = false;
            this.numRandom.Location = new System.Drawing.Point(490, 18);
            this.numRandom.Name = "numRandom";
            this.numRandom.Size = new System.Drawing.Size(60, 22);
            this.numRandom.TabIndex = 6;
            this.numRandom.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // lblRandom
            // 
            this.lblRandom.AutoSize = true;
            this.lblRandom.Location = new System.Drawing.Point(460, 22);
            this.lblRandom.Name = "lblRandom";
            this.lblRandom.Size = new System.Drawing.Size(20, 16);
            this.lblRandom.TabIndex = 5;
            this.lblRandom.Text = "%";
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.Location = new System.Drawing.Point(350, 20);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(110, 20);
            this.chkRandom.TabIndex = 4;
            this.chkRandom.Text = "Случайность";
            this.chkRandom.UseVisualStyleBackColor = true;
            // 
            // numIterations
            // 
            this.numIterations.Location = new System.Drawing.Point(280, 18);
            this.numIterations.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(60, 22);
            this.numIterations.TabIndex = 3;
            this.numIterations.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(190, 22);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(80, 16);
            this.lblIterations.TabIndex = 2;
            this.lblIterations.Text = "Итераций:";
            // 
            // cmbPresets
            // 
            this.cmbPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPresets.FormattingEnabled = true;
            this.cmbPresets.Location = new System.Drawing.Point(70, 18);
            this.cmbPresets.Name = "cmbPresets";
            this.cmbPresets.Size = new System.Drawing.Size(110, 24);
            this.cmbPresets.TabIndex = 1;
            // 
            // lblPreset
            // 
            this.lblPreset.AutoSize = true;
            this.lblPreset.Location = new System.Drawing.Point(10, 22);
            this.lblPreset.Name = "lblPreset";
            this.lblPreset.Size = new System.Drawing.Size(55, 16);
            this.lblPreset.TabIndex = 0;
            this.lblPreset.Text = "Шаблон:";
            // 
            // tabPageMidpoint
            // 
            this.tabPageMidpoint.Location = new System.Drawing.Point(4, 25);
            this.tabPageMidpoint.Name = "tabPageMidpoint";
            this.tabPageMidpoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMidpoint.Size = new System.Drawing.Size(992, 721);
            this.tabPageMidpoint.TabIndex = 1;
            this.tabPageMidpoint.Text = "Midpoint displacement";
            this.tabPageMidpoint.UseVisualStyleBackColor = true;
            // 
            // tabPageBezier
            // 
            this.tabPageBezier.Location = new System.Drawing.Point(4, 25);
            this.tabPageBezier.Name = "tabPageBezier";
            this.tabPageBezier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBezier.Size = new System.Drawing.Size(992, 721);
            this.tabPageBezier.TabIndex = 2;
            this.tabPageBezier.Text = "Кривые Безье";
            this.tabPageBezier.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Компьютерная графика — фракталы и кривые";
            this.tabControl.ResumeLayout(false);
            this.tabPageLSystem.ResumeLayout(false);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLSystem;
        private System.Windows.Forms.TabPage tabPageMidpoint;
        private System.Windows.Forms.TabPage tabPageBezier;

        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblPreset;
        private System.Windows.Forms.ComboBox cmbPresets;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.CheckBox chkRandom;
        private System.Windows.Forms.Label lblRandom;
        private System.Windows.Forms.NumericUpDown numRandom;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.Label lblInfo;
    }
}