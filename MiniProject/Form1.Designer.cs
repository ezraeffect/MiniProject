namespace MiniProject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_mclear = new System.Windows.Forms.Button();
            this.button_mRecall = new System.Windows.Forms.Button();
            this.button_mplus = new System.Windows.Forms.Button();
            this.button_mMinus = new System.Windows.Forms.Button();
            this.button_m = new System.Windows.Forms.Button();
            this.button_backspace = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_clearEntry = new System.Windows.Forms.Button();
            this.button_percent = new System.Windows.Forms.Button();
            this.button_div = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button_mul = new System.Windows.Forms.Button();
            this.button_writeNine = new System.Windows.Forms.Button();
            this.button_writeEight = new System.Windows.Forms.Button();
            this.button_writeSeven = new System.Windows.Forms.Button();
            this.button_sub = new System.Windows.Forms.Button();
            this.button_writeSix = new System.Windows.Forms.Button();
            this.button_writeFive = new System.Windows.Forms.Button();
            this.button_writeFour = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_writeThree = new System.Windows.Forms.Button();
            this.button_writeTwo = new System.Windows.Forms.Button();
            this.button_writeOne = new System.Windows.Forms.Button();
            this.button_equl = new System.Windows.Forms.Button();
            this.button_writeDot = new System.Windows.Forms.Button();
            this.button_writeZero = new System.Windows.Forms.Button();
            this.button_toggleSign = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.textBox_result = new System.Windows.Forms.Label();
            this.textBox_view = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_mclear
            // 
            this.button_mclear.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_mclear.Location = new System.Drawing.Point(12, 18);
            this.button_mclear.Name = "button_mclear";
            this.button_mclear.Size = new System.Drawing.Size(114, 75);
            this.button_mclear.TabIndex = 0;
            this.button_mclear.Text = "MC";
            this.button_mclear.UseVisualStyleBackColor = true;
            // 
            // button_mRecall
            // 
            this.button_mRecall.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_mRecall.Location = new System.Drawing.Point(130, 18);
            this.button_mRecall.Name = "button_mRecall";
            this.button_mRecall.Size = new System.Drawing.Size(114, 75);
            this.button_mRecall.TabIndex = 1;
            this.button_mRecall.Text = "MR";
            this.button_mRecall.UseVisualStyleBackColor = true;
            // 
            // button_mplus
            // 
            this.button_mplus.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_mplus.Location = new System.Drawing.Point(248, 18);
            this.button_mplus.Name = "button_mplus";
            this.button_mplus.Size = new System.Drawing.Size(114, 75);
            this.button_mplus.TabIndex = 2;
            this.button_mplus.Text = "M+";
            this.button_mplus.UseVisualStyleBackColor = true;
            // 
            // button_mMinus
            // 
            this.button_mMinus.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_mMinus.Location = new System.Drawing.Point(366, 18);
            this.button_mMinus.Name = "button_mMinus";
            this.button_mMinus.Size = new System.Drawing.Size(114, 75);
            this.button_mMinus.TabIndex = 3;
            this.button_mMinus.Text = "M-";
            this.button_mMinus.UseVisualStyleBackColor = true;
            // 
            // button_m
            // 
            this.button_m.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_m.Location = new System.Drawing.Point(484, 18);
            this.button_m.Name = "button_m";
            this.button_m.Size = new System.Drawing.Size(114, 75);
            this.button_m.TabIndex = 4;
            this.button_m.Text = "M";
            this.button_m.UseVisualStyleBackColor = true;
            // 
            // button_backspace
            // 
            this.button_backspace.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_backspace.Location = new System.Drawing.Point(455, 99);
            this.button_backspace.Name = "button_backspace";
            this.button_backspace.Size = new System.Drawing.Size(141, 75);
            this.button_backspace.TabIndex = 8;
            this.button_backspace.Text = "Backs";
            this.button_backspace.UseVisualStyleBackColor = true;
            this.button_backspace.Click += new System.EventHandler(this.button_backspace_Click);
            // 
            // button_clear
            // 
            this.button_clear.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_clear.Location = new System.Drawing.Point(306, 99);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(145, 75);
            this.button_clear.TabIndex = 9;
            this.button_clear.Text = "C";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_clearEntry
            // 
            this.button_clearEntry.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_clearEntry.Location = new System.Drawing.Point(162, 99);
            this.button_clearEntry.Name = "button_clearEntry";
            this.button_clearEntry.Size = new System.Drawing.Size(140, 75);
            this.button_clearEntry.TabIndex = 10;
            this.button_clearEntry.Text = "CE";
            this.button_clearEntry.UseVisualStyleBackColor = true;
            this.button_clearEntry.Click += new System.EventHandler(this.button_clearEntry_Click);
            // 
            // button_percent
            // 
            this.button_percent.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_percent.Location = new System.Drawing.Point(12, 99);
            this.button_percent.Name = "button_percent";
            this.button_percent.Size = new System.Drawing.Size(137, 75);
            this.button_percent.TabIndex = 11;
            this.button_percent.Text = "%";
            this.button_percent.UseVisualStyleBackColor = true;
            // 
            // button_div
            // 
            this.button_div.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_div.Location = new System.Drawing.Point(455, 180);
            this.button_div.Name = "button_div";
            this.button_div.Size = new System.Drawing.Size(141, 75);
            this.button_div.TabIndex = 12;
            this.button_div.Tag = "_divide";
            this.button_div.Text = "/";
            this.button_div.UseVisualStyleBackColor = true;
            this.button_div.Click += new System.EventHandler(this.button4kindOperatorPress_Event);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button12.Location = new System.Drawing.Point(306, 180);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(145, 75);
            this.button12.TabIndex = 13;
            this.button12.Text = "2sqrt";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button11.Location = new System.Drawing.Point(162, 180);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(140, 75);
            this.button11.TabIndex = 14;
            this.button11.Text = "x^2";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button10.Location = new System.Drawing.Point(12, 180);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(137, 75);
            this.button10.TabIndex = 15;
            this.button10.Text = "1/x";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button_mul
            // 
            this.button_mul.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_mul.Location = new System.Drawing.Point(455, 261);
            this.button_mul.Name = "button_mul";
            this.button_mul.Size = new System.Drawing.Size(141, 75);
            this.button_mul.TabIndex = 16;
            this.button_mul.Tag = "_multiple";
            this.button_mul.Text = "X";
            this.button_mul.UseVisualStyleBackColor = true;
            this.button_mul.Click += new System.EventHandler(this.button4kindOperatorPress_Event);
            // 
            // button_writeNine
            // 
            this.button_writeNine.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeNine.Location = new System.Drawing.Point(306, 261);
            this.button_writeNine.Name = "button_writeNine";
            this.button_writeNine.Size = new System.Drawing.Size(145, 75);
            this.button_writeNine.TabIndex = 17;
            this.button_writeNine.Text = "9";
            this.button_writeNine.UseVisualStyleBackColor = true;
            this.button_writeNine.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_writeEight
            // 
            this.button_writeEight.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeEight.Location = new System.Drawing.Point(162, 261);
            this.button_writeEight.Name = "button_writeEight";
            this.button_writeEight.Size = new System.Drawing.Size(140, 75);
            this.button_writeEight.TabIndex = 18;
            this.button_writeEight.Text = "8";
            this.button_writeEight.UseVisualStyleBackColor = true;
            this.button_writeEight.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_writeSeven
            // 
            this.button_writeSeven.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeSeven.Location = new System.Drawing.Point(12, 261);
            this.button_writeSeven.Name = "button_writeSeven";
            this.button_writeSeven.Size = new System.Drawing.Size(137, 75);
            this.button_writeSeven.TabIndex = 19;
            this.button_writeSeven.Text = "7";
            this.button_writeSeven.UseVisualStyleBackColor = true;
            this.button_writeSeven.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_sub
            // 
            this.button_sub.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_sub.Location = new System.Drawing.Point(455, 342);
            this.button_sub.Name = "button_sub";
            this.button_sub.Size = new System.Drawing.Size(141, 75);
            this.button_sub.TabIndex = 20;
            this.button_sub.Tag = "_minus";
            this.button_sub.Text = "-";
            this.button_sub.UseVisualStyleBackColor = true;
            this.button_sub.Click += new System.EventHandler(this.button4kindOperatorPress_Event);
            // 
            // button_writeSix
            // 
            this.button_writeSix.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeSix.Location = new System.Drawing.Point(306, 342);
            this.button_writeSix.Name = "button_writeSix";
            this.button_writeSix.Size = new System.Drawing.Size(145, 75);
            this.button_writeSix.TabIndex = 21;
            this.button_writeSix.Text = "6";
            this.button_writeSix.UseVisualStyleBackColor = true;
            this.button_writeSix.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_writeFive
            // 
            this.button_writeFive.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeFive.Location = new System.Drawing.Point(162, 342);
            this.button_writeFive.Name = "button_writeFive";
            this.button_writeFive.Size = new System.Drawing.Size(140, 75);
            this.button_writeFive.TabIndex = 22;
            this.button_writeFive.Text = "5";
            this.button_writeFive.UseVisualStyleBackColor = true;
            this.button_writeFive.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_writeFour
            // 
            this.button_writeFour.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeFour.Location = new System.Drawing.Point(12, 342);
            this.button_writeFour.Name = "button_writeFour";
            this.button_writeFour.Size = new System.Drawing.Size(137, 75);
            this.button_writeFour.TabIndex = 23;
            this.button_writeFour.Text = "4";
            this.button_writeFour.UseVisualStyleBackColor = true;
            this.button_writeFour.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_add
            // 
            this.button_add.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_add.Location = new System.Drawing.Point(455, 423);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(141, 75);
            this.button_add.TabIndex = 24;
            this.button_add.Tag = "_plus";
            this.button_add.Text = "+";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button4kindOperatorPress_Event);
            // 
            // button_writeThree
            // 
            this.button_writeThree.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeThree.Location = new System.Drawing.Point(306, 423);
            this.button_writeThree.Name = "button_writeThree";
            this.button_writeThree.Size = new System.Drawing.Size(145, 75);
            this.button_writeThree.TabIndex = 25;
            this.button_writeThree.Text = "3";
            this.button_writeThree.UseVisualStyleBackColor = true;
            this.button_writeThree.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_writeTwo
            // 
            this.button_writeTwo.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeTwo.Location = new System.Drawing.Point(162, 423);
            this.button_writeTwo.Name = "button_writeTwo";
            this.button_writeTwo.Size = new System.Drawing.Size(140, 75);
            this.button_writeTwo.TabIndex = 26;
            this.button_writeTwo.Text = "2";
            this.button_writeTwo.UseVisualStyleBackColor = true;
            this.button_writeTwo.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_writeOne
            // 
            this.button_writeOne.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeOne.Location = new System.Drawing.Point(12, 423);
            this.button_writeOne.Name = "button_writeOne";
            this.button_writeOne.Size = new System.Drawing.Size(137, 75);
            this.button_writeOne.TabIndex = 27;
            this.button_writeOne.Text = "1";
            this.button_writeOne.UseVisualStyleBackColor = true;
            this.button_writeOne.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_equl
            // 
            this.button_equl.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_equl.Location = new System.Drawing.Point(455, 504);
            this.button_equl.Name = "button_equl";
            this.button_equl.Size = new System.Drawing.Size(141, 75);
            this.button_equl.TabIndex = 28;
            this.button_equl.Text = "=";
            this.button_equl.UseVisualStyleBackColor = true;
            this.button_equl.Click += new System.EventHandler(this.button_equl_Click);
            // 
            // button_writeDot
            // 
            this.button_writeDot.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeDot.Location = new System.Drawing.Point(306, 504);
            this.button_writeDot.Name = "button_writeDot";
            this.button_writeDot.Size = new System.Drawing.Size(145, 75);
            this.button_writeDot.TabIndex = 29;
            this.button_writeDot.Text = ".";
            this.button_writeDot.UseVisualStyleBackColor = true;
            this.button_writeDot.Click += new System.EventHandler(this.button_writeDot_Click);
            // 
            // button_writeZero
            // 
            this.button_writeZero.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_writeZero.Location = new System.Drawing.Point(162, 504);
            this.button_writeZero.Name = "button_writeZero";
            this.button_writeZero.Size = new System.Drawing.Size(140, 75);
            this.button_writeZero.TabIndex = 30;
            this.button_writeZero.Text = "0";
            this.button_writeZero.UseVisualStyleBackColor = true;
            this.button_writeZero.Click += new System.EventHandler(this.NumberKeyPress_0to9_Event);
            // 
            // button_toggleSign
            // 
            this.button_toggleSign.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_toggleSign.Location = new System.Drawing.Point(12, 504);
            this.button_toggleSign.Name = "button_toggleSign";
            this.button_toggleSign.Size = new System.Drawing.Size(137, 75);
            this.button_toggleSign.TabIndex = 31;
            this.button_toggleSign.Text = "+/-";
            this.button_toggleSign.UseVisualStyleBackColor = true;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.button_toggleSign);
            this.pnlBody.Controls.Add(this.button_writeZero);
            this.pnlBody.Controls.Add(this.button_writeDot);
            this.pnlBody.Controls.Add(this.button_equl);
            this.pnlBody.Controls.Add(this.button_writeOne);
            this.pnlBody.Controls.Add(this.button_writeTwo);
            this.pnlBody.Controls.Add(this.button_writeThree);
            this.pnlBody.Controls.Add(this.button_add);
            this.pnlBody.Controls.Add(this.button_writeFour);
            this.pnlBody.Controls.Add(this.button_writeFive);
            this.pnlBody.Controls.Add(this.button_writeSix);
            this.pnlBody.Controls.Add(this.button_sub);
            this.pnlBody.Controls.Add(this.button_writeSeven);
            this.pnlBody.Controls.Add(this.button_writeEight);
            this.pnlBody.Controls.Add(this.button_writeNine);
            this.pnlBody.Controls.Add(this.button_mul);
            this.pnlBody.Controls.Add(this.button10);
            this.pnlBody.Controls.Add(this.button11);
            this.pnlBody.Controls.Add(this.button12);
            this.pnlBody.Controls.Add(this.button_div);
            this.pnlBody.Controls.Add(this.button_percent);
            this.pnlBody.Controls.Add(this.button_clearEntry);
            this.pnlBody.Controls.Add(this.button_clear);
            this.pnlBody.Controls.Add(this.button_backspace);
            this.pnlBody.Controls.Add(this.button_m);
            this.pnlBody.Controls.Add(this.button_mMinus);
            this.pnlBody.Controls.Add(this.button_mplus);
            this.pnlBody.Controls.Add(this.button_mRecall);
            this.pnlBody.Controls.Add(this.button_mclear);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 150);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(610, 592);
            this.pnlBody.TabIndex = 32;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.textBox_result);
            this.pnlTop.Controls.Add(this.textBox_view);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(610, 150);
            this.pnlTop.TabIndex = 31;
            // 
            // textBox_result
            // 
            this.textBox_result.Font = new System.Drawing.Font("굴림", 35F);
            this.textBox_result.Location = new System.Drawing.Point(5, 61);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(602, 89);
            this.textBox_result.TabIndex = 1;
            this.textBox_result.Text = "123,456,789";
            this.textBox_result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_view
            // 
            this.textBox_view.Font = new System.Drawing.Font("굴림", 11F);
            this.textBox_view.Location = new System.Drawing.Point(0, 0);
            this.textBox_view.Name = "textBox_view";
            this.textBox_view.Size = new System.Drawing.Size(607, 52);
            this.textBox_view.TabIndex = 0;
            this.textBox_view.Text = "123,456+789=";
            this.textBox_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 742);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlBody.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_mclear;
        private System.Windows.Forms.Button button_mRecall;
        private System.Windows.Forms.Button button_mplus;
        private System.Windows.Forms.Button button_mMinus;
        private System.Windows.Forms.Button button_m;
        private System.Windows.Forms.Button button_backspace;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_clearEntry;
        private System.Windows.Forms.Button button_percent;
        private System.Windows.Forms.Button button_div;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button_mul;
        private System.Windows.Forms.Button button_writeNine;
        private System.Windows.Forms.Button button_writeEight;
        private System.Windows.Forms.Button button_writeSeven;
        private System.Windows.Forms.Button button_sub;
        private System.Windows.Forms.Button button_writeSix;
        private System.Windows.Forms.Button button_writeFive;
        private System.Windows.Forms.Button button_writeFour;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_writeThree;
        private System.Windows.Forms.Button button_writeTwo;
        private System.Windows.Forms.Button button_writeOne;
        private System.Windows.Forms.Button button_equl;
        private System.Windows.Forms.Button button_writeDot;
        private System.Windows.Forms.Button button_writeZero;
        private System.Windows.Forms.Button button_toggleSign;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label textBox_result;
        private System.Windows.Forms.Label textBox_view;
    }
}

