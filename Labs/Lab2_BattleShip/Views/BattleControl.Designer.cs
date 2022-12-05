
namespace Labs.Lab2_BattleShip.Views
{
    partial class BattleControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleControl));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.humanFieldControl = new Labs.Lab2_BattleShip.Views.FieldControl();
            this.aiFieldControl = new Labs.Lab2_BattleShip.Views.FieldControl();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel.BackgroundImage")));
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.Controls.Add(this.humanFieldControl, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.aiFieldControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // humanFieldControl
            // 
            this.humanFieldControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.humanFieldControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.humanFieldControl.Location = new System.Drawing.Point(605, 5);
            this.humanFieldControl.Margin = new System.Windows.Forms.Padding(5);
            this.humanFieldControl.Name = "humanFieldControl";
            this.humanFieldControl.Size = new System.Drawing.Size(190, 190);
            this.humanFieldControl.TabIndex = 0;
            // 
            // aiFieldControl
            // 
            this.aiFieldControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.aiFieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aiFieldControl.Location = new System.Drawing.Point(5, 205);
            this.aiFieldControl.Margin = new System.Windows.Forms.Padding(5);
            this.aiFieldControl.Name = "aiFieldControl";
            this.aiFieldControl.Size = new System.Drawing.Size(390, 390);
            this.aiFieldControl.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Magenta;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(392, 76);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сохранить игру\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BattleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "BattleControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private FieldControl humanFieldControl;
        private FieldControl aiFieldControl;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
