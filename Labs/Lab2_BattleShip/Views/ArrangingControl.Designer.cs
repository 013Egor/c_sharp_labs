
namespace Labs.Lab2_BattleShip.Views
{
    partial class ArrangingControl
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


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArrangingControl));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fieldControl = new Labs.Lab2_BattleShip.Views.FieldControl();
            this.endArrangingButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel.BackgroundImage")));
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.fieldControl, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.endArrangingButton, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // fieldControl
            // 
            this.fieldControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldControl.Location = new System.Drawing.Point(203, 103);
            this.fieldControl.Name = "fieldControl";
            this.fieldControl.Size = new System.Drawing.Size(394, 394);
            this.fieldControl.TabIndex = 2;
            // 
            // endArrangingButton
            // 
            this.endArrangingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endArrangingButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.endArrangingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endArrangingButton.Location = new System.Drawing.Point(203, 503);
            this.endArrangingButton.Name = "endArrangingButton";
            this.endArrangingButton.Size = new System.Drawing.Size(394, 94);
            this.endArrangingButton.TabIndex = 0;
            this.endArrangingButton.Text = "В бой!!!";
            this.endArrangingButton.UseVisualStyleBackColor = false;
            // 
            // ArrangingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ArrangingControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button endArrangingButton;
        private FieldControl fieldControl;
    }
}
