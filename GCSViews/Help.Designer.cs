using Avalonia.Win32.Interoperability;

namespace MissionPlanner.GCSViews
{
	partial class Help
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
			this.CHK_showconsole = new System.Windows.Forms.CheckBox();
			this.BUT_updatecheck = new MissionPlanner.Controls.MyButton();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.BUT_betaupdate = new MissionPlanner.Controls.MyButton();
			this.winFormsAvaloniaControlHost = new WinFormsAvaloniaControlHost();
			this.SuspendLayout();
			//
			// CHK_showconsole
			//
			resources.ApplyResources(this.CHK_showconsole, "CHK_showconsole");
			this.CHK_showconsole.Name = "CHK_showconsole";
			this.CHK_showconsole.UseVisualStyleBackColor = true;
			this.CHK_showconsole.CheckedChanged += new System.EventHandler(this.CHK_showconsole_CheckedChanged);
			//
			// BUT_updatecheck
			//
			resources.ApplyResources(this.BUT_updatecheck, "BUT_updatecheck");
			this.BUT_updatecheck.Name = "BUT_updatecheck";
			this.BUT_updatecheck.UseVisualStyleBackColor = true;
			this.BUT_updatecheck.Click += new System.EventHandler(this.BUT_updatecheck_Click);
			//
			// linkLabel1
			//
			resources.ApplyResources(this.linkLabel1, "linkLabel1");
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabStop = true;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			//
			// BUT_betaupdate
			//
			resources.ApplyResources(this.BUT_betaupdate, "BUT_betaupdate");
			this.BUT_betaupdate.Name = "BUT_betaupdate";
			this.BUT_betaupdate.UseVisualStyleBackColor = true;
			this.BUT_betaupdate.Click += new System.EventHandler(this.BUT_betaupdate_Click);
			//
			// winFormsAvaloniaControlHost
			//
			resources.ApplyResources(this.winFormsAvaloniaControlHost, "winFormsAvaloniaControlHost");
			this.winFormsAvaloniaControlHost.Name = "winFormsAvaloniaControlHost";
			//
			// Help
			//
			this.Controls.Add(this.winFormsAvaloniaControlHost);
			this.Controls.Add(this.BUT_betaupdate);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.CHK_showconsole);
			this.Controls.Add(this.BUT_updatecheck);
			resources.ApplyResources(this, "$this");
			this.Name = "Help";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.MyButton BUT_updatecheck;
		private System.Windows.Forms.CheckBox CHK_showconsole;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private Controls.MyButton BUT_betaupdate;
		private WinFormsAvaloniaControlHost winFormsAvaloniaControlHost { get; set; }
	}
}
