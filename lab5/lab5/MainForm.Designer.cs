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
            tabControl = new TabControl();
            tabPageLSystem = new TabPage();
            panelCanvas = new Panel();
            panelControls = new Panel();
            chkTreeStyle = new CheckBox();
            lblInfo = new Label();
            btnRedraw = new Button();
            btnLoad = new Button();
            numRandom = new NumericUpDown();
            lblRandom = new Label();
            chkRandom = new CheckBox();
            numIterations = new NumericUpDown();
            lblIterations = new Label();
            cmbPresets = new ComboBox();
            lblPreset = new Label();
            tabPageMidpoint = new TabPage();
            panelMidCanvas = new Panel();
            panelMidpointControls = new Panel();
            numMidEndPoint = new NumericUpDown();
            numMidStartPoint = new NumericUpDown();
            labelMidEndPoint = new Label();
            labelMidStartPoint = new Label();
            lblMidInfo = new Label();
            btnMidRun = new Button();
            btnMidStep = new Button();
            btnMidReset = new Button();
            labelSeed = new Label();
            numMidSeed = new NumericUpDown();
            numMidIterations = new NumericUpDown();
            labelIterations = new Label();
            numRoughness = new NumericUpDown();
            labelRoughness = new Label();
            tabPageBezier = new TabPage();
            tabControl.SuspendLayout();
            tabPageLSystem.SuspendLayout();
            panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRandom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIterations).BeginInit();
            tabPageMidpoint.SuspendLayout();
            panelMidpointControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMidEndPoint).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMidStartPoint).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMidSeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMidIterations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRoughness).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageLSystem);
            tabControl.Controls.Add(tabPageMidpoint);
            tabControl.Controls.Add(tabPageBezier);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1000, 938);
            tabControl.TabIndex = 0;
            // 
            // tabPageLSystem
            // 
            tabPageLSystem.Controls.Add(panelCanvas);
            tabPageLSystem.Controls.Add(panelControls);
            tabPageLSystem.Location = new Point(4, 29);
            tabPageLSystem.Margin = new Padding(3, 4, 3, 4);
            tabPageLSystem.Name = "tabPageLSystem";
            tabPageLSystem.Padding = new Padding(3, 4, 3, 4);
            tabPageLSystem.Size = new Size(992, 905);
            tabPageLSystem.TabIndex = 0;
            tabPageLSystem.Text = "L-системы";
            tabPageLSystem.UseVisualStyleBackColor = true;
            // 
            // panelCanvas
            // 
            panelCanvas.BackColor = Color.White;
            panelCanvas.Dock = DockStyle.Fill;
            panelCanvas.Location = new Point(3, 108);
            panelCanvas.Margin = new Padding(3, 4, 3, 4);
            panelCanvas.Name = "panelCanvas";
            panelCanvas.Size = new Size(986, 793);
            panelCanvas.TabIndex = 1;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(chkTreeStyle);
            panelControls.Controls.Add(lblInfo);
            panelControls.Controls.Add(btnRedraw);
            panelControls.Controls.Add(btnLoad);
            panelControls.Controls.Add(numRandom);
            panelControls.Controls.Add(lblRandom);
            panelControls.Controls.Add(chkRandom);
            panelControls.Controls.Add(numIterations);
            panelControls.Controls.Add(lblIterations);
            panelControls.Controls.Add(cmbPresets);
            panelControls.Controls.Add(lblPreset);
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(3, 4);
            panelControls.Margin = new Padding(3, 4, 3, 4);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(986, 104);
            panelControls.TabIndex = 0;
            panelControls.Paint += panelControls_Paint;
            // 
            // chkTreeStyle
            // 
            chkTreeStyle.AutoSize = true;
            chkTreeStyle.Location = new Point(629, 18);
            chkTreeStyle.Name = "chkTreeStyle";
            chkTreeStyle.Size = new Size(206, 24);
            chkTreeStyle.TabIndex = 10;
            chkTreeStyle.Text = "Стилизовать дерево (1.б)";
            chkTreeStyle.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(399, 71);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(57, 20);
            lblInfo.TabIndex = 9;
            lblInfo.Text = "Готово";
            // 
            // btnRedraw
            // 
            btnRedraw.Location = new Point(237, 62);
            btnRedraw.Margin = new Padding(3, 4, 3, 4);
            btnRedraw.Name = "btnRedraw";
            btnRedraw.Size = new Size(128, 38);
            btnRedraw.TabIndex = 8;
            btnRedraw.Text = "Перерисовать";
            btnRedraw.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(10, 62);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(192, 38);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Загрузить из файла...";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // numRandom
            // 
            numRandom.Enabled = false;
            numRandom.Location = new Point(534, 18);
            numRandom.Margin = new Padding(3, 4, 3, 4);
            numRandom.Name = "numRandom";
            numRandom.Size = new Size(60, 27);
            numRandom.TabIndex = 6;
            numRandom.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // lblRandom
            // 
            lblRandom.AutoSize = true;
            lblRandom.Location = new Point(507, 22);
            lblRandom.Name = "lblRandom";
            lblRandom.Size = new Size(21, 20);
            lblRandom.TabIndex = 5;
            lblRandom.Text = "%";
            // 
            // chkRandom
            // 
            chkRandom.AutoSize = true;
            chkRandom.Location = new Point(382, 21);
            chkRandom.Margin = new Padding(3, 4, 3, 4);
            chkRandom.Name = "chkRandom";
            chkRandom.Size = new Size(119, 24);
            chkRandom.TabIndex = 4;
            chkRandom.Text = "Случайность";
            chkRandom.UseVisualStyleBackColor = true;
            // 
            // numIterations
            // 
            numIterations.Location = new Point(305, 20);
            numIterations.Margin = new Padding(3, 4, 3, 4);
            numIterations.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numIterations.Name = "numIterations";
            numIterations.Size = new Size(60, 27);
            numIterations.TabIndex = 3;
            numIterations.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // lblIterations
            // 
            lblIterations.AutoSize = true;
            lblIterations.Location = new Point(218, 22);
            lblIterations.Name = "lblIterations";
            lblIterations.Size = new Size(81, 20);
            lblIterations.TabIndex = 2;
            lblIterations.Text = "Итераций:";
            // 
            // cmbPresets
            // 
            cmbPresets.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPresets.FormattingEnabled = true;
            cmbPresets.Location = new Point(85, 19);
            cmbPresets.Margin = new Padding(3, 4, 3, 4);
            cmbPresets.Name = "cmbPresets";
            cmbPresets.Size = new Size(110, 28);
            cmbPresets.TabIndex = 1;
            // 
            // lblPreset
            // 
            lblPreset.AutoSize = true;
            lblPreset.Location = new Point(10, 22);
            lblPreset.Name = "lblPreset";
            lblPreset.Size = new Size(69, 20);
            lblPreset.TabIndex = 0;
            lblPreset.Text = "Шаблон:";
            // 
            // tabPageMidpoint
            // 
            tabPageMidpoint.Controls.Add(panelMidCanvas);
            tabPageMidpoint.Controls.Add(panelMidpointControls);
            tabPageMidpoint.Location = new Point(4, 29);
            tabPageMidpoint.Margin = new Padding(3, 4, 3, 4);
            tabPageMidpoint.Name = "tabPageMidpoint";
            tabPageMidpoint.Padding = new Padding(3, 4, 3, 4);
            tabPageMidpoint.Size = new Size(992, 905);
            tabPageMidpoint.TabIndex = 1;
            tabPageMidpoint.Text = "Midpoint displacement";
            tabPageMidpoint.UseVisualStyleBackColor = true;
            // 
            // panelMidCanvas
            // 
            panelMidCanvas.Dock = DockStyle.Fill;
            panelMidCanvas.Location = new Point(3, 113);
            panelMidCanvas.Name = "panelMidCanvas";
            panelMidCanvas.Size = new Size(986, 788);
            panelMidCanvas.TabIndex = 1;
            // 
            // panelMidpointControls
            // 
            panelMidpointControls.Controls.Add(numMidEndPoint);
            panelMidpointControls.Controls.Add(numMidStartPoint);
            panelMidpointControls.Controls.Add(labelMidEndPoint);
            panelMidpointControls.Controls.Add(labelMidStartPoint);
            panelMidpointControls.Controls.Add(lblMidInfo);
            panelMidpointControls.Controls.Add(btnMidRun);
            panelMidpointControls.Controls.Add(btnMidStep);
            panelMidpointControls.Controls.Add(btnMidReset);
            panelMidpointControls.Controls.Add(labelSeed);
            panelMidpointControls.Controls.Add(numMidSeed);
            panelMidpointControls.Controls.Add(numMidIterations);
            panelMidpointControls.Controls.Add(labelIterations);
            panelMidpointControls.Controls.Add(numRoughness);
            panelMidpointControls.Controls.Add(labelRoughness);
            panelMidpointControls.Dock = DockStyle.Top;
            panelMidpointControls.Location = new Point(3, 4);
            panelMidpointControls.Name = "panelMidpointControls";
            panelMidpointControls.Size = new Size(986, 109);
            panelMidpointControls.TabIndex = 0;
            // 
            // numMidEndPoint
            // 
            numMidEndPoint.DecimalPlaces = 2;
            numMidEndPoint.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numMidEndPoint.Location = new Point(852, 17);
            numMidEndPoint.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numMidEndPoint.Name = "numMidEndPoint";
            numMidEndPoint.Size = new Size(80, 27);
            numMidEndPoint.TabIndex = 13;
            numMidEndPoint.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // numMidStartPoint
            // 
            numMidStartPoint.DecimalPlaces = 2;
            numMidStartPoint.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numMidStartPoint.Location = new Point(645, 17);
            numMidStartPoint.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numMidStartPoint.Name = "numMidStartPoint";
            numMidStartPoint.Size = new Size(80, 27);
            numMidStartPoint.TabIndex = 12;
            numMidStartPoint.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // labelMidEndPoint
            // 
            labelMidEndPoint.AutoSize = true;
            labelMidEndPoint.Location = new Point(731, 19);
            labelMidEndPoint.Name = "labelMidEndPoint";
            labelMidEndPoint.Size = new Size(115, 20);
            labelMidEndPoint.TabIndex = 11;
            labelMidEndPoint.Text = "Высота справа:";
            // 
            // labelMidStartPoint
            // 
            labelMidStartPoint.AutoSize = true;
            labelMidStartPoint.Location = new Point(534, 19);
            labelMidStartPoint.Name = "labelMidStartPoint";
            labelMidStartPoint.Size = new Size(105, 20);
            labelMidStartPoint.TabIndex = 10;
            labelMidStartPoint.Text = "Высота слева:";
            labelMidStartPoint.Click += labelMidStartPoint_Click;
            // 
            // lblMidInfo
            // 
            lblMidInfo.AutoSize = true;
            lblMidInfo.Location = new Point(586, 74);
            lblMidInfo.Name = "lblMidInfo";
            lblMidInfo.Size = new Size(74, 20);
            lblMidInfo.TabIndex = 9;
            lblMidInfo.Text = "Шаг: 0 / 8";
            // 
            // btnMidRun
            // 
            btnMidRun.Location = new Point(365, 68);
            btnMidRun.Name = "btnMidRun";
            btnMidRun.Size = new Size(192, 32);
            btnMidRun.TabIndex = 8;
            btnMidRun.Text = "Выполнить до конца";
            btnMidRun.UseVisualStyleBackColor = true;
            // 
            // btnMidStep
            // 
            btnMidStep.Location = new Point(157, 68);
            btnMidStep.Name = "btnMidStep";
            btnMidStep.Size = new Size(192, 32);
            btnMidStep.TabIndex = 7;
            btnMidStep.Text = "Следующий шаг";
            btnMidStep.UseVisualStyleBackColor = true;
            // 
            // btnMidReset
            // 
            btnMidReset.Location = new Point(12, 68);
            btnMidReset.Name = "btnMidReset";
            btnMidReset.Size = new Size(128, 32);
            btnMidReset.TabIndex = 6;
            btnMidReset.Text = "Сбросить";
            btnMidReset.UseVisualStyleBackColor = true;
            // 
            // labelSeed
            // 
            labelSeed.AutoSize = true;
            labelSeed.Location = new Point(397, 19);
            labelSeed.Name = "labelSeed";
            labelSeed.Size = new Size(45, 20);
            labelSeed.TabIndex = 5;
            labelSeed.Text = "Seed:";
            // 
            // numMidSeed
            // 
            numMidSeed.Location = new Point(448, 17);
            numMidSeed.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numMidSeed.Name = "numMidSeed";
            numMidSeed.Size = new Size(80, 27);
            numMidSeed.TabIndex = 4;
            // 
            // numMidIterations
            // 
            numMidIterations.Location = new Point(311, 17);
            numMidIterations.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numMidIterations.Name = "numMidIterations";
            numMidIterations.Size = new Size(80, 27);
            numMidIterations.TabIndex = 3;
            numMidIterations.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // labelIterations
            // 
            labelIterations.AutoSize = true;
            labelIterations.Location = new Point(224, 19);
            labelIterations.Name = "labelIterations";
            labelIterations.Size = new Size(81, 20);
            labelIterations.TabIndex = 2;
            labelIterations.Text = "Итераций:";
            // 
            // numRoughness
            // 
            numRoughness.DecimalPlaces = 1;
            numRoughness.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numRoughness.Location = new Point(138, 17);
            numRoughness.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numRoughness.Name = "numRoughness";
            numRoughness.Size = new Size(80, 27);
            numRoughness.TabIndex = 1;
            numRoughness.Value = new decimal(new int[] { 7, 0, 0, 65536 });
            // 
            // labelRoughness
            // 
            labelRoughness.AutoSize = true;
            labelRoughness.Location = new Point(12, 19);
            labelRoughness.Name = "labelRoughness";
            labelRoughness.Size = new Size(120, 20);
            labelRoughness.TabIndex = 0;
            labelRoughness.Text = "Шероховатость:";
            // 
            // tabPageBezier
            // 
            tabPageBezier.Location = new Point(4, 29);
            tabPageBezier.Margin = new Padding(3, 4, 3, 4);
            tabPageBezier.Name = "tabPageBezier";
            tabPageBezier.Padding = new Padding(3, 4, 3, 4);
            tabPageBezier.Size = new Size(992, 905);
            tabPageBezier.TabIndex = 2;
            tabPageBezier.Text = "Кривые Безье";
            tabPageBezier.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 938);
            Controls.Add(tabControl);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Компьютерная графика — фракталы и кривые";
            tabControl.ResumeLayout(false);
            tabPageLSystem.ResumeLayout(false);
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRandom).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIterations).EndInit();
            tabPageMidpoint.ResumeLayout(false);
            panelMidpointControls.ResumeLayout(false);
            panelMidpointControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMidEndPoint).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMidStartPoint).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMidSeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMidIterations).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRoughness).EndInit();
            ResumeLayout(false);
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
        private Panel panelMidpointControls;
        private NumericUpDown numRoughness;
        private Label labelRoughness;
        private NumericUpDown numMidIterations;
        private Label labelIterations;
        private Button btnMidRun;
        private Button btnMidStep;
        private Button btnMidReset;
        private Label labelSeed;
        private NumericUpDown numMidSeed;
        private Label lblMidInfo;
        private Panel panelMidCanvas;
        private Label labelMidEndPoint;
        private Label labelMidStartPoint;
        private NumericUpDown numMidStartPoint;
        private NumericUpDown numMidEndPoint;
        private CheckBox chkTreeStyle;
    }
}