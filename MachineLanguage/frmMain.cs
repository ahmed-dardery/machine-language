using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;



namespace MachineLanguage
{
	public partial class frmMain : Form
	{
		TextBox txtFastEdit;
		ListViewItem[] lstMemory;
		ListViewItem[] lstRegister;

		byte[] valMemory = new byte[256];
		byte[] valRegister = new byte[16];

		bool Halt = false;
		bool Limit = false;
		public bool Modified = false;

		byte _PC = 0x00;
		public byte PC
		{
			get { return _PC; }
			set { _PC = value; txtPC.Text = Extra.ToHex(_PC, 4); }
		}
		byte[] IR = { 0x00, 0x00 };


		public frmMain()
		{
			this.Icon = MachineLanguage.Properties.Resources.icon_programming;
			InitializeComponent();

			chkSimple.Checked = true;

			txtFastEdit = new TextBox();
			editing = false;
			this.Controls.Add(txtFastEdit);
			txtFastEdit.BringToFront();
			txtFastEdit.KeyDown += new KeyEventHandler(this.txtFastEdit_KeyDown);
			txtFastEdit.Leave += new EventHandler(this.txtFastEdit_Leave);


			//Fills both the Memory and the Register with initial values of 0x00
			lstMemory = new ListViewItem[256];
			lstRegister = new ListViewItem[16];
			for (int i = 0; i < 256; i++)
			{
				lstMemory[i] = new ListViewItem(new string[] { Extra.ToHex(i, 2), "00000000", "00", "0", "0" });

				if (i < 16) lstRegister[i] = new ListViewItem(new string[] { Extra.ToHex(i, 1), "00000000", "00", "0", "0" });
			}

			lstMyMemory.Items.AddRange(lstMemory);
			lstMyRegisters.Items.AddRange(lstRegister);


		}

		#region Memory/Register Wrapper

		//Instead of only editing the numerical value. This also edits its representation in the ListView.
		public void EditMemory(byte address, byte x)
		{
			lstMemory[address].SubItems[1].Text = Extra.ToBin(x, 8);
			lstMemory[address].SubItems[2].Text = Extra.ToHex(x, 2);
			lstMemory[address].SubItems[3].Text = ((sbyte)x).ToString();
			lstMemory[address].SubItems[4].Text = FloatingNotation.BitsToFloat(x).ToString();

			valMemory[address] = x;

			if (address == 0x00)
			{
				if (x != 0x00)
				{ txtScreen.AppendText(((char)x).ToString()); }
				else
				{ txtScreen.Clear(); }
			}
		}
		//Instead of only editing the numerical value. This also edits its representation in the ListView.
		public void EditRegister(byte id, byte x)
		{
			lstRegister[id].SubItems[1].Text = Extra.ToBin(x, 8);
			lstRegister[id].SubItems[2].Text = Extra.ToHex(x, 2);
			lstRegister[id].SubItems[3].Text = ((sbyte)x).ToString();
			lstRegister[id].SubItems[4].Text = FloatingNotation.BitsToFloat(x).ToString();
			valRegister[id] = x;
		}

		public void FillMemory(byte[] code, byte address = 0)
		{
			foreach (byte x in code)
			{
				EditMemory(address, x);
				address++;
			}
		}

		public void FillRegister(byte[] code, byte address = 0)
		{
			foreach (byte x in code)
			{
				EditRegister(address, x);
				address++;
			}
		}

		void SetOpDescription(string L0, string L1, string L2, string L3, string description)
		{
			txtOpcode.Text = L0;
			lblCode.Text = string.Concat(L0, L1, L2, L3);
			lblO1.Text = L1;
			lblO2.Text = L2;
			lblO3.Text = L3;

			
			txtDescription.Text = string.Format(description, Extra.ToHex(IR[0] & 0xF,1), Extra.ToHex(IR[1] >> 4,1), Extra.ToHex(IR[1] & 0xF,1));
		}

		#endregion

		#region Fetch Decode Execute

