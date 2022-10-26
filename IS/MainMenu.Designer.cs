
namespace IS
{
    partial class MainMenu
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
            this.btnTransations = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTransations
            // 
            this.btnTransations.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTransations.Image = global::IS.Properties.Resources.icons8_transaction_30;
            this.btnTransations.Location = new System.Drawing.Point(217, 26);
            this.btnTransations.Name = "btnTransations";
            this.btnTransations.Size = new System.Drawing.Size(150, 75);
            this.btnTransations.TabIndex = 0;
            this.btnTransations.Text = "Transactions";
            this.btnTransations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransations.UseVisualStyleBackColor = true;
            this.btnTransations.Click += new System.EventHandler(this.btnTransations_Click);
            // 
            // btnItems
            // 
            this.btnItems.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnItems.Image = global::IS.Properties.Resources.icons8_add_shopping_cart_30;
            this.btnItems.Location = new System.Drawing.Point(20, 26);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(150, 75);
            this.btnItems.TabIndex = 1;
            this.btnItems.Text = "Items";
            this.btnItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInventory.Image = global::IS.Properties.Resources.icons8_in_inventory_30;
            this.btnInventory.Location = new System.Drawing.Point(412, 26);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(150, 75);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventory.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 118);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.btnTransations);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTransations;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnInventory;
    }
}