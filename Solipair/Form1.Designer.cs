namespace Solipair {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pP1Deck = new System.Windows.Forms.Panel();
            this.lP1Deck = new System.Windows.Forms.Label();
            this.pP1Discard = new System.Windows.Forms.Panel();
            this.lP1DiscardTop = new System.Windows.Forms.Label();
            this.lP1Discard = new System.Windows.Forms.Label();
            this.pCard1 = new System.Windows.Forms.Panel();
            this.pCard4 = new System.Windows.Forms.Panel();
            this.pCard3 = new System.Windows.Forms.Panel();
            this.pCard2 = new System.Windows.Forms.Panel();
            this.pP2Discard = new System.Windows.Forms.Panel();
            this.lP2DiscardTop = new System.Windows.Forms.Label();
            this.lP2Discard = new System.Windows.Forms.Label();
            this.pP2Deck = new System.Windows.Forms.Panel();
            this.lP2Deck = new System.Windows.Forms.Label();
            this.bReset = new System.Windows.Forms.Button();
            this.lPlayerTurn = new System.Windows.Forms.Label();
            this.pP1Deck.SuspendLayout();
            this.pP1Discard.SuspendLayout();
            this.pP2Discard.SuspendLayout();
            this.pP2Deck.SuspendLayout();
            this.SuspendLayout();
            // 
            // pP1Deck
            // 
            this.pP1Deck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pP1Deck.Controls.Add(this.lP1Deck);
            this.pP1Deck.Location = new System.Drawing.Point(21, 474);
            this.pP1Deck.Name = "pP1Deck";
            this.pP1Deck.Size = new System.Drawing.Size(106, 150);
            this.pP1Deck.TabIndex = 0;
            this.pP1Deck.Tag = "Card";
            this.pP1Deck.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pP1Deck_MouseClick);
            // 
            // lP1Deck
            // 
            this.lP1Deck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lP1Deck.AutoSize = true;
            this.lP1Deck.Location = new System.Drawing.Point(42, 63);
            this.lP1Deck.Name = "lP1Deck";
            this.lP1Deck.Size = new System.Drawing.Size(19, 15);
            this.lP1Deck.TabIndex = 0;
            this.lP1Deck.Text = "36";
            this.lP1Deck.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pCard1_MouseClick);
            // 
            // pP1Discard
            // 
            this.pP1Discard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pP1Discard.Controls.Add(this.lP1DiscardTop);
            this.pP1Discard.Controls.Add(this.lP1Discard);
            this.pP1Discard.Location = new System.Drawing.Point(159, 474);
            this.pP1Discard.Name = "pP1Discard";
            this.pP1Discard.Size = new System.Drawing.Size(106, 150);
            this.pP1Discard.TabIndex = 1;
            this.pP1Discard.Tag = "Card";
            this.pP1Discard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pP1Discard_MouseClick);
            // 
            // lP1DiscardTop
            // 
            this.lP1DiscardTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lP1DiscardTop.AutoSize = true;
            this.lP1DiscardTop.Location = new System.Drawing.Point(12, 87);
            this.lP1DiscardTop.Name = "lP1DiscardTop";
            this.lP1DiscardTop.Size = new System.Drawing.Size(81, 15);
            this.lP1DiscardTop.TabIndex = 1;
            this.lP1DiscardTop.Text = "lP1DiscardTop";
            this.lP1DiscardTop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pP1Discard_MouseClick);
            // 
            // lP1Discard
            // 
            this.lP1Discard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lP1Discard.AutoSize = true;
            this.lP1Discard.Location = new System.Drawing.Point(45, 60);
            this.lP1Discard.Name = "lP1Discard";
            this.lP1Discard.Size = new System.Drawing.Size(13, 15);
            this.lP1Discard.TabIndex = 0;
            this.lP1Discard.Text = "0";
            this.lP1Discard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pP1Discard_MouseClick);
            // 
            // pCard1
            // 
            this.pCard1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCard1.Location = new System.Drawing.Point(512, 30);
            this.pCard1.Name = "pCard1";
            this.pCard1.Size = new System.Drawing.Size(112, 433);
            this.pCard1.TabIndex = 2;
            this.pCard1.Tag = "Card";
            this.pCard1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pCard1_MouseClick);
            // 
            // pCard4
            // 
            this.pCard4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCard4.Location = new System.Drawing.Point(895, 30);
            this.pCard4.Name = "pCard4";
            this.pCard4.Size = new System.Drawing.Size(112, 433);
            this.pCard4.TabIndex = 3;
            this.pCard4.Tag = "Card";
            this.pCard4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pCard4_MouseClick);
            // 
            // pCard3
            // 
            this.pCard3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCard3.Location = new System.Drawing.Point(768, 30);
            this.pCard3.Name = "pCard3";
            this.pCard3.Size = new System.Drawing.Size(112, 433);
            this.pCard3.TabIndex = 3;
            this.pCard3.Tag = "Card";
            this.pCard3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pCard3_MouseClick);
            // 
            // pCard2
            // 
            this.pCard2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCard2.Location = new System.Drawing.Point(639, 30);
            this.pCard2.Name = "pCard2";
            this.pCard2.Size = new System.Drawing.Size(112, 433);
            this.pCard2.TabIndex = 3;
            this.pCard2.Tag = "Card";
            this.pCard2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pCard2_MouseClick);
            // 
            // pP2Discard
            // 
            this.pP2Discard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pP2Discard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pP2Discard.Controls.Add(this.lP2DiscardTop);
            this.pP2Discard.Controls.Add(this.lP2Discard);
            this.pP2Discard.Location = new System.Drawing.Point(1209, 474);
            this.pP2Discard.Name = "pP2Discard";
            this.pP2Discard.Size = new System.Drawing.Size(104, 150);
            this.pP2Discard.TabIndex = 3;
            this.pP2Discard.Tag = "Card";
            this.pP2Discard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pP2Discard_MouseClick);
            // 
            // lP2DiscardTop
            // 
            this.lP2DiscardTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lP2DiscardTop.AutoSize = true;
            this.lP2DiscardTop.Location = new System.Drawing.Point(12, 87);
            this.lP2DiscardTop.Name = "lP2DiscardTop";
            this.lP2DiscardTop.Size = new System.Drawing.Size(81, 15);
            this.lP2DiscardTop.TabIndex = 1;
            this.lP2DiscardTop.Text = "lP2DiscardTop";
            // 
            // lP2Discard
            // 
            this.lP2Discard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lP2Discard.AutoSize = true;
            this.lP2Discard.Location = new System.Drawing.Point(45, 60);
            this.lP2Discard.Name = "lP2Discard";
            this.lP2Discard.Size = new System.Drawing.Size(13, 15);
            this.lP2Discard.TabIndex = 0;
            this.lP2Discard.Text = "0";
            // 
            // pP2Deck
            // 
            this.pP2Deck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pP2Deck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pP2Deck.Controls.Add(this.lP2Deck);
            this.pP2Deck.Location = new System.Drawing.Point(1345, 474);
            this.pP2Deck.Name = "pP2Deck";
            this.pP2Deck.Size = new System.Drawing.Size(104, 150);
            this.pP2Deck.TabIndex = 2;
            this.pP2Deck.Tag = "Card";
            this.pP2Deck.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pP2Deck_MouseClick);
            // 
            // lP2Deck
            // 
            this.lP2Deck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lP2Deck.AutoSize = true;
            this.lP2Deck.Location = new System.Drawing.Point(40, 65);
            this.lP2Deck.Name = "lP2Deck";
            this.lP2Deck.Size = new System.Drawing.Size(19, 15);
            this.lP2Deck.TabIndex = 0;
            this.lP2Deck.Text = "36";
            this.lP2Deck.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pP2Deck_MouseClick);
            // 
            // bReset
            // 
            this.bReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bReset.Location = new System.Drawing.Point(732, 535);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 7;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // lPlayerTurn
            // 
            this.lPlayerTurn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lPlayerTurn.AutoSize = true;
            this.lPlayerTurn.Location = new System.Drawing.Point(750, 496);
            this.lPlayerTurn.Name = "lPlayerTurn";
            this.lPlayerTurn.Size = new System.Drawing.Size(38, 15);
            this.lPlayerTurn.TabIndex = 8;
            this.lPlayerTurn.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 648);
            this.Controls.Add(this.pCard1);
            this.Controls.Add(this.pCard2);
            this.Controls.Add(this.pP2Deck);
            this.Controls.Add(this.pCard3);
            this.Controls.Add(this.pP1Deck);
            this.Controls.Add(this.pCard4);
            this.Controls.Add(this.pP2Discard);
            this.Controls.Add(this.lPlayerTurn);
            this.Controls.Add(this.pP1Discard);
            this.Controls.Add(this.bReset);
            this.MinimumSize = new System.Drawing.Size(1487, 687);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pP1Deck.ResumeLayout(false);
            this.pP1Deck.PerformLayout();
            this.pP1Discard.ResumeLayout(false);
            this.pP1Discard.PerformLayout();
            this.pP2Discard.ResumeLayout(false);
            this.pP2Discard.PerformLayout();
            this.pP2Deck.ResumeLayout(false);
            this.pP2Deck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pP1Deck;
        private Label lP1Deck;
        private Panel pP1Discard;
        private Label lP1Discard;
        private Label lP1DiscardTop;
        private Panel pCard1;
        private Panel pCard4;
        private Panel pCard3;
        private Panel pCard2;
        private Panel pP2Discard;
        private Label lP2DiscardTop;
        private Label lP2Discard;
        private Panel pP2Deck;
        private Label lP2Deck;
        private Button bReset;
        private Label lPlayerTurn;
    }
}