		/// <summary>
		/// Retrieve the next instruction from memory (as indicated by the program counter) and then increment the program counter.
		/// </summary>
		void Fetch()
		{
			PC = Extra.FromHex(txtPC.Text);

			IR[0] = valMemory[PC];
			if (PC + 1 > 255)
			{
				IR[1] = 0;
				PC -= 1;
			}
			else
			{
				IR[1] = valMemory[PC + 1];
			}

			if (PC >= 0xFE) Limit = true;

			PC = (byte)(PC + 2);

			txtIR.Text = Extra.ToHex(IR[0], 2) + Extra.ToHex(IR[1], 2);
			txtPC.Text = Extra.ToHex(PC, 2);
		}

		/// <summary>
		/// Decode the bit pattern in the instruction register. 
		/// </summary>
		void Decode()
		{
			short newIR = short.Parse(txtIR.Text, System.Globalization.NumberStyles.HexNumber);
			IR[0] = (byte)(newIR >> 8);
			IR[1] = (byte)(newIR % 256);

			byte opcode = (byte)(IR[0] >> 4);
			switch (opcode)
			{
				case 0:
					SetOpDescription("0", "?", "?", "?", Extra.mydescriptions[opcode]);
					break;
				case 1:
				case 2:
				case 3:
					SetOpDescription(opcode.ToString(), "R", "X", "Y", Extra.mydescriptions[opcode]);
					break;
				case 4:
					SetOpDescription("4", "?", "R", "S", Extra.mydescriptions[opcode]);
					break;
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
					SetOpDescription(opcode.ToString(), "R", "S", "T", Extra.mydescriptions[opcode]);
					break;
				case 10:
					SetOpDescription("A", "R", "?", "X", Extra.mydescriptions[opcode]);
					break;
				case 11:
					SetOpDescription("B", "R", "X", "Y", Extra.mydescriptions[opcode]);
					break;
				case 12:
					SetOpDescription("C", "?", "?", "?", Extra.mydescriptions[opcode]);
					break;
				default:
					SetOpDescription("?", "?", "?", "?", Extra.mydescriptions[opcode]);
					break;
			}
			txtOpcode.Text = Extra.ToHex(IR[0] >> 4, 1);
			txtOperand1.Text = Extra.ToHex(IR[0] & 0xF, 1);
			txtOperand2.Text = Extra.ToHex(IR[1] >> 4, 1);
			txtOperand3.Text = Extra.ToHex(IR[1] & 0xF, 1);
		}

