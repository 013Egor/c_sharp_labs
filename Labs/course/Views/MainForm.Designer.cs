
namespace Labs.Lab2_BattleShip.Views
{
    partial class MainForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.difficultySelection = new Labs.Lab2_BattleShip.Views.DifficultySelection();
            this.arrangingControl = new Labs.Lab2_BattleShip.Views.ArrangingControl();
            this.battleControl = new Labs.Lab2_BattleShip.Views.BattleControl();
            this.startControl = new Labs.Lab2_BattleShip.Views.StartControl();
            this.finishedControl = new Labs.Lab2_BattleShip.Views.FinishedControl();
            this.SuspendLayout();
            // 
            // arrangingControl
            // 
            this.arrangingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arrangingControl.Location = new System.Drawing.Point(0, 0);
            this.arrangingControl.Name = "arrangingControl";
            this.arrangingControl.Size = new System.Drawing.Size(800, 600);
            this.arrangingControl.TabIndex = 1;
            // 
            // battleControl
            // 
            this.battleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.battleControl.Location = new System.Drawing.Point(0, 0);
            this.battleControl.Name = "battleControl";
            this.battleControl.Size = new System.Drawing.Size(800, 600);
            this.battleControl.TabIndex = 0;
            // 
            // startControl
            // 
            this.startControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startControl.Location = new System.Drawing.Point(0, 0);
            this.startControl.Name = "startControl";
            this.startControl.Size = new System.Drawing.Size(800, 600);
            this.startControl.TabIndex = 2;
            // 
            // difficultySelection
            // 
            this.difficultySelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.difficultySelection.Location = new System.Drawing.Point(0, 0);
            this.difficultySelection.Name = "difficultySelection";
            this.difficultySelection.Size = new System.Drawing.Size(800, 600);
            this.difficultySelection.TabIndex = 4;
            // 
            // finishedControl
            // 
            this.finishedControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishedControl.Location = new System.Drawing.Point(0, 0);
            this.finishedControl.Name = "finishedControl";
            this.finishedControl.Size = new System.Drawing.Size(800, 600);
            this.finishedControl.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.finishedControl);
            this.Controls.Add(this.startControl);
            this.Controls.Add(this.difficultySelection);
            this.Controls.Add(this.arrangingControl);
            this.Controls.Add(this.battleControl);
            this.MaximumSize = new System.Drawing.Size(816, 639);
            this.MinimumSize = new System.Drawing.Size(816, 639);
            this.Name = "MainForm";
            this.Text = "Морской бой";
            this.ResumeLayout(false);

        }

        #endregion

        private DifficultySelection difficultySelection;
        private BattleControl battleControl;
        private ArrangingControl arrangingControl;
        private StartControl startControl;
        private FinishedControl finishedControl;
    }
}