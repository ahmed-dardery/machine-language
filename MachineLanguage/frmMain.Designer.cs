namespace MachineLanguage
{
	partial class frmMain
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
			this.lstMyMemory = new System.Windows.Forms.ListView();
			this.clmnH11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmnH12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmnH13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmnH14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmnH15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lstMyRegisters = new System.Windows.Forms.ListView();
			this.clmnH21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmnH22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmnH23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmnH24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmnH25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.grbRegister = new System.Windows.Forms.GroupBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.btnClearRegister = new System.Windows.Forms.Button();
			this.lblCode = new System.Windows.Forms.Label();
			this.txtOperand3 = new System.Windows.Forms.TextBox();
			this.btnExecute = new System.Windows.Forms.Button();
			this.lblO3 = new System.Windows.Forms.Label();
			this.txtOperand2 = new System.Windows.Forms.TextBox();
			this.lblO2 = new System.Windows.Forms.Label();
			this.txtOperand1 = new System.Windows.Forms.TextBox();
			this.lblO1 = new System.Windows.Forms.Label();
			this.txtOpcode = new System.Windows.Forms.TextBox();
			this.btnFetch = new System.Windows.Forms.Button();
			this.btnDecode = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtIR = new System.Windows.Forms.TextBox();
			this.txtPC = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.grbMainMemory = new System.Windows.Forms.GroupBox();
			this.btnClearMemory = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnRunOne = new System.Windows.Forms.Button();
			this.grbControl = new System.Windows.Forms.GroupBox();
			this.btnRunLoop = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.chkSimple = new System.Windows.Forms.CheckBox();
			this.grbRegister.SuspendLayout();
			this.grbMainMemory.SuspendLayout();
			this.grbControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstMyMemory
			// 
			this.lstMyMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstMyMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnH11,
            this.clmnH12,
            this.clmnH13,
            this.clmnH14,
            this.clmnH15});
			this.lstMyMemory.FullRowSelect = true;
			this.lstMyMemory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstMyMemory.Location = new System.Drawing.Point(6, 19);
			this.lstMyMemory.Name = "lstMyMemory";
			this.lstMyMemory.Size = new System.Drawing.Size(348, 395);
			this.lstMyMemory.TabIndex = 0;
			this.lstMyMemory.UseCompatibleStateImageBehavior = false;
			this.lstMyMemory.View = System.Windows.Forms.View.Details;
			this.lstMyMemory.DoubleClick += new System.EventHandler(this.lstData_DoubleClick);
			this.lstMyMemory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lst_KeyUp);
			// 
			// clmnH11
			// 
			this.clmnH11.Text = "Address";
			// 
			// clmnH12
			// 
			this.clmnH12.Text = "Binary";
			this.clmnH12.Width = 80;
			// 
			// clmnH13
			// 
			this.clmnH13.Text = "Hex";
			this.clmnH13.Width = 40;
			// 
			// clmnH14
			// 
			this.clmnH14.Text = "Int";
			this.clmnH14.Width = 40;
			// 
			// clmnH15
			// 
			this.clmnH15.Text = "Floating";
			this.clmnH15.Width = 95;
			// 
			// lstMyRegisters
			// 
			this.lstMyRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstMyRegisters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnH21,
            this.clmnH22,
            this.clmnH23,
            this.clmnH24,
            this.clmnH25});
			this.lstMyRegisters.FullRowSelect = true;
			this.lstMyRegisters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstMyRegisters.Location = new System.Drawing.Point(6, 19);
			this.lstMyRegisters.Name = "lstMyRegisters";
			this.lstMyRegisters.Size = new System.Drawing.Size(338, 303);
			this.lstMyRegisters.TabIndex = 0;
			this.lstMyRegisters.UseCompatibleStateImageBehavior = false;
			this.lstMyRegisters.View = System.Windows.Forms.View.Details;
			this.lstMyRegisters.DoubleClick += new System.EventHandler(this.lstData_DoubleClick);
			this.lstMyRegisters.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lst_KeyUp);
			// 
			// clmnH21
			// 
			this.clmnH21.Text = "Register";
			// 
			// clmnH22
			// 
			this.clmnH22.Text = "Binary";
			this.clmnH22.Width = 80;
			// 
			// clmnH23
			// 
			this.clmnH23.Text = "Hex";
			this.clmnH23.Width = 40;
			// 
			// clmnH24
			// 
			this.clmnH24.Text = "Int";
			this.clmnH24.Width = 40;
			// 
			// clmnH25
			// 
			this.clmnH25.Text = "Floating";
			this.clmnH25.Width = 95;
			// 
			// grbRegister
			// 
			this.grbRegister.Controls.Add(this.txtDescription);
			this.grbRegister.Controls.Add(this.btnClearRegister);
			this.grbRegister.Controls.Add(this.lblCode);
			this.grbRegister.Controls.Add(this.txtOperand3);
			this.grbRegister.Controls.Add(this.btnExecute);
			this.grbRegister.Controls.Add(this.lblO3);
			this.grbRegister.Controls.Add(this.txtOperand2);
			this.grbRegister.Controls.Add(this.lblO2);
			this.grbRegister.Controls.Add(this.txtOperand1);
			this.grbRegister.Controls.Add(this.lblO1);
			this.grbRegister.Controls.Add(this.txtOpcode);
			this.grbRegister.Controls.Add(this.btnFetch);
			this.grbRegister.Controls.Add(this.btnDecode);
			this.grbRegister.Controls.Add(this.label4);
			this.grbRegister.Controls.Add(this.txtIR);
			this.grbRegister.Controls.Add(this.txtPC);
			this.grbRegister.Controls.Add(this.label2);
			this.grbRegister.Controls.Add(this.label1);
			this.grbRegister.Controls.Add(this.lstMyRegisters);
			this.grbRegister.Location = new System.Drawing.Point(376, 12);
			this.grbRegister.Name = "grbRegister";
			this.grbRegister.Size = new System.Drawing.Size(544, 357);
			this.grbRegister.TabIndex = 1;
			this.grbRegister.TabStop = false;
			this.grbRegister.Text = "Central Processing Unit";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(351, 242);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.Size = new System.Drawing.Size(184, 67);
			this.txtDescription.TabIndex = 18;
			// 
			// btnClearRegister
			// 
			this.btnClearRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearRegister.Location = new System.Drawing.Point(6, 328);
			this.btnClearRegister.Name = "btnClearRegister";
			this.btnClearRegister.Size = new System.Drawing.Size(338, 23);
			this.btnClearRegister.TabIndex = 17;
			this.btnClearRegister.Text = "Clear Register";
			this.btnClearRegister.UseVisualStyleBackColor = true;
			this.btnClearRegister.Click += new System.EventHandler(this.btnClearRegister_Click);
			// 
			// lblCode
			// 
			this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCode.AutoSize = true;
			this.lblCode.Location = new System.Drawing.Point(360, 193);
			this.lblCode.Name = "lblCode";
			this.lblCode.Size = new System.Drawing.Size(27, 13);
			this.lblCode.TabIndex = 9;
			this.lblCode.Text = "????";
			// 
			// txtOperand3
			// 
			this.txtOperand3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOperand3.Location = new System.Drawing.Point(474, 219);
			this.txtOperand3.MaxLength = 1;
			this.txtOperand3.Name = "txtOperand3";
			this.txtOperand3.ReadOnly = true;
			this.txtOperand3.Size = new System.Drawing.Size(26, 20);
			this.txtOperand3.TabIndex = 15;
			// 
			// btnExecute
			// 
			this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExecute.Enabled = false;
			this.btnExecute.Location = new System.Drawing.Point(350, 315);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(184, 23);
			this.btnExecute.TabIndex = 16;
			this.btnExecute.Text = "Execute";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// lblO3
			// 
			this.lblO3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblO3.AutoSize = true;
			this.lblO3.Location = new System.Drawing.Point(449, 222);
			this.lblO3.Name = "lblO3";
			this.lblO3.Size = new System.Drawing.Size(19, 13);
			this.lblO3.TabIndex = 14;
			this.lblO3.Text = "? :";
			// 
			// txtOperand2
			// 
			this.txtOperand2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOperand2.Location = new System.Drawing.Point(474, 193);
			this.txtOperand2.MaxLength = 1;
			this.txtOperand2.Name = "txtOperand2";
			this.txtOperand2.ReadOnly = true;
			this.txtOperand2.Size = new System.Drawing.Size(26, 20);
			this.txtOperand2.TabIndex = 13;
			// 
			// lblO2
			// 
			this.lblO2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblO2.AutoSize = true;
			this.lblO2.Location = new System.Drawing.Point(449, 196);
			this.lblO2.Name = "lblO2";
			this.lblO2.Size = new System.Drawing.Size(19, 13);
			this.lblO2.TabIndex = 12;
			this.lblO2.Text = "? :";
			// 
			// txtOperand1
			// 
			this.txtOperand1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOperand1.Location = new System.Drawing.Point(474, 167);
			this.txtOperand1.MaxLength = 1;
			this.txtOperand1.Name = "txtOperand1";
			this.txtOperand1.ReadOnly = true;
			this.txtOperand1.Size = new System.Drawing.Size(26, 20);
			this.txtOperand1.TabIndex = 11;
			// 
			// lblO1
			// 
			this.lblO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblO1.AutoSize = true;
			this.lblO1.Location = new System.Drawing.Point(449, 170);
			this.lblO1.Name = "lblO1";
			this.lblO1.Size = new System.Drawing.Size(19, 13);
			this.lblO1.TabIndex = 10;
			this.lblO1.Text = "? :";
			// 
			// txtOpcode
			// 
			this.txtOpcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOpcode.Location = new System.Drawing.Point(407, 167);
			this.txtOpcode.MaxLength = 1;
			this.txtOpcode.Name = "txtOpcode";
			this.txtOpcode.ReadOnly = true;
			this.txtOpcode.Size = new System.Drawing.Size(26, 20);
			this.txtOpcode.TabIndex = 8;
			this.txtOpcode.TextChanged += new System.EventHandler(this.txtOpcode_TextChanged);
			// 
			// btnFetch
			// 
			this.btnFetch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFetch.Location = new System.Drawing.Point(351, 64);
			this.btnFetch.Name = "btnFetch";
			this.btnFetch.Size = new System.Drawing.Size(184, 23);
			this.btnFetch.TabIndex = 3;
			this.btnFetch.Text = "Fetch";
			this.btnFetch.UseVisualStyleBackColor = true;
			this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
			// 
			// btnDecode
			// 
			this.btnDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDecode.Enabled = false;
			this.btnDecode.Location = new System.Drawing.Point(351, 135);
			this.btnDecode.Name = "btnDecode";
			this.btnDecode.Size = new System.Drawing.Size(184, 23);
			this.btnDecode.TabIndex = 6;
			this.btnDecode.Text = "Decode";
			this.btnDecode.UseVisualStyleBackColor = true;
			this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(351, 170);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Opcode:";
			// 
			// txtIR
			// 
			this.txtIR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIR.Location = new System.Drawing.Point(400, 109);
			this.txtIR.MaxLength = 4;
			this.txtIR.Name = "txtIR";
			this.txtIR.Size = new System.Drawing.Size(100, 20);
			this.txtIR.TabIndex = 5;
			this.txtIR.TextChanged += new System.EventHandler(this.txtIR_TextChanged);
			// 
			// txtPC
			// 
			this.txtPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPC.Location = new System.Drawing.Point(400, 38);
			this.txtPC.MaxLength = 2;
			this.txtPC.Name = "txtPC";
			this.txtPC.Size = new System.Drawing.Size(100, 20);
			this.txtPC.TabIndex = 2;
			this.txtPC.Text = "00";
			this.txtPC.TextChanged += new System.EventHandler(this.txtPC_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(351, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Instruction Register:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(351, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Program Counter:";
			// 
			// grbMainMemory
			// 
			this.grbMainMemory.Controls.Add(this.btnClearMemory);
			this.grbMainMemory.Controls.Add(this.button1);
			this.grbMainMemory.Controls.Add(this.lstMyMemory);
			this.grbMainMemory.Location = new System.Drawing.Point(12, 12);
			this.grbMainMemory.Name = "grbMainMemory";
			this.grbMainMemory.Size = new System.Drawing.Size(360, 453);
			this.grbMainMemory.TabIndex = 0;
			this.grbMainMemory.TabStop = false;
			this.grbMainMemory.Text = "Main Memory";
			// 
			// btnClearMemory
			// 
			this.btnClearMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearMemory.Location = new System.Drawing.Point(268, 420);
			this.btnClearMemory.Name = "btnClearMemory";
			this.btnClearMemory.Size = new System.Drawing.Size(86, 23);
			this.btnClearMemory.TabIndex = 2;
			this.btnClearMemory.Text = "Clear Memory";
			this.btnClearMemory.UseVisualStyleBackColor = true;
			this.btnClearMemory.Click += new System.EventHandler(this.btnClearMemory_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(6, 420);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(256, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Batch Add Code";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnBatchEdit_Click);
			// 
			// btnRunOne
			// 
			this.btnRunOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRunOne.Location = new System.Drawing.Point(9, 19);
			this.btnRunOne.Name = "btnRunOne";
			this.btnRunOne.Size = new System.Drawing.Size(526, 23);
			this.btnRunOne.TabIndex = 0;
			this.btnRunOne.Text = "Run one cycle ( Fetch - Decode - Execute )";
			this.btnRunOne.UseVisualStyleBackColor = true;
			this.btnRunOne.Click += new System.EventHandler(this.btnRunOne_Click);
			// 
			// grbControl
			// 
			this.grbControl.Controls.Add(this.btnRunLoop);
			this.grbControl.Controls.Add(this.btnRunOne);
			this.grbControl.Location = new System.Drawing.Point(376, 375);
			this.grbControl.Name = "grbControl";
			this.grbControl.Size = new System.Drawing.Size(544, 108);
			this.grbControl.TabIndex = 2;
			this.grbControl.TabStop = false;
			this.grbControl.Text = "Control";
			// 
			// btnRunLoop
			// 
			this.btnRunLoop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRunLoop.Location = new System.Drawing.Point(9, 48);
			this.btnRunLoop.Name = "btnRunLoop";
			this.btnRunLoop.Size = new System.Drawing.Size(526, 50);
			this.btnRunLoop.TabIndex = 1;
			this.btnRunLoop.Text = "Run untill halt";
			this.btnRunLoop.UseVisualStyleBackColor = true;
			this.btnRunLoop.Click += new System.EventHandler(this.btnRunLoop_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 473);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "By Ahmed Dardery";
			// 
			// chkSimple
			// 
			this.chkSimple.AutoSize = true;
			this.chkSimple.Location = new System.Drawing.Point(291, 472);
			this.chkSimple.Name = "chkSimple";
			this.chkSimple.Size = new System.Drawing.Size(81, 17);
			this.chkSimple.TabIndex = 4;
			this.chkSimple.Text = "Simple View";
			this.chkSimple.UseVisualStyleBackColor = true;
			this.chkSimple.CheckedChanged += new System.EventHandler(this.chkSimple_CheckedChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(928, 498);
			this.Controls.Add(this.chkSimple);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.grbControl);
			this.Controls.Add(this.grbMainMemory);
			this.Controls.Add(this.grbRegister);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Machine Language Interpreter";
			this.grbRegister.ResumeLayout(false);
			this.grbRegister.PerformLayout();
			this.grbMainMemory.ResumeLayout(false);
			this.grbControl.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lstMyMemory;
		private System.Windows.Forms.ColumnHeader clmnH11;
		private System.Windows.Forms.ColumnHeader clmnH12;
		private System.Windows.Forms.ColumnHeader clmnH13;
		private System.Windows.Forms.ColumnHeader clmnH14;
		private System.Windows.Forms.ColumnHeader clmnH15;
		private System.Windows.Forms.ListView lstMyRegisters;
		private System.Windows.Forms.ColumnHeader clmnH21;
		private System.Windows.Forms.ColumnHeader clmnH22;
		private System.Windows.Forms.ColumnHeader clmnH23;
		private System.Windows.Forms.ColumnHeader clmnH24;
		private System.Windows.Forms.ColumnHeader clmnH25;
		private System.Windows.Forms.GroupBox grbRegister;
		private System.Windows.Forms.TextBox txtIR;
		private System.Windows.Forms.TextBox txtPC;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grbMainMemory;
		private System.Windows.Forms.Button btnRunOne;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.Button btnFetch;
		private System.Windows.Forms.Button btnDecode;
		private System.Windows.Forms.GroupBox grbControl;
		private System.Windows.Forms.Button btnRunLoop;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lblCode;
		private System.Windows.Forms.TextBox txtOperand3;
		private System.Windows.Forms.Label lblO3;
		private System.Windows.Forms.TextBox txtOperand2;
		private System.Windows.Forms.Label lblO2;
		private System.Windows.Forms.TextBox txtOperand1;
		private System.Windows.Forms.Label lblO1;
		private System.Windows.Forms.TextBox txtOpcode;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnClearMemory;
		private System.Windows.Forms.Button btnClearRegister;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.CheckBox chkSimple;
	}
}