		/// <summary>
		/// Perform the action required by the instruction in the instruction register.
		/// </summary>
		void Execute()
		{
			Halt = false;
			byte opcode = (byte)(IR[0] >> 4);

			if (opcode == 0)
			{

			}
			else if (opcode == 1)
			{
				byte R = (byte)(IR[0] & 0xF);
				byte XY = IR[1];

				EditRegister(R, valMemory[XY]);
			}
			else if (opcode == 2)
			{
				byte R = (byte)(IR[0] & 0xF);
				byte XY = IR[1];

				EditRegister(R, XY);
			}
			else if (opcode == 3)
			{
				byte R = (byte)(IR[0] & 0xF);
				byte XY = IR[1];

				EditMemory(XY, valRegister[R]);
			}
			else if (opcode == 4)
			{
				byte R = (byte)(IR[1] >> 4);
				byte S = (byte)(IR[1] & 0xF);

				EditRegister(S, valRegister[R]);
			}
			else if (opcode == 5)
			{
				byte R = (byte)(IR[0] & 0xF);
				byte S = (byte)(IR[1] >> 4);
				byte T = (byte)(IR[1] & 0xF);

				EditRegister(R, (byte)(valRegister[S] + valRegister[T]));
			}
			else if (opcode == 6)
			{
				byte R = (byte)(IR[0] & 0xF);
				byte S = (byte)(IR[1] >> 4);
				byte T = (byte)(IR[1] & 0xF);

				EditRegister(R, (byte)((new FloatingNotation(valRegister[S]) + new FloatingNotation(valRegister[T]))).ToBits());
			}
			else if (opcode == 7)
			{
				byte R = (byte)(IR[0] & 0xF);
				byte S = (byte)(IR[1] >> 4);
				byte T = (byte)(IR[1] & 0xF);

				EditRegister(R, (byte)(valRegister[S] | valRegister[T]));
			}
			else if (opcode == 8)
			{
				byte R = (byte)(IR[0] & 0xF);
				byte S = (byte)(IR[1] >> 4);
				byte T = (byte)(IR[1] & 0xF);

				EditRegister(R, (byte)(valRegister[S] & valRegister[T]));
			}
			else if (opcode == 9)
			{
				byte R = (byte)(IR[0] & 0xF);
				byte S = (byte)(IR[1] >> 4);
				byte T = (byte)(IR[1] & 0xF);

				EditRegister(R, (byte)(valRegister[S] ^ valRegister[T]));
			}
			else if (opcode == 10)
			{ //A
				byte R = (byte)(IR[0] & 0xF);
				byte X = (byte)(IR[1] & 0xF);
				byte res = valRegister[R];
				for (byte i = 0; i < X; i++)
				{
					res = (byte)((res >> 1) + ((res & 1) << 7));
				}
				EditRegister(R, res);
			}
			else if (opcode == 11)
			{ //B
				byte R = (byte)(IR[0] & 0xF);
				if (valRegister[R] == valRegister[0]) PC = IR[1];
			}
			else if (opcode == 12)
			{ //C
				Halt = true;
			}
			else if (opcode == 13)
			{ //D
				Halt = true;
			}
			else if (opcode == 14)
			{ //E
				Halt = true;
			}
			else if (opcode == 15)
			{ //F
				Halt = true;
			}
			else
			{
				throw new NotImplementedException();
			}
		}


		#endregion

		#region Can Fetch/Decode/Execute

		bool _canFetch = true;
		bool canFetch
		{
			get { return _canFetch; }
			set { _canFetch = value; btnFetch.Enabled = value; }
		}
		bool _canDecode = false;
		bool canDecode
		{
			get { return _canDecode; }
			set { _canDecode = value; btnDecode.Enabled = value; }
		}
		bool _canExecute = false;
		bool canExecute
		{
			get { return _canExecute; }
			set { _canExecute = value; btnExecute.Enabled = value; }
		}

