﻿namespace SpacerUI
{
    partial class MainForm
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
            this.ч = new System.Windows.Forms.GroupBox();
            this.CloseKompasButton = new System.Windows.Forms.Button();
            this.StartKompasButton = new System.Windows.Forms.Button();
            this.GroupSpacer = new System.Windows.Forms.GroupBox();
            this.LabelWidth = new System.Windows.Forms.Label();
            this.FieldWidth = new System.Windows.Forms.NumericUpDown();
            this.FieldInnerDiametr = new System.Windows.Forms.NumericUpDown();
            this.LabelInnerDiametr = new System.Windows.Forms.Label();
            this.FieldOuterDiametr = new System.Windows.Forms.NumericUpDown();
            this.LabelOuterDiametr = new System.Windows.Forms.Label();
            this.FieldCountHoles = new System.Windows.Forms.NumericUpDown();
            this.LabelCountHoles = new System.Windows.Forms.Label();
            this.FieldDistance = new System.Windows.Forms.NumericUpDown();
            this.LabelDistance = new System.Windows.Forms.Label();
            this.ButtonDraw = new System.Windows.Forms.Button();
            this.ч.SuspendLayout();
            this.GroupSpacer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldInnerDiametr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldOuterDiametr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldCountHoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // ч
            // 
            this.ч.Controls.Add(this.CloseKompasButton);
            this.ч.Controls.Add(this.StartKompasButton);
            this.ч.Location = new System.Drawing.Point(12, 12);
            this.ч.Name = "ч";
            this.ч.Size = new System.Drawing.Size(314, 57);
            this.ч.TabIndex = 9;
            this.ч.TabStop = false;
            this.ч.Text = "Компас-3D";
            // 
            // CloseKompasButton
            // 
            this.CloseKompasButton.Enabled = false;
            this.CloseKompasButton.Location = new System.Drawing.Point(233, 19);
            this.CloseKompasButton.Name = "CloseKompasButton";
            this.CloseKompasButton.Size = new System.Drawing.Size(75, 23);
            this.CloseKompasButton.TabIndex = 1;
            this.CloseKompasButton.Text = "Закрыть";
            this.CloseKompasButton.UseVisualStyleBackColor = true;
            this.CloseKompasButton.Click += new System.EventHandler(this.CloseKompasButton_Click);
            // 
            // StartKompasButton
            // 
            this.StartKompasButton.Location = new System.Drawing.Point(6, 19);
            this.StartKompasButton.Name = "StartKompasButton";
            this.StartKompasButton.Size = new System.Drawing.Size(75, 23);
            this.StartKompasButton.TabIndex = 0;
            this.StartKompasButton.Text = "Запуск";
            this.StartKompasButton.UseVisualStyleBackColor = true;
            this.StartKompasButton.Click += new System.EventHandler(this.StartKompasButton_Click);
            // 
            // GroupSpacer
            // 
            this.GroupSpacer.Controls.Add(this.FieldCountHoles);
            this.GroupSpacer.Controls.Add(this.ButtonDraw);
            this.GroupSpacer.Controls.Add(this.FieldDistance);
            this.GroupSpacer.Controls.Add(this.LabelDistance);
            this.GroupSpacer.Controls.Add(this.LabelCountHoles);
            this.GroupSpacer.Controls.Add(this.FieldOuterDiametr);
            this.GroupSpacer.Controls.Add(this.LabelOuterDiametr);
            this.GroupSpacer.Controls.Add(this.FieldInnerDiametr);
            this.GroupSpacer.Controls.Add(this.LabelInnerDiametr);
            this.GroupSpacer.Controls.Add(this.FieldWidth);
            this.GroupSpacer.Controls.Add(this.LabelWidth);
            this.GroupSpacer.Location = new System.Drawing.Point(12, 75);
            this.GroupSpacer.Name = "GroupSpacer";
            this.GroupSpacer.Size = new System.Drawing.Size(314, 188);
            this.GroupSpacer.TabIndex = 10;
            this.GroupSpacer.TabStop = false;
            this.GroupSpacer.Text = "Проставка";
            // 
            // LabelWidth
            // 
            this.LabelWidth.AutoSize = true;
            this.LabelWidth.Location = new System.Drawing.Point(6, 31);
            this.LabelWidth.Name = "LabelWidth";
            this.LabelWidth.Size = new System.Drawing.Size(134, 13);
            this.LabelWidth.TabIndex = 0;
            this.LabelWidth.Text = "Толщина проставки(мм):";
            // 
            // FieldWidth
            // 
            this.FieldWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.FieldWidth.Location = new System.Drawing.Point(187, 29);
            this.FieldWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FieldWidth.Name = "FieldWidth";
            this.FieldWidth.Size = new System.Drawing.Size(121, 20);
            this.FieldWidth.TabIndex = 1;
            this.FieldWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FieldWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // FieldInnerDiametr
            // 
            this.FieldInnerDiametr.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.FieldInnerDiametr.Location = new System.Drawing.Point(187, 55);
            this.FieldInnerDiametr.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FieldInnerDiametr.Name = "FieldInnerDiametr";
            this.FieldInnerDiametr.Size = new System.Drawing.Size(121, 20);
            this.FieldInnerDiametr.TabIndex = 3;
            this.FieldInnerDiametr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FieldInnerDiametr.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FieldInnerDiametr.ValueChanged += new System.EventHandler(this.FieldInnerDiametr_ValueChanged);
            // 
            // LabelInnerDiametr
            // 
            this.LabelInnerDiametr.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.LabelInnerDiametr.AutoSize = true;
            this.LabelInnerDiametr.Location = new System.Drawing.Point(6, 57);
            this.LabelInnerDiametr.Name = "LabelInnerDiametr";
            this.LabelInnerDiametr.Size = new System.Drawing.Size(140, 13);
            this.LabelInnerDiametr.TabIndex = 2;
            this.LabelInnerDiametr.Text = "Внутренний диаметр (мм):";
            // 
            // FieldOuterDiametr
            // 
            this.FieldOuterDiametr.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.FieldOuterDiametr.Location = new System.Drawing.Point(187, 81);
            this.FieldOuterDiametr.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.FieldOuterDiametr.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.FieldOuterDiametr.Name = "FieldOuterDiametr";
            this.FieldOuterDiametr.Size = new System.Drawing.Size(121, 20);
            this.FieldOuterDiametr.TabIndex = 5;
            this.FieldOuterDiametr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FieldOuterDiametr.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // LabelOuterDiametr
            // 
            this.LabelOuterDiametr.AutoSize = true;
            this.LabelOuterDiametr.Location = new System.Drawing.Point(6, 83);
            this.LabelOuterDiametr.Name = "LabelOuterDiametr";
            this.LabelOuterDiametr.Size = new System.Drawing.Size(126, 13);
            this.LabelOuterDiametr.TabIndex = 4;
            this.LabelOuterDiametr.Text = "Внешний диаметр (мм):";
            // 
            // FieldCountHoles
            // 
            this.FieldCountHoles.Location = new System.Drawing.Point(187, 107);
            this.FieldCountHoles.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.FieldCountHoles.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.FieldCountHoles.Name = "FieldCountHoles";
            this.FieldCountHoles.Size = new System.Drawing.Size(121, 20);
            this.FieldCountHoles.TabIndex = 7;
            this.FieldCountHoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FieldCountHoles.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // LabelCountHoles
            // 
            this.LabelCountHoles.AutoSize = true;
            this.LabelCountHoles.Location = new System.Drawing.Point(6, 109);
            this.LabelCountHoles.Name = "LabelCountHoles";
            this.LabelCountHoles.Size = new System.Drawing.Size(124, 13);
            this.LabelCountHoles.TabIndex = 6;
            this.LabelCountHoles.Text = "Количество отверстий:";
            // 
            // FieldDistance
            // 
            this.FieldDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.FieldDistance.Location = new System.Drawing.Point(187, 133);
            this.FieldDistance.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.FieldDistance.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.FieldDistance.Name = "FieldDistance";
            this.FieldDistance.Size = new System.Drawing.Size(121, 20);
            this.FieldDistance.TabIndex = 9;
            this.FieldDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FieldDistance.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // LabelDistance
            // 
            this.LabelDistance.AutoSize = true;
            this.LabelDistance.Location = new System.Drawing.Point(6, 135);
            this.LabelDistance.Name = "LabelDistance";
            this.LabelDistance.Size = new System.Drawing.Size(175, 13);
            this.LabelDistance.TabIndex = 8;
            this.LabelDistance.Text = "Расстояние между отверстиями:";
            // 
            // ButtonDraw
            // 
            this.ButtonDraw.Location = new System.Drawing.Point(187, 159);
            this.ButtonDraw.Name = "ButtonDraw";
            this.ButtonDraw.Size = new System.Drawing.Size(121, 23);
            this.ButtonDraw.TabIndex = 10;
            this.ButtonDraw.Text = "Построить";
            this.ButtonDraw.UseVisualStyleBackColor = true;
            this.ButtonDraw.Click += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 275);
            this.Controls.Add(this.GroupSpacer);
            this.Controls.Add(this.ч);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Проставка";
            this.ч.ResumeLayout(false);
            this.GroupSpacer.ResumeLayout(false);
            this.GroupSpacer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldInnerDiametr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldOuterDiametr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldCountHoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldDistance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ч;
        private System.Windows.Forms.Button CloseKompasButton;
        private System.Windows.Forms.Button StartKompasButton;
        private System.Windows.Forms.GroupBox GroupSpacer;
        private System.Windows.Forms.Button ButtonDraw;
        private System.Windows.Forms.NumericUpDown FieldDistance;
        private System.Windows.Forms.Label LabelDistance;
        private System.Windows.Forms.NumericUpDown FieldCountHoles;
        private System.Windows.Forms.Label LabelCountHoles;
        private System.Windows.Forms.NumericUpDown FieldOuterDiametr;
        private System.Windows.Forms.Label LabelOuterDiametr;
        private System.Windows.Forms.NumericUpDown FieldInnerDiametr;
        private System.Windows.Forms.Label LabelInnerDiametr;
        private System.Windows.Forms.NumericUpDown FieldWidth;
        private System.Windows.Forms.Label LabelWidth;
    }
}
