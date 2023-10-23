namespace OOP_gui_figure
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pctBx = new PictureBox();
            label1 = new Label();
            lblCount = new Label();
            btnDelete = new Button();
            btnClear = new Button();
            btnDecrease = new Button();
            btnIncrease = new Button();
            btnRight = new Button();
            btnLeft = new Button();
            btnDown = new Button();
            cmBx = new ComboBox();
            btnColor = new Button();
            btnUp = new Button();
            btnGroup = new Button();
            colorDialog = new ColorDialog();
            btnCancel = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            treeVw = new TreeView();
            btnTxt = new Button();
            ((System.ComponentModel.ISupportInitialize)pctBx).BeginInit();
            SuspendLayout();
            // 
            // pctBx
            // 
            pctBx.BackColor = SystemColors.ControlLightLight;
            pctBx.Location = new Point(6, 38);
            pctBx.Name = "pctBx";
            pctBx.Size = new Size(592, 403);
            pctBx.TabIndex = 0;
            pctBx.TabStop = false;
            pctBx.Click += pctBx_Click;
            pctBx.Paint += pctBx_Paint;
            pctBx.MouseClick += pctBx_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(118, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 1;
            label1.Text = "Выберите фигуру:";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(452, 9);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(121, 15);
            lblCount.TabIndex = 2;
            lblCount.Text = "Количество фигур: 0";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(371, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(604, 6);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 7;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDecrease
            // 
            btnDecrease.BackgroundImage = Properties.Resources.minus;
            btnDecrease.BackgroundImageLayout = ImageLayout.Stretch;
            btnDecrease.FlatAppearance.BorderSize = 0;
            btnDecrease.FlatStyle = FlatStyle.Flat;
            btnDecrease.Location = new Point(604, 106);
            btnDecrease.Name = "btnDecrease";
            btnDecrease.Size = new Size(25, 25);
            btnDecrease.TabIndex = 8;
            btnDecrease.UseVisualStyleBackColor = true;
            btnDecrease.Click += btnDecrease_Click;
            // 
            // btnIncrease
            // 
            btnIncrease.BackgroundImage = Properties.Resources.plus;
            btnIncrease.BackgroundImageLayout = ImageLayout.Stretch;
            btnIncrease.FlatAppearance.BorderSize = 0;
            btnIncrease.FlatStyle = FlatStyle.Flat;
            btnIncrease.Location = new Point(654, 106);
            btnIncrease.Name = "btnIncrease";
            btnIncrease.Size = new Size(25, 25);
            btnIncrease.TabIndex = 9;
            btnIncrease.UseVisualStyleBackColor = true;
            btnIncrease.Click += btnIncrease_Click;
            // 
            // btnRight
            // 
            btnRight.BackgroundImage = Properties.Resources.arrow_right;
            btnRight.BackgroundImageLayout = ImageLayout.Stretch;
            btnRight.FlatAppearance.BorderSize = 0;
            btnRight.FlatStyle = FlatStyle.Flat;
            btnRight.Location = new Point(654, 166);
            btnRight.Name = "btnRight";
            btnRight.Size = new Size(25, 25);
            btnRight.TabIndex = 11;
            btnRight.UseVisualStyleBackColor = true;
            btnRight.Click += btnRight_Click;
            // 
            // btnLeft
            // 
            btnLeft.BackgroundImage = Properties.Resources.arrow_left;
            btnLeft.BackgroundImageLayout = ImageLayout.Stretch;
            btnLeft.FlatAppearance.BorderSize = 0;
            btnLeft.FlatStyle = FlatStyle.Flat;
            btnLeft.Location = new Point(604, 166);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new Size(25, 25);
            btnLeft.TabIndex = 12;
            btnLeft.UseVisualStyleBackColor = true;
            btnLeft.Click += btnLeft_Click;
            // 
            // btnDown
            // 
            btnDown.BackgroundImage = Properties.Resources.arrow_down;
            btnDown.BackgroundImageLayout = ImageLayout.Stretch;
            btnDown.FlatAppearance.BorderSize = 0;
            btnDown.FlatStyle = FlatStyle.Flat;
            btnDown.Location = new Point(629, 191);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(25, 25);
            btnDown.TabIndex = 13;
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // cmBx
            // 
            cmBx.DropDownStyle = ComboBoxStyle.DropDownList;
            cmBx.FormattingEnabled = true;
            cmBx.Items.AddRange(new object[] { "Круг", "Квадрат", "Треугольник" });
            cmBx.Location = new Point(231, 6);
            cmBx.Name = "cmBx";
            cmBx.Size = new Size(121, 23);
            cmBx.TabIndex = 14;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(604, 67);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(75, 23);
            btnColor.TabIndex = 15;
            btnColor.Text = "Цвет";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // btnUp
            // 
            btnUp.BackgroundImage = Properties.Resources.arrow_up;
            btnUp.BackgroundImageLayout = ImageLayout.Stretch;
            btnUp.FlatAppearance.BorderColor = SystemColors.GradientInactiveCaption;
            btnUp.FlatAppearance.BorderSize = 0;
            btnUp.FlatStyle = FlatStyle.Flat;
            btnUp.Location = new Point(629, 139);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(25, 25);
            btnUp.TabIndex = 16;
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnGroup
            // 
            btnGroup.Location = new Point(604, 38);
            btnGroup.Name = "btnGroup";
            btnGroup.Size = new Size(75, 23);
            btnGroup.TabIndex = 17;
            btnGroup.Text = "Группа";
            btnGroup.UseVisualStyleBackColor = true;
            btnGroup.Click += btnGroup_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackgroundImage = Properties.Resources.cancel;
            btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(68, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(25, 25);
            btnCancel.TabIndex = 18;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackgroundImage = Properties.Resources.save;
            btnSave.BackgroundImageLayout = ImageLayout.Stretch;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(37, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(25, 25);
            btnSave.TabIndex = 21;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackgroundImage = Properties.Resources.load;
            btnLoad.BackgroundImageLayout = ImageLayout.Stretch;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Location = new Point(6, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(25, 25);
            btnLoad.TabIndex = 22;
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // treeVw
            // 
            treeVw.Location = new Point(685, 6);
            treeVw.Name = "treeVw";
            treeVw.Size = new Size(169, 435);
            treeVw.TabIndex = 23;
            // 
            // btnTxt
            // 
            btnTxt.Location = new Point(604, 222);
            btnTxt.Name = "btnTxt";
            btnTxt.Size = new Size(75, 23);
            btnTxt.TabIndex = 24;
            btnTxt.Text = "Запись";
            btnTxt.UseVisualStyleBackColor = true;
            btnTxt.Click += btnTxt_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(862, 450);
            Controls.Add(btnTxt);
            Controls.Add(treeVw);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(btnGroup);
            Controls.Add(btnUp);
            Controls.Add(btnColor);
            Controls.Add(cmBx);
            Controls.Add(btnDown);
            Controls.Add(btnLeft);
            Controls.Add(btnRight);
            Controls.Add(btnIncrease);
            Controls.Add(btnDecrease);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(lblCount);
            Controls.Add(label1);
            Controls.Add(pctBx);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "MainForm";
            Text = "Фигуры";
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pctBx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pctBx;
        private Label label1;
        private Label lblCount;
        private Button btnDelete;
        private Button btnClear;
        private Button btnDecrease;
        private Button btnIncrease;
        private Button btnRight;
        private Button btnLeft;
        private Button btnDown;
        private ComboBox cmBx;
        private Button btnColor;
        private Button btnUp;
        private Button btnGroup;
        private ColorDialog colorDialog;
        private Button btnCancel;
        private Button btnSave;
        private Button btnLoad;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private TreeView treeVw;
        private Button btnTxt;
    }
}