		bool FetchPossible()
		{
			if (Halt)
			{
				return (MessageBox.Show("The last performed instruction resulted in a halt to the execution of the program. Are you sure you want to perform the next operation?", "Instruction Halt"
				   , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes);
			}
			else if (Modified)
			{
				if (MessageBox.Show("Since the last operation, memory has been edited externally. Please check that you have adjusted the Program Counter correctly. Are you sure you want to perform the next operation?", "Instruction Halt"
				   , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
				{
					Modified = false;
					return true;
				}
				else return false;
			}
			else return true;
		}
		#endregion

		#region Quick Edit
		int curRow;
		int curCol;

		ListView lstData;
		bool _editing = false;
		bool editing
		{
			get { return _editing; }
			set { _editing = value; txtFastEdit.Visible = value; }
		}

		private void lstData_DoubleClick(object sender, EventArgs e)
		{
			lstData = (ListView)sender;
			Point position = lstData.PointToClient(System.Windows.Forms.Cursor.Position);
			int index = 0;
			var _myitem = lstData.SelectedItems[0];
			if (_myitem.SubItems[1].Bounds.Contains(position))
			{
				txtFastEdit.MaxLength = 8;
				index = 1;
			}
			else if (_myitem.SubItems[2].Bounds.Contains(position))
			{
				txtFastEdit.MaxLength = 2;
				index = 2;
			}
			else if (_myitem.SubItems[3].Bounds.Contains(position))
			{
				txtFastEdit.MaxLength = 4;
				index = 3;
			}
			else if (_myitem.SubItems[4].Bounds.Contains(position))
			{
				txtFastEdit.MaxLength = 7;
				index = 4;
			}
			else
			{ return; }
			curRow = _myitem.Index;
			curCol = index;

			txtFastEdit.Bounds = getBounds(curRow, curCol);
			txtFastEdit.Text = _myitem.SubItems[curCol].Text;
			editing = true;
			txtFastEdit.Focus();
			txtFastEdit.SelectionStart = 0;
			txtFastEdit.SelectionLength = txtFastEdit.TextLength;

		}
		public Rectangle getBounds(int row, int column)
		{
			int x = 0;
			int y = 0;
			int width = 0;
			int height = 0;
			Rectangle rect = lstData.Items[row].SubItems[column].Bounds;
			x = rect.X + lstData.Location.X + lstData.Parent.Location.X + 2;
			y = rect.Y + lstData.Location.Y + lstData.Parent.Location.Y + 2;
			width = lstData.Columns[column].Width;
			height = rect.Height;

			return new Rectangle(x, y, width, height);
		}

		public void ConfirmQuickEdit(bool Cancel = false)
		{

			if (editing == true)
			{
				if (!Cancel)
				{
					string txt = txtFastEdit.Text;
					switch (curCol)
					{
						case 1:
							if (!(string.IsNullOrEmpty(txt) || !Extra.IsBinable(txt)))

								if (lstData.Name == lstMyMemory.Name) EditMemory((byte)curRow, Extra.FromBin(txt));
								else if (lstData.Name == lstMyRegisters.Name) EditRegister((byte)curRow, Extra.FromBin(txt));

							break;
						case 2:
							if (!(string.IsNullOrEmpty(txt) || !Extra.IsHexable(txt)))
								if (lstData.Name == lstMyMemory.Name) EditMemory((byte)curRow, Extra.FromHex(txt));
								else if (lstData.Name == lstMyRegisters.Name) EditRegister((byte)curRow, Extra.FromHex(txt));
							break;
						case 3:
							sbyte x;
							if (sbyte.TryParse(txt, out x))
								if (lstData.Name == lstMyMemory.Name) EditMemory((byte)curRow, (byte)x);
								else if (lstData.Name == lstMyRegisters.Name) EditRegister((byte)curRow, (byte)x);
							break;
						case 4:
							float y;
							if (float.TryParse(txt, out y))
								if (lstData.Name == lstMyMemory.Name) EditMemory((byte)curRow, FloatingNotation.FloatToBits(y));
								else if (lstData.Name == lstMyRegisters.Name) EditRegister((byte)curRow, FloatingNotation.FloatToBits(y));
							break;
					}
				}
				editing = false;
				lstData.Focus();

			}
		}

		private void txtFastEdit_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) ConfirmQuickEdit();
			else if (e.KeyCode == Keys.Escape) ConfirmQuickEdit(true);
		}
		private void txtFastEdit_Leave(object sender, EventArgs e)
		{
			ConfirmQuickEdit();
		}
		private void lstData_MouseClick(object sender, MouseEventArgs e)
		{
			ConfirmQuickEdit();
		}

		#endregion


		private void btnFetch_Click(object sender, EventArgs e)
		{
			if (FetchPossible())
			{
				Fetch();
			}
		}

		private void btnDecode_Click(object sender, EventArgs e)
		{
			Decode();
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			Execute();
		}


		private void btnRunOne_Click(object sender, EventArgs e)
		{
			if (FetchPossible())
			{
				Fetch();
				Decode();
				Execute();
			}

		}
		private void btnRunLoop_Click(object sender, EventArgs e)
		{
			if (FetchPossible())
			{
				Stopwatch mytimer = new Stopwatch();
				mytimer.Start();

				while (true)
				{
					Fetch();
					Execute();
					if (Halt)
					{
						Halt = false;
						Decode();
						MessageBox.Show("The Execution has been terminated.", "Execution", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}
					else if (Limit)
					{
						Limit = false;
						Decode();
						MessageBox.Show("The Execution has reached the end of the memory.", "Execution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					}
					else if (mytimer.ElapsedMilliseconds > 7000)
					{
						Decode();
						MessageBox.Show("The Execution has timed out. Ensure that there are no infinite loops in the instruction set.", "Execution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						break;
					}
				}
				mytimer.Stop();
			}
		}

		private void txtPC_TextChanged(object sender, EventArgs e)
		{
			if (txtPC.Text == "") canFetch = false;
			else canFetch = Extra.IsHexable(txtPC.Text);

			Modified = false;
		}
		private void txtIR_TextChanged(object sender, EventArgs e)
		{

			if (txtIR.Text == "") canDecode = false;
			else canDecode = (txtIR.Text.Length == txtIR.MaxLength) && Extra.IsHexable(txtIR.Text);
		}

		private void txtOpcode_TextChanged(object sender, EventArgs e)
		{
			if (txtOpcode.Text == "") canExecute = false;
			else canExecute = true;
		}


		private void btnBatchEdit_Click(object sender, EventArgs e)
		{
			frmMemoryEdit MemoryEditInstance = new frmMemoryEdit(this);
			MemoryEditInstance.ShowDialog();
		}

		private void chkSimple_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSimple.Checked)
			{
				int removed1 = clmnH14.Width + clmnH15.Width;
				int removed2 = clmnH14.Width + clmnH15.Width;

				lstMyMemory.Columns.Remove(clmnH14);
				lstMyMemory.Columns.Remove(clmnH15);
				lstMyRegisters.Columns.Remove(clmnH24);
				lstMyRegisters.Columns.Remove(clmnH25);

				this.Width -= removed1 + removed2;

				grbMainMemory.Width -= removed1;
				chkSimple.Location = new Point(chkSimple.Location.X - removed1, chkSimple.Location.Y);

				grbRegister.Width -= removed2;
				grbRegister.Location = new Point(grbRegister.Location.X - removed2, grbRegister.Location.Y);
				grbControl.Width -= removed2;
				grbControl.Location = new Point(grbControl.Location.X - removed2, grbControl.Location.Y);
				grbScreen.Location = new Point(grbScreen.Location.X - removed2, grbScreen.Location.Y);
				btnRunOne.Text = "Run one cycle";
			}
			else
			{
				int removed1 = clmnH14.Width + clmnH15.Width;
				int removed2 = clmnH14.Width + clmnH15.Width;

				lstMyMemory.Columns.Add(clmnH14);
				lstMyMemory.Columns.Add(clmnH15);
				lstMyRegisters.Columns.Add(clmnH24);
				lstMyRegisters.Columns.Add(clmnH25);

				this.Width += removed1 + removed2;

				grbMainMemory.Width += removed1;
				chkSimple.Location = new Point(chkSimple.Location.X + removed1, chkSimple.Location.Y);

				grbRegister.Width += removed2;
				grbRegister.Location = new Point(grbRegister.Location.X + removed2, grbRegister.Location.Y);
				grbControl.Width += removed2;
				grbControl.Location = new Point(grbControl.Location.X + removed2, grbControl.Location.Y);
				grbScreen.Location = new Point(grbScreen.Location.X + removed2, grbScreen.Location.Y);
				btnRunOne.Text = "Run one cycle ( Fetch - Decode - Execute )";
			}
		}

		private void lst_KeyUp(object sender, KeyEventArgs e)
		{
			var list = (ListView)sender;
			if (list.SelectedIndices.Count > 0 && e.KeyData == Keys.Delete)
			{
				if (list.Name == lstMyRegisters.Name) EditRegister((byte)list.SelectedIndices[0], 0);
				else if (list.Name == lstMyMemory.Name) EditMemory((byte)list.SelectedIndices[0], 0);
			}
		}

		private void btnClearMemory_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to clear the entire memory?", "Clear Main Memory"
				   , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				FillMemory(new byte[256], 0x00);
		}
		private void btnClearRegister_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to clear all registers?", "Clear all Registers"
				, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				FillRegister(new byte[16], 0x00);
		}

		private void btnClearScreen_Click(object sender, EventArgs e)
		{
			txtScreen.Clear();
		}
	}